﻿// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using hMailServer;
using NUnit.Framework;
using RegressionTests.Infrastructure;
using RegressionTests.Shared;
using System.IO;

namespace RegressionTests.SSL
{
   [TestFixture]
   public class CertificateTypes : TestFixtureBase
   {
      [Test]
      [Description("Test that loading a private key with password does not hang")]
      public void SetupSSLCertificateWithPassword()
      {
         string sslPath = Path.Combine(SslSetup.GetSslCertPath(), "WithPassword");

         SSLCertificate sslCertificate = _application.Settings.SSLCertificates.Add();
         sslCertificate.Name = "Example";
         sslCertificate.CertificateFile = sslPath + "\\server.crt";
         sslCertificate.PrivateKeyFile = sslPath + "\\server.key";
         sslCertificate.Save();

         TCPIPPort port = _application.Settings.TCPIPPorts.Add();
         port.Address = "0.0.0.0";
         port.PortNumber = 251;
         port.UseSSL = true;
         port.SSLCertificateID = sslCertificate.ID;
         port.Protocol = eSessionType.eSTSMTP;
         port.Save();

         _application.Stop();
         _application.Start();

         CustomAsserts.AssertReportedError("The private key file has a password. hMailServer does not support this.",
                                       "Failed to load private key file.");

         SingletonProvider<TestSetup>.Instance.PerformBasicSetup();
      }
   }
}