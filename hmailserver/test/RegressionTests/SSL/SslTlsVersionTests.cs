// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using NUnit.Framework;
using RegressionTests.Infrastructure;
using RegressionTests.Shared;
using System.ComponentModel;
using System.Net;
using System.Security.Authentication;
using System.Threading;

namespace RegressionTests.SSL
{
   [TestFixture]
   public class SslTlsVersionTests : TestFixtureBase
   {
      private hMailServer.Account _account;

      private void SetSslVersions(bool tlsv10, bool tlsv11, bool tlsv12, bool tlsv13)
      {
         SslSetup.SetupSSLPorts(_application, new SslVersions()
         {
            Tls10 = tlsv10,
            Tls11 = tlsv11,
            Tls12 = tlsv12,
            Tls13 = tlsv13
         });

         Thread.Sleep(1000);
      }

      [SetUp]
      public new void SetUp()
      {
         _account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");
      }

      [Test]
      public void ItShouldBePossibleToDisableSslV3()
      {
         SetSslVersions(true, true, true, true);
         var smtpClientSimulator = new SmtpClientSimulator(true, SslProtocols.Ssl3, 25001, IPAddress.Parse("127.0.0.1"));

         try
         {
            string errorMessage;
            smtpClientSimulator.Send(false, _account.Address, "test", _account.Address, _account.Address, "Test",
               "test",
               out errorMessage);

            Assert.Fail("Was able to establish SSLv3 connection");
         }
         catch (System.Security.Authentication.AuthenticationException)
         {
            // on windows 10
         }
         catch (Win32Exception)
         {
            // on newer windows 10
         }
         catch (System.IO.IOException)
         {
            // on windows xp
         }
      }

      [Test]
      public void WhenSSL3IsDisabledTLSShouldWork()
      {
         SetSslVersions(true, true, true, true);
         //RvdH
         //var smtpClientSimulator = new SmtpClientSimulator(true, SslProtocols.Tls, 25001, IPAddress.Parse("127.0.0.1"));
         var smtpClientSimulator = new SmtpClientSimulator(true, SslProtocols.Tls12, 25001, IPAddress.Parse("127.0.0.1"));

         string errorMessage;
         smtpClientSimulator.Send(false, _account.Address, "test", _account.Address, _account.Address, "Test", "test", out errorMessage);

         var message = Pop3ClientSimulator.AssertGetFirstMessageText(_account.Address, "test");
         Assert.IsTrue(message.Contains("version=TLSv1"), message);
      }

      // RvdH
      [Test]
      public void TLS10IsDisabled()
      {
         SetSslVersions(false, true, true, true);
         var smtpClientSimulator = new SmtpClientSimulator(true, SslProtocols.Tls, 25001, IPAddress.Parse("127.0.0.1"));

         try
         {
            string errorMessage;
            smtpClientSimulator.Send(false, _account.Address, "test", _account.Address, _account.Address, "Test", "test", out errorMessage);
         }
         catch (System.Security.Authentication.AuthenticationException)
         {
            // on windows 10
         }
         catch (Win32Exception)
         {
            // on newer windows 10
         }
         catch (System.IO.IOException)
         {
            // on windows xp
         }

         string error = LogHandler.ReadCurrentDefaultLog();
         Assert.IsTrue(error.Contains("unsupported protocol"));
      }

      // RvdH
      [Test]
      public void UptoTLS11IsDisabled()
      {
         SetSslVersions(false, false, true, true);
         var smtpClientSimulator = new SmtpClientSimulator(true, SslProtocols.Tls11, 25001, IPAddress.Parse("127.0.0.1"));

         try
         {
            string errorMessage;
            smtpClientSimulator.Send(false, _account.Address, "test", _account.Address, _account.Address, "Test", "test", out errorMessage);
         }
         catch (System.Security.Authentication.AuthenticationException)
         {
            // on windows 10
         }
         catch (Win32Exception)
         {
            // on newer windows 10
         }
         catch (System.IO.IOException)
         {
            // on windows xp
         }

         string error = LogHandler.ReadCurrentDefaultLog();
         Assert.IsTrue(error.Contains("unsupported protocol"));
      }

      // RvdH
      [Test]
      public void UptoTLS12IsDisabled()
      {
         SetSslVersions(false, false, false, true);
         var smtpClientSimulator = new SmtpClientSimulator(true, SslProtocols.Tls12, 25001, IPAddress.Parse("127.0.0.1"));

         try
         {
            string errorMessage;
            smtpClientSimulator.Send(false, _account.Address, "test", _account.Address, _account.Address, "Test", "test", out errorMessage);
         }
         catch (System.Security.Authentication.AuthenticationException)
         {
            // on windows 10
         }
         catch (Win32Exception)
         {
            // on newer windows 10
         }
         catch (System.IO.IOException)
         {
            // on windows xp
         }

         string error = LogHandler.ReadCurrentDefaultLog();
         Assert.IsTrue(error.Contains("unsupported protocol"));
      }

      // RvdH
      [Test]
      public void AllTLSProtocolsDisabled()
      {
         SetSslVersions(false, false, false, false);
         var smtpClientSimulator = new SmtpClientSimulator(true, SslProtocols.Tls12, 25001, IPAddress.Parse("127.0.0.1"));

         try
         {
            string errorMessage;
            smtpClientSimulator.Send(false, _account.Address, "test", _account.Address, _account.Address, "Test", "test", out errorMessage);
         }
         catch (System.Security.Authentication.AuthenticationException)
         {
            // on windows 10
         }
         catch (Win32Exception)
         {
            // on newer windows 10
         }
         catch (System.IO.IOException)
         {
            // on windows xp
         }

         string error = LogHandler.ReadCurrentDefaultLog();
         Assert.IsTrue(error.Contains("no protocols available"));
      }
   }
}