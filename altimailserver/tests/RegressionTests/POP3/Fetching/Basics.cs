﻿// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer;
using NUnit.Framework;
using RegressionTests.Infrastructure;
using RegressionTests.Shared;
using System;
using System.Collections.Generic;

namespace RegressionTests.POP3.Fetching
{
   [TestFixture]
   public class Basics : TestFixtureBase
   {
      private static FetchAccount CreateFetchAccount(Account account, int port, bool antiSpam, bool antiVirus)
      {
         FetchAccount fa = account.FetchAccounts.Add();

         fa.Enabled = true;
         fa.MinutesBetweenFetch = 10;
         fa.Name = "Test";
         fa.Username = "test@example.com";
         fa.Password = "test";
         fa.UseSSL = false;
         fa.ServerAddress = "localhost";
         fa.Port = port;
         fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
         fa.ProcessMIMERecipients = false;
         fa.DaysToKeepMessages = -1;
         fa.UseAntiSpam = antiSpam;
         fa.UseAntiVirus = antiVirus;
         fa.Save();
         return fa;
      }

      [Test]
      public void TestAntiVirusDisabled()
      {
         var messages = new List<string>();

         string messageText = "From: spftest@openspf.org\r\n" +
                              "To: Martin@example.com\r\n" +
                              "Subject: Test\r\n" +
                              "\r\n" +
                              "Should be blocked by SPF.";

         messages.Add(messageText);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = CreateFetchAccount(account, port, false, false);

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);

            Message message = account.IMAPFolders.get_ItemByName("INBOX").Messages[0];
            Assert.IsFalse(message.get_Flag(eMessageFlag.eMFVirusScan));
         }
      }

      [Test]
      public void TestAntiVirusEnabled()
      {
         var messages = new List<string>();

         string messageText = "From: spftest@openspf.org\r\n" +
                              "To: Martin@example.com\r\n" +
                              "Subject: Test\r\n" +
                              "\r\n" +
                              "Should be blocked by SPF.";

         messages.Add(messageText);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = CreateFetchAccount(account, port, false, true);

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);

            Message message = account.IMAPFolders.get_ItemByName("INBOX").Messages[0];
            Assert.IsTrue(message.get_Flag(eMessageFlag.eMFVirusScan));
         }
      }

      [Test]
      public void TestBasicExternalAccount()
      {
         var messages = new List<string>();

         string message = "Received: from example.com (example.com [1.2.3.4]) by mail.host.edu\r\n" +
                          "From: Martin@example.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            string downloadedMessage = Pop3ClientSimulator.AssertGetFirstMessageText(account.Address, "test");

            StringAssert.Contains("Subject: Test", downloadedMessage);
            StringAssert.Contains("Hello!", downloadedMessage);
         }
      }

      [Test]
      public void TestFetchFromInvalidHostName()
      {
         Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
         FetchAccount fa = account.FetchAccounts.Add();

         fa.Enabled = true;
         fa.MinutesBetweenFetch = 10;
         fa.Name = "Test";
         fa.Username = "test@example.com";
         fa.Password = "test";
         fa.UseSSL = false;
         fa.ServerAddress = "nonexistant.example.com";
         fa.Port = 110;
         fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
         fa.ProcessMIMERecipients = false;
         fa.Save();

         fa.DownloadNow();

         RetryHelper.TryAction(TimeSpan.FromSeconds(10), () =>
         {
            var
               log = LogHandler.ReadCurrentDefaultLog();

            if (!log.Contains("The IP address for external account Test could not be resolved. Aborting fetch."))
               throw new Exception("Expected message not appearing in log.");
         });

         fa.Delete();
      }


      [Test]
      public void TestDelete()
      {
         var messages = new List<string>();

         string message = "From: Martin@example.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = -1;
            fa.Save();


            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            string downloadedMessage = Pop3ClientSimulator.AssertGetFirstMessageText(account.Address, "test");

            StringAssert.Contains("Hello!", downloadedMessage);
            Assert.AreEqual(1, pop3Server.DeletedMessages.Count);
         }
      }

      [Test]
      public void TestDeleteMutliple()
      {
         var messages = new List<string>();

         string message = "From: Martin@example.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);
         messages.Add(message);
         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = -1;
            fa.Save();


            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 3);

            Assert.AreEqual(3, pop3Server.DeletedMessages.Count);
         }
      }

      [Test]
      [Description("Issue 215, Mail not delivered to MIME recipients (if external). Test option disabled.")]
      public void TestDeliverToExternalMimeRecipientsDisabled()
      {
         var messages = new List<string>();

         string message = "From: Martin@example.com\r\n" +
                          "To: \"Test\" <test1@test.com>, \"ExternalGuy\" <external@dummy-example.com>\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            var deliveryResults = new Dictionary<string, int>();
            deliveryResults["external@dummy-example.com"] = 250;

            Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            Account account2 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test1@test.com", "test");
            Account catchallAccount = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "catchall@test.com",
                                                                                       "test");

            _domain.Postmaster = catchallAccount.Address;
            _domain.Save();

            FetchAccount fa = account1.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            string downloadedMessage1 = Pop3ClientSimulator.AssertGetFirstMessageText(account2.Address, "test");
            Pop3ClientSimulator.AssertMessageCount(account1.Address, "test", 0);
            StringAssert.Contains("Hello!", downloadedMessage1);

            Pop3ClientSimulator.AssertMessageCount(account2.Address, "test", 0);
            Pop3ClientSimulator.AssertMessageCount(catchallAccount.Address, "test", 0);
         }
      }

      [Test]
      [Description("Issue 215, Mail not delivered to MIME recipients (if external)")]
      public void TestDeliverToExternalMimeRecipientsEnabled()
      {
         var messages = new List<string>();

         string message = "From: Martin@example.com\r\n" +
                          "To: \"Test\" <test1@test.com>, \"ExternalGuy\" <external@dummy-example.com>\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            var deliveryResults = new Dictionary<string, int>();
            deliveryResults["external@dummy-example.com"] = 250;

            int smtpServerPort = TestSetup.GetNextFreePort();
            using (var smtpServer = new SmtpServerSimulator(1, smtpServerPort))
            {
               smtpServer.AddRecipientResult(deliveryResults);
               smtpServer.StartListen();

               // Add a route so we can connect to localhost.
               Route route = TestSetup.AddRoutePointingAtLocalhost(1, smtpServerPort, false);
               route.TreatSecurityAsLocalDomain = true;
               route.Save();

               Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
               Account account2 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test1@test.com", "test");
               Account catchallAccount = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "catchall@test.com",
                                                                                          "test");

               _domain.Postmaster = catchallAccount.Address;
               _domain.Save();

               FetchAccount fa = account1.FetchAccounts.Add();

               fa.Enabled = true;
               fa.MinutesBetweenFetch = 10;
               fa.Name = "Test";
               fa.Username = "test@example.com";
               fa.Password = "test";
               fa.UseSSL = false;
               fa.ServerAddress = "localhost";
               fa.Port = port;
               fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
               fa.ProcessMIMERecipients = true;
               fa.EnableRouteRecipients = true;
               fa.Save();

               fa.DownloadNow();

               pop3Server.WaitForCompletion();

               fa.Delete();

               string downloadedMessage1 = Pop3ClientSimulator.AssertGetFirstMessageText(account2.Address, "test");
               Pop3ClientSimulator.AssertMessageCount(account1.Address, "test", 0);
               Pop3ClientSimulator.AssertMessageCount(catchallAccount.Address, "test", 0);
               StringAssert.Contains("Hello!", downloadedMessage1);

               // Make sure the exernal list has received his copy.
               smtpServer.WaitForCompletion();
               string messageData = smtpServer.MessageData;
               Assert.IsTrue(messageData.Contains(messageData), messageData);

               CustomAsserts.AssertRecipientsInDeliveryQueue(0, false);
            }
         }
      }

      [Test]
      [Description(
         "Issue 215, Mail not delivered to MIME recipients (if external). Test to deliver when the route is external."
         )]
      public void TestDeliverToExternalMimeRecipientsEnabledRouteAsExternal()
      {
         var messages = new List<string>();

         string message = "From: Martin@example.com\r\n" +
                          "To: \"Test\" <test1@test.com>, \"ExternalGuy\" <external@dummy-example.com>\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account userAccount = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            Account recipientAccount1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test1@test.com",
                                                                                         "test");
            Account catchallAccount = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "catchall@test.com",
                                                                                       "test");

            _domain.Postmaster = catchallAccount.Address;
            _domain.Save();

            FetchAccount fa = userAccount.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = true;
            fa.EnableRouteRecipients = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            string downloadedMessage1 = Pop3ClientSimulator.AssertGetFirstMessageText(recipientAccount1.Address, "test");
            StringAssert.Contains("Hello!", downloadedMessage1);

            CustomAsserts.AssertRecipientsInDeliveryQueue(0, false);
         }
      }

      [Test]
      public void TestDeliverToMIMERecipients()
      {
         var messages = new List<string>();

         string message = "From: Martin@example.com\r\n" +
                          "To: \"Test\" <test1@test.com>, \"Test 2\" <test2@test.com>\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            Account account2 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test1@test.com", "test");
            Account account3 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test2@test.com", "test");
            Account catchallAccount = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "catchall@test.com",
                                                                                       "test");

            _domain.Postmaster = catchallAccount.Address;
            _domain.Save();


            FetchAccount fa = account1.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            string downloadedMessage1 = Pop3ClientSimulator.AssertGetFirstMessageText(account2.Address, "test");
            string downloadedMessage2 = Pop3ClientSimulator.AssertGetFirstMessageText(account3.Address, "test");
            Pop3ClientSimulator.AssertMessageCount(account1.Address, "test", 0);
            Pop3ClientSimulator.AssertMessageCount(catchallAccount.Address, "test", 0);

            StringAssert.Contains("Hello!", downloadedMessage1);
            StringAssert.Contains("Hello!", downloadedMessage2);
         }
      }

      [Test]
      [Description("Issue 313, External fetch thread hangs on -ERR response")]
      public void TestServerNotSupportingUIDL()
      {
         var messages = new List<string>();

         string message = "Received: from example.com (example.com [1.2.3.4]) by mail.host.edu\r\n" +
                          "From: Martin@example.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Hello!";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.SupportsUIDL = false;
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.Save();
            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            RetryHelper.TryAction(TimeSpan.FromSeconds(10), () =>
            {
               string error = LogHandler.ReadCurrentDefaultLog();

               RetryableAssert.IsTrue(error.Contains("-ERR unhandled command"));
               RetryableAssert.IsTrue(error.Contains("Completed retrieval of messages from external account."));
            });
         }
      }

      [Test]
      public void TestSpamProtectionDisabled()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";


         _application.Settings.AntiSpam.UseSPF = true;
         _application.Settings.AntiSpam.UseSPFScore = 5;

         var messages = new List<string>();

         string message = "From: spftest@openspf.org\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should be blocked by SPF.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = -1;
            fa.UseAntiSpam = false;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            string downloadedMessage = Pop3ClientSimulator.AssertGetFirstMessageText(account.Address, "test");

            Assert.IsFalse(downloadedMessage.Contains("X-hMailServer-Spam: YES"));
         }
      }

      [Test]
      [Description("Issue 249: POP3 download may fail on spam message")]
      public void TestSpamProtectionNoTagging()
      {
         CustomAsserts.AssertSpamAssassinIsRunning();
         System.Threading.Thread.Sleep(5000);

         _application.Settings.AntiSpam.SpamMarkThreshold = 5;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 9999;
         _application.Settings.AntiSpam.MaximumMessageSize = 1024 * 1024;
         _application.Settings.AntiSpam.AddHeaderReason = false;
         _application.Settings.AntiSpam.AddHeaderSpam = false;
         _application.Settings.AntiSpam.PrependSubject = false;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         // Enable SpamAssassin
         _application.Settings.AntiSpam.SpamAssassinEnabled = true;
         _application.Settings.AntiSpam.SpamAssassinHost = "localhost";
         _application.Settings.AntiSpam.SpamAssassinPort = 783;
         _application.Settings.AntiSpam.SpamAssassinMergeScore = true;
         _application.Settings.AntiSpam.SpamAssassinScore = 5;

         var messages = new List<string>();

         string message = "From: Martin@example.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "XJS*C4JDBQADN1.NSBN3*2IDNEN*GTUBE-STANDARD-ANTI-UBE-TEST-EMAIL*C.34X";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = -1;
            fa.UseAntiSpam = true;

            fa.Save();
            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);
         }
      }

      [Test]
      public void TestSpamProtectionPostTransmission()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";


         SURBLServer surblServer = _application.Settings.AntiSpam.SURBLServers[0];
         surblServer.Active = true;
         surblServer.Score = 5;
         surblServer.Save();

         var messages = new List<string>();

         string message = "Received: from example.com (example.com [1.2.3.4]) by mail.host.edu\r\n" +
                          "From: Martin@example.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "http://surbl-org-permanent-test-point.com/";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = -1;
            fa.UseAntiSpam = true;

            fa.Save();
            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            string downloadedMessage = Pop3ClientSimulator.AssertGetFirstMessageText(account.Address, "test");

            Assert.IsTrue(downloadedMessage.Contains("X-hMailServer-Spam: YES"));
         }
      }


      [Test]
      public void TestSpamProtectionPreTransmissionHELODelete()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         _application.Settings.AntiSpam.CheckHostInHelo = true;
         _application.Settings.AntiSpam.CheckHostInHeloScore = 105;

         var messages = new List<string>();

         string message = "Received: from openspf.org (openspf.org [1.2.1.1]) by mail.host.edu\r\n" +
                          "From: spftest@openspf.org\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should be blocked by SPF.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = 0;
            fa.UseAntiSpam = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 0);
         }
      }

      [Test]
      public void TestSpamProtectionPreTransmissionHELOPass()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         _application.Settings.AntiSpam.CheckHostInHelo = true;
         _application.Settings.AntiSpam.CheckHostInHeloScore = 105;

         var messages = new List<string>();

         string message = "Received: from mail.AltimailServer.com (mail.AltimailServer.com [" +
                          TestSetup.GethMailServerCOMIPaddress() + "]) by mail.host.edu\r\n" +
                          "From: spftest@openspf.org\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should not be blocked.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = 0;
            fa.UseAntiSpam = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);
         }
      }

      [Test]
      [Description("Test that the spam test skips hosts which are listed as incoming relays.")]
      public void TestSpamProtectionPreTransmissionHELOPassFirst()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         _application.Settings.AntiSpam.CheckHostInHelo = true;
         _application.Settings.AntiSpam.CheckHostInHeloScore = 105;

         IncomingRelay incomingRelay = _application.Settings.IncomingRelays.Add();
         incomingRelay.LowerIP = "1.2.1.2";
         incomingRelay.UpperIP = "1.2.1.3";
         incomingRelay.Name = "Test";
         incomingRelay.Save();

         var messages = new List<string>();

         string message = "Received: from example.com (example.com [1.2.1.2]) by mail.host.edu\r\n" +
                          "Received: from mail.AltimailServer.com (mail.AltimailServer.com [" +
                          TestSetup.GethMailServerCOMIPaddress() + "]) by mail.host.edu\r\n" +
                          "From: spftest@openspf.org\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should be blocked by SPF.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = 0;
            fa.UseAntiSpam = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);
         }
      }

      [Test]
      public void TestSpamProtectionPreTransmissionSPFDelete()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         _application.Settings.AntiSpam.UseSPF = true;
         _application.Settings.AntiSpam.UseSPFScore = 105;

         var messages = new List<string>();

         string message = "Received: from openspf.org (openspf.org [1.2.3.4]) by mail.host.edu\r\n" +
                          "From: spftest@openspf.org\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should be blocked by SPF.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = 0;
            fa.UseAntiSpam = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 0);
         }
      }

      [Test]
      public void TestSpamProtectionPreTransmissionSPFPass()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         _application.Settings.AntiSpam.UseSPF = true;
         _application.Settings.AntiSpam.UseSPFScore = 105;

         var messages = new List<string>();

         string message = "Received: from example.com (mail.AltimailServer.com [" + TestSetup.GethMailServerCOMIPaddress() + "]) by mail.example.com\r\n" +
                          "From: test@AltimailServer.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should not be blocked.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = 0;
            fa.UseAntiSpam = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);
         }
      }


      [Test]
      [Description("Issue 14, Potentially invalid sender address when fetching from external account")]
      public void TestFetchMessageWithValidFromAddress()
      {

         string message = string.Format("From: A@example.com\r\n" +
                                        "To: someone@example.com\r\n" +
                                        "Subject: Test\r\n" +
                                        "\r\n" +
                                        "Hello!");

         var messages = new List<string>() { message };


         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.SendBufferMode = Pop3ServerSimulator.BufferMode.SingleBuffer;
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            LockHelper.WaitForUnlock(fa);

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);

            var log = LogHandler.ReadCurrentDefaultLog();
            Assert.IsTrue(log.Contains("Delivering message from A@example.com to user@test.com."));
         }
      }

      [Test]
      [Description("Issue 14, Potentially invalid sender address when fetching from external account")]
      public void TestFetchMessageWithInvalidFromAddress()
      {

         string message = string.Format("From: A\r\n" +
                                        "To: someone@example.com\r\n" +
                                        "Subject: Test\r\n" +
                                        "\r\n" +
                                        "Hello!");

         var messages = new List<string>() { message };


         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.SendBufferMode = Pop3ServerSimulator.BufferMode.SingleBuffer;
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            LockHelper.WaitForUnlock(fa);

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);

            var log = LogHandler.ReadCurrentDefaultLog();
            Assert.IsTrue(log.Contains("Delivering message from <Empty> to user@test.com."));
         }
      }

      // RvdH
      [Test]
      public void TestSpamProtectionPreTransmissionPTRFail()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         _application.Settings.AntiSpam.CheckPTR = true;
         _application.Settings.AntiSpam.CheckPTRScore = 105;

         var messages = new List<string>();

         string message = "Received: from static.vnpt.vn (static.vnpt.vn [14.247.252.17]) by mail.host.edu\r\n" +
                          "From: something@static.vnpt.vn\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should be blocked.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = 0;
            fa.UseAntiSpam = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            _application.Settings.AntiSpam.CheckPTR = false;

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 0);
         }
      }

      // RvdH
      [Test]
      public void TestSpamProtectionPreTransmissionPTRPass()
      {
         _application.Settings.AntiSpam.SpamMarkThreshold = 1;
         _application.Settings.AntiSpam.SpamDeleteThreshold = 100;
         _application.Settings.AntiSpam.AddHeaderReason = true;
         _application.Settings.AntiSpam.AddHeaderSpam = true;
         _application.Settings.AntiSpam.PrependSubject = true;
         _application.Settings.AntiSpam.PrependSubjectText = "ThisIsSpam";

         _application.Settings.AntiSpam.CheckPTR = true;
         _application.Settings.AntiSpam.CheckPTRScore = 105;

         var messages = new List<string>();

         string message = "Received: from mail-ed1-x533.google.com (mail-ed1-x533.google.com [2a00:1450:4864:20::533]) by mail.host.edu\r\n" +
                          "From: something@gmail.com\r\n" +
                          "To: Martin@example.com\r\n" +
                          "Subject: Test\r\n" +
                          "\r\n" +
                          "Should not be blocked.";

         messages.Add(message);

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");
            FetchAccount fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "Test";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.MIMERecipientHeaders = "To,CC,X-RCPT-TO,X-Envelope-To";
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = 0;
            fa.UseAntiSpam = true;
            fa.Save();

            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            fa.Delete();

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 1);
         }
      }
   }
}