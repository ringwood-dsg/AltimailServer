﻿// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer;
using NUnit.Framework;
using RegressionTests.Infrastructure;
using RegressionTests.Shared;
using System;
using System.Collections.Generic;
using System.IO;

namespace RegressionTests.AntiSpam.DKIM
{
   [TestFixture]
   public class Signing : TestFixtureBase
   {
      #region Setup/Teardown

      [SetUp]
      public new void SetUp()
      {
         _antiSpam = _application.Settings.AntiSpam;

         _antiSpam.SpamDeleteThreshold = 5;
      }

      #endregion

      private AltimailServer.AntiSpam _antiSpam;

      private string GetPrivateKeyFile()
      {
         string sslPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "..\\..\\..\\..\\SSL examples");

         var exampleKeyFile = Path.Combine(sslPath, "example.key");
         if (!File.Exists((exampleKeyFile)))
            throw new Exception("Example key file could not be found.");

         return exampleKeyFile;
      }

      private string SendMessage(bool? sendAsAlias = false)
      {
         return SendMessage("Test message", sendAsAlias);
      }

      private string SendMessage(string body, bool? sendAsAlias = false)
      {
         SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");

         // setup DomainAlias
         if (sendAsAlias.HasValue && sendAsAlias.Value.Equals(true))
         {
            var domainAlias = _domain.DomainAliases.Add();
            domainAlias.DomainID = _domain.ID;
            domainAlias.AliasName = "test.org";
            domainAlias.Save();
            _domain.Save();
         }

         var deliveryResults = new Dictionary<string, int>();
         deliveryResults["test@example.com"] = 250;

         int port = TestSetup.GetNextFreePort();
         using (var server = new SmtpServerSimulator(1, port))
         {
            server.SecondsToWaitBeforeTerminate = 60;
            server.AddRecipientResult(deliveryResults);
            server.StartListen();

            // Add a route so we can connect to localhost.
            AddRoutePointingAtLocalhost(5, port);

            // Send message to this route.
            var smtp = new SmtpClientSimulator();
            var recipients = new List<string>();
            recipients.Add("test@example.com");

            // send as primary or domain alias?
            if (sendAsAlias.HasValue && sendAsAlias.Value.Equals(true))
               smtp.Send("test@test.org", recipients, "Test", body);
            else
               smtp.Send("test@test.com", recipients, "Test", body);

            // Wait for the client to disconnect.
            server.WaitForCompletion();
            string messageData = server.MessageData;

            CustomAsserts.AssertRecipientsInDeliveryQueue(0);

            return messageData;
         }
      }

      internal static Route AddRoutePointingAtLocalhost(int numberOfTries, int port)
      {
         // Add a route pointing at localhost
         Settings settings = SingletonProvider<TestSetup>.Instance.GetApp().Settings;

         Route route = settings.Routes.Add();
         route.DomainName = "example.com";
         route.TargetSMTPHost = "localhost";
         route.TargetSMTPPort = port;
         route.NumberOfTries = numberOfTries;
         route.MinutesBetweenTry = 5;
         route.Save();

         return route;
      }

      [Test]
      [Description("Test usage of algorithm RSA-SHA1.")]
      public void TestAlgorithmSHA1()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSigningAlgorithm = eDKIMAlgorithm.eSHA1;
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsTrue(result.ToLower().Contains("a=rsa-sha1"), result);
      }

      [Test]
      [Description("Test usage of algorithm RSA-SHA256.")]
      public void TestAlgorithmSHA256()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSigningAlgorithm = eDKIMAlgorithm.eSHA256;
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();

         if (result.ToLower().Contains("a=rsa-sha256") == false)
         {
            Assert.Fail(result);
         }
      }

      [Test]
      [Description("Test that the default canonicalization method is relaxed/relaxed.")]
      public void TestCanonicalizationMethodSimpleSimple()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMBodyCanonicalizationMethod = eDKIMCanonicalizationMethod.eCanonicalizationSimple;
         _domain.DKIMHeaderCanonicalizationMethod = eDKIMCanonicalizationMethod.eCanonicalizationSimple;
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsTrue(result.ToLower().Contains("simple/simple"), result);
      }

      [Test]
      [Description("Test that the default canonicalization method is relaxed/relaxed.")]
      public void TestDefaultAlgorithm()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsTrue(result.ToLower().Contains("a=rsa-sha256"), result);
      }

      [Test]
      [Description("Test that the default canonicalization method is relaxed/relaxed.")]
      public void TestDefaultCanonicalizationMethod()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsTrue(result.ToLower().Contains("relaxed/relaxed"), result);
      }

      [Test]
      [Description("Test that senders domain is specified in the d=tag.")]
      public void TestDomainInHeader()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsTrue(result.ToLower().Contains("dkim-signature"), result);
         Assert.IsTrue(result.ToLower().Contains("d=" + _domain.Name.ToLower()), result);
      }

      //RvdH
      [Test]
      [Description("Test that senders domain alias is specified in the d=tag.")]
      public void TestDomainDomainAliasInHeader()
      {
         // Enable DomainAlias Signing
         _domain.DKIMSignAliasesEnabled = true;
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage("Test Message", true);
         Assert.IsTrue(result.ToLower().Contains("dkim-signature"), result);
         Assert.IsTrue(result.ToLower().Contains("d=" + _domain.DomainAliases[0].AliasName.ToLower()), result);
      }

      [Test]
      [Description("Test that the selector specified in the domain is specified in the header.")]
      public void TestSelectorInHeader()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "MySelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsTrue(result.ToLower().Contains("dkim-signature"), result);
         Assert.IsTrue(result.Contains("s=MySelector"), result);
      }


      [Test]
      [Description("Test to DKIM sign an empty body.")]
      public void TestSignSingleEmptyBody()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage("");
         Assert.IsTrue(result.Contains("bh=47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=;"), result);
      }

      [Test]
      [Description("Test to DKIM sign an empty body.")]
      public void TestSignSingleFewWordBody()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage("Whati\r\nwhati\r\n\r\nwhati\r\n\r\n");
         Assert.IsTrue(result.Contains("bh=HfVBKUbHPvnfdY6y9RCu4IDyM+v+0HkekU0RPi3bgCk=;"), result);
      }

      [Test]
      [Description("Test to DKIM sign an empty body.")]
      public void TestSignSingleWordBody()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage("Test");
         Assert.IsTrue(result.Contains("bh=fdkeB/A0FkbVP2k4J4pNPoeWH6vqBm9+b0C3OY87Cw8=;"), result);
      }

      [Test]
      [Description("Test that a message sent through a new domain is not tagged.")]
      public void TestSigningDisabled()
      {
         string result = SendMessage();
         Assert.IsFalse(result.ToLower().Contains("dkim-signature"), result);
      }

      [Test]
      [Description("Test that a dkim-sigature is added if both the selector and private key is specified.")]
      public void TestSigningEnabled()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSelector = "TestSelector";
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsTrue(result.ToLower().Contains("dkim-signature"), result);
      }

      [Test]
      [Description("Test that no dkim-sigature is added if the private key is not specified.")]
      public void TestSigningEnabledNoPrivateKey()
      {
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsFalse(result.ToLower().Contains("dkim-signature"), result);

         CustomAsserts.AssertReportedError("Either the selector or private key file was not specified.");
      }

      [Test]
      [Description("Test that no dkim-sigature is added if the selector is not specified.")]
      public void TestSigningEnabledNoSelector()
      {
         _domain.DKIMPrivateKeyFile = GetPrivateKeyFile();
         _domain.DKIMSignEnabled = true;
         _domain.Save();

         string result = SendMessage();
         Assert.IsFalse(result.ToLower().Contains("dkim-signature"), result);

         CustomAsserts.AssertReportedError("Either the selector or private key file was not specified.");
      }
   }
}