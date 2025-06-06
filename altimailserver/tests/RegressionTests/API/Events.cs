﻿// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer;
using NUnit.Framework;
using RegressionTests.Infrastructure;
using RegressionTests.Shared;
using System;
using System.Collections.Generic;
using System.IO;

namespace RegressionTests.API
{
   [TestFixture]
   public class Events : TestFixtureBase
   {
      //RvdH
      [Test]
      public void OnClientHELOTestClientPropertiesVBScript()
      {
         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         // set ssl & tls ports
         RegressionTests.SSL.SslSetup.SetupSSLPorts(app);

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnHELO(oClient) " + Environment.NewLine +
                         " EventLog.Write(\"Port: \" & oClient.Port) " + Environment.NewLine +
                         " EventLog.Write(\"Address: \" & oClient.IPAddress) " + Environment.NewLine +
                         " EventLog.Write(\"Username: \" & oClient.Username) " + Environment.NewLine +
                         " EventLog.Write(\"SessionId: \" & oClient.SessionID) " + Environment.NewLine +
                         " EventLog.Write(\"Authenticated: \" & oClient.Authenticated) " + Environment.NewLine +
                         " EventLog.Write(\"Encrypted: \" & oClient.EncryptedConnection) " + Environment.NewLine +
                         "If (oClient.EncryptedConnection) Then " + Environment.NewLine +
                         " EventLog.Write(\"CipherVersion: \" & oClient.CipherVersion) " + Environment.NewLine +
                         " EventLog.Write(\"CipherName: \" & oClient.CipherName) " + Environment.NewLine +
                         " EventLog.Write(\"CipherBits: \" & oClient.CipherBits) " + Environment.NewLine +
                         "End If " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         var smtpClientSimulator = new TcpConnection();
         smtpClientSimulator.Connect(25003);
         var banner = smtpClientSimulator.Receive();
         var capabilities1 = smtpClientSimulator.SendAndReceive("EHLO example.com\r\n");
         Assert.IsTrue(capabilities1.Contains("STARTTLS"));

         smtpClientSimulator.SendAndReceive("STARTTLS\r\n");
         smtpClientSimulator.HandshakeAsClient();

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("Port: 25003"));
         Assert.IsTrue(message.Contains("Address: 127"));
         Assert.IsTrue(message.Contains("Username: \"")); // Should be empty, Username isn't available at this time.
         Assert.IsFalse(message.Contains("Authenticated: True"));
         Assert.IsFalse(message.Contains("Encrypted: True"));
         Assert.IsFalse(message.Contains("CipherVersion: TLSv1"));
         StringAssert.DoesNotMatch(".*\"CipherName: [\\w\\-]+\"", message);
         StringAssert.DoesNotMatch(".*\"CipherBits: \\d+\"", message);

         // Delete the log after swithing to StartTLS
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         var capabilities2 = smtpClientSimulator.SendAndReceive("EHLO example.com\r\n");
         Assert.IsFalse(capabilities2.Contains("STARTTLS"));

         smtpClientSimulator.SendAndReceive("QUIT\r\n");

         // Check that the message exists
         message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("Port: 25003"));
         Assert.IsTrue(message.Contains("Address: 127"));
         Assert.IsTrue(message.Contains("Username: \"")); // Should be empty, Username isn't available at this time.
         Assert.IsTrue(message.Contains("Authenticated: False"));
         Assert.IsTrue(message.Contains("Encrypted: True"));
         Assert.IsTrue(message.Contains("CipherVersion: TLSv1"));
         StringAssert.IsMatch(".*\"CipherName: [\\w\\-]+\"", message);
         StringAssert.IsMatch(".*\"CipherBits: \\d+\"", message);

         // reset ports
         var settings = app.Settings;
         var ports = settings.TCPIPPorts;
         ports.SetDefault();
         app.Stop();
         app.Start();
      }

      //RvdH
      [Test]
      public void OnClientHELOTestClientPropertiesJScript()
      {
         _settings.Scripting.Language = "JScript";

         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         // set ssl & tls ports
         RegressionTests.SSL.SslSetup.SetupSSLPorts(app);

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         Scripting scripting = app.Settings.Scripting;

         string script = "function OnHELO(oClient) {" + Environment.NewLine +
                         " EventLog.Write('Port: ' + oClient.Port); " + Environment.NewLine +
                         " EventLog.Write('Address: ' + oClient.IPAddress); " + Environment.NewLine +
                         " EventLog.Write('Username: ' + oClient.Username); " + Environment.NewLine +
                         " EventLog.Write('SessionId: ' + oClient.SessionID); " + Environment.NewLine +
                         " EventLog.Write('Authenticated: ' + oClient.Authenticated); " + Environment.NewLine +
                         " EventLog.Write('Encrypted: ' + oClient.EncryptedConnection); " + Environment.NewLine +
                         " if (oClient.EncryptedConnection) { " + Environment.NewLine +
                         " EventLog.Write('CipherVersion: ' + oClient.CipherVersion); " + Environment.NewLine +
                         " EventLog.Write('CipherName: ' + oClient.CipherName); " + Environment.NewLine +
                         " EventLog.Write('CipherBits: ' + oClient.CipherBits); " + Environment.NewLine +
                         " }" + Environment.NewLine +
                         "}" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         var smtpClientSimulator = new TcpConnection();
         smtpClientSimulator.Connect(25003);
         var banner = smtpClientSimulator.Receive();
         var capabilities1 = smtpClientSimulator.SendAndReceive("EHLO example.com\r\n");
         Assert.IsTrue(capabilities1.Contains("STARTTLS"));

         smtpClientSimulator.SendAndReceive("STARTTLS\r\n");
         smtpClientSimulator.HandshakeAsClient();

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("Port: 25003"));
         Assert.IsTrue(message.Contains("Address: 127"));
         Assert.IsTrue(message.Contains("Username: \"")); // Should be empty, Username isn't available at this time.
         Assert.IsFalse(message.Contains("Authenticated: true"));
         Assert.IsFalse(message.Contains("Encrypted: true"));
         Assert.IsFalse(message.Contains("CipherVersion: TLSv1"));
         StringAssert.DoesNotMatch(".*\"CipherName: [\\w\\-]+\"", message);
         StringAssert.DoesNotMatch(".*\"CipherBits: \\d+\"", message);

         // Delete the log after swithing to StartTLS
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         var capabilities2 = smtpClientSimulator.SendAndReceive("EHLO example.com\r\n");
         Assert.IsFalse(capabilities2.Contains("STARTTLS"));

         smtpClientSimulator.SendAndReceive("QUIT\r\n");

         // Check that the message exists
         message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("Port: 25003"));
         Assert.IsTrue(message.Contains("Address: 127"));
         Assert.IsTrue(message.Contains("Username: \"")); // Should be empty, Username isn't available at this time.
         Assert.IsTrue(message.Contains("Authenticated: false"));
         Assert.IsTrue(message.Contains("Encrypted: true"));
         Assert.IsTrue(message.Contains("CipherVersion: TLSv1"));
         StringAssert.IsMatch(".*\"CipherName: [\\w\\-]+\"", message);
         StringAssert.IsMatch(".*\"CipherBits: \\d+\"", message);

         // reset ports
         var settings = app.Settings;
         var ports = settings.TCPIPPorts;
         ports.SetDefault();
         app.Stop();
         app.Start();
      }

      //RvdH
      [Test]
      public void TestOnHeloRejectVBScript()
      {
         string eventLogFile = _settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // First set up a script
         string script =
            @"Sub OnHELO(oClient)
               EventLog.Write(oClient.HELO)
               If (oClient.HELO = ""ylmf-pc"") Then
                  Result.Value = 1
               End If
            End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         Settings settings = _settings;
         settings.DisconnectInvalidClients = true;
         settings.MaxNumberOfInvalidCommands = 3;

         var sim = new TcpConnection();
         sim.Connect(25);
         sim.Receive(); // banner

         sim.SendAndReceive("HELO ylmf-pc\r\n");
         sim.SendAndReceive("HELO ylmf-pc\r\n");
         sim.SendAndReceive("HELO ylmf-pc\r\n");
         var result = sim.SendAndReceive("HELO ylmf-pc\r\n");

         Assert.IsTrue(result.Contains("Too many invalid commands"), result);
      }

      //RvdH
      [Test]
      public void TestOnHeloRejectJScript()
      {
         _settings.Scripting.Language = "JScript";

         string eventLogFile = _settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // First set up a script
         string script =
            @"function OnHELO(oClient) {
               EventLog.Write(oClient.HELO);
               if (oClient.HELO === 'ylmf-pc') {
                  Result.Value = 1;
               }
            }";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         Settings settings = _settings;
         settings.DisconnectInvalidClients = true;
         settings.MaxNumberOfInvalidCommands = 3;

         var sim = new TcpConnection();
         sim.Connect(25);
         sim.Receive(); // banner

         sim.SendAndReceive("HELO ylmf-pc\r\n");
         sim.SendAndReceive("HELO ylmf-pc\r\n");
         sim.SendAndReceive("HELO ylmf-pc\r\n");
         var result = sim.SendAndReceive("HELO ylmf-pc\r\n");

         Assert.IsTrue(result.Contains("Too many invalid commands"), result);
      }

      [Test]
      public void TestOnAcceptMessageJScript()
      {
         _settings.Scripting.Language = "JScript";
         // First set up a script
         string script =
            @"function OnAcceptMessage(oClient, message)
                           {
                              message.HeaderValue('X-SpamResult') = 'TEST';
                              message.Save();
                           }";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         // Add an account and send a message to it.
         Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");

         SmtpClientSimulator.StaticSend(account1.Address, account1.Address, "Test", "SampleBody");

         // Check that the message exists
         string message = Pop3ClientSimulator.AssertGetFirstMessageText(account1.Address, "test");
         Assert.IsNotEmpty(message);

         Assert.Less(0, message.IndexOf("X-SpamResult: TEST"));
      }

      [Test]
      public void TestOnAcceptMessageVBScript()
      {
         string eventLogFile = _settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // First set up a script
         string script =
            @"Sub OnAcceptMessage(oClient, message)
                               message.HeaderValue(""X-SpamResult"") = ""TEST""
                               message.Save()
                               EventLog.Write(""Port: "" & oClient.Port)
                               EventLog.Write(""Address: "" & oClient.IPAddress)
                               EventLog.Write(""Username: "" & oClient.Username)
                               EventLog.Write(""SessionId: "" & oClient.SessionID)
                              End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         // Add an account and send a message to it.
         Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");

         SmtpClientSimulator.StaticSend(account1.Address, account1.Address, "Test", "SampleBody");

         // Check that the message exists
         string message = Pop3ClientSimulator.AssertGetFirstMessageText(account1.Address, "test");
         Assert.IsNotEmpty(message);

         Assert.Less(0, message.IndexOf("X-SpamResult: TEST"));


         // Check that the message exists
         message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("Port: 25"));
         Assert.IsTrue(message.Contains("Address: 127"));
         Assert.IsTrue(message.Contains("Username: \"")); // Should be empty, Username isn't available at this time.
         StringAssert.IsMatch(".*\"SessionId: \\d+\"", message);

      }

      // RvdH
      [Test]
      public void TestOnRecipientUnknownVBScript()
      {
         string eventLogFile = _settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // First set up a script
         string script =
            @"Sub OnRecipientUnknown(oClient, oMessage)
                               EventLog.Write(""OnRecipientUnknown "")
                              End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         // Add an account and send a message to it.
         Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");

         try
         {
            SmtpClientSimulator.StaticSend(account1.Address, "nonexistent@test.com", "Test", "SampleBody");
         }
         catch (DeliveryFailedException)
         {
            // Expected, since recipient does not exist.
         }

         // Check that the event was triggered
         var message = TestSetup.ReadExistingTextFile(eventLogFile);
         Assert.IsTrue(message.Contains("OnRecipientUnknown"));
      }

      //RvdH
      [Test]
      public void TestOnRecipientUnknownJScript()
      {
         _settings.Scripting.Language = "JScript";

         string eventLogFile = _settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // First set up a script
         string script =
            @"function OnRecipientUnknown(oClient, oMessage) {
               EventLog.Write(""OnRecipientUnknown"");
            }";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         // Add an account and send a message to it.
         Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");

         try
         {
            SmtpClientSimulator.StaticSend(account1.Address, "nonexistent@test.com", "Test", "SampleBody");
         }
         catch (DeliveryFailedException)
         {
            // Expected, since recipient does not exist.
         }

         // Check that the event was triggered
         var message = TestSetup.ReadExistingTextFile(eventLogFile);
         Assert.IsTrue(message.Contains("OnRecipientUnknown"));
      }

      // RvdH
      [Test]
      public void TestOnTooManyInvalidCommandsVBScript()
      {
         int maxInvalid = 5;

         _settings.MaxNumberOfInvalidCommands = maxInvalid;
         _settings.DisconnectInvalidClients = true;

         string eventLogFile = _settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // First set up a script
         string script =
            @"Sub OnTooManyInvalidCommands(oClient, oMessage)
                               EventLog.Write(""OnTooManyInvalidCommands "")
                              End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         var client = new SmtpClientSimulator();
         client.Connect();
         client.Receive(); // Welcome banner
         var ehloResponse = client.SendAndReceive("EHLO example.com\r\n");

         for (int i = 0; i < maxInvalid + 1; i++)
         {
            client.SendAndReceive("MAIL FROM\r\n");
         }

         // restore
         _settings.MaxNumberOfInvalidCommands = 3;
         _settings.DisconnectInvalidClients = false;

         // Check that the event was triggered
         var message = TestSetup.ReadExistingTextFile(eventLogFile);
         Assert.IsTrue(message.Contains("OnTooManyInvalidCommands"));
      }

      //RvdH
      [Test]
      public void TestOnTooManyInvalidCommandsJScript()
      {
         _settings.Scripting.Language = "JScript";

         int maxInvalid = 5;

         _settings.MaxNumberOfInvalidCommands = maxInvalid;
         _settings.DisconnectInvalidClients = true;

         string eventLogFile = _settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // First set up a script
         string script =
            @"function OnTooManyInvalidCommands(oClient, oMessage) {
               EventLog.Write('OnTooManyInvalidCommands');
            }";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         var oSimulator = new TcpConnection();
         oSimulator.Connect(25);
         oSimulator.Receive(); // Welcome banner
         var ehloResponse = oSimulator.SendAndReceive("EHLO example.com\r\n");

         for (int i = 0; i < maxInvalid + 1; i++)
         {
            oSimulator.SendAndReceive("MAIL FROM\r\n");
         }

         // Check that the event was triggered
         var message = TestSetup.ReadExistingTextFile(eventLogFile);
         Assert.IsTrue(message.Contains("OnTooManyInvalidCommands"));
      }

      [Test]
      public void TestOnBackupCompletedJScript()
      {
         Scripting scripting = _settings.Scripting;
         scripting.Language = "JScript";

         // First set up a script
         string script =
            @"function OnBackupCompleted()
                           {
                               EventLog.Write('Backup process completed')
                           }";


         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         var back = new BackupRestore();
         back.InitializeBackupSettings();
         back.TestWithMessages();


         string eventLogText = TestSetup.ReadExistingTextFile(LogHandler.GetEventLogFileName());
         Assert.IsTrue(eventLogText.Contains("Backup process completed"));
      }

      [Test]
      public void TestOnBackupCompletedVBScript()
      {
         // First set up a script
         string script =
            @"Sub OnBackupCompleted()
                               EventLog.Write(""Backup process completed"")
                           End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         var back = new BackupRestore();
         back.InitializeBackupSettings();
         back.TestWithMessages();


         string eventLogText = TestSetup.ReadExistingTextFile(LogHandler.GetEventLogFileName());
         Assert.IsTrue(eventLogText.Contains("Backup process completed"));
      }

      [Test]
      public void TestOnBackupFailedJScript()
      {
         Scripting scripting = _settings.Scripting;
         scripting.Language = "JScript";

         // First set up a script
         string script =
            @"function OnBackupFailed(reason)     
                           {
                               EventLog.Write('Failed: ' + reason)
                           }";


         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         var back = new BackupRestore();
         back.InitializeBackupSettings();
         back.SetBackupDir(@"C:\some-non-existant-directory");
         Assert.IsFalse(back.Execute());

         CustomAsserts.AssertReportedError("BACKUP ERROR: The specified backup directory is not accessible:");
         string eventLogText = TestSetup.ReadExistingTextFile(LogHandler.GetEventLogFileName());
         Assert.IsTrue(eventLogText.Contains("The specified backup directory is not accessible"));
      }

      [Test]
      public void TestOnBackupFailedVBScript()
      {
         // First set up a script
         string script =
            @"Sub OnBackupFailed(reason)
                               EventLog.Write(""Failed: "" & reason)
                           End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         var back = new BackupRestore();
         back.InitializeBackupSettings();
         back.SetBackupDir(@"C:\some-non-existant-directory");
         Assert.IsFalse(back.Execute());

         CustomAsserts.AssertReportedError("BACKUP ERROR: The specified backup directory is not accessible:");
         string eventLogText = TestSetup.ReadExistingTextFile(LogHandler.GetEventLogFileName());
         Assert.IsTrue(eventLogText.Contains("The specified backup directory is not accessible"));
      }

      [Test]
      public void TestOnClientConnectJScript()
      {
         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         scripting.Language = "JScript";

         string script = "function OnClientConnect(oClient) " + Environment.NewLine +
                         "{" + Environment.NewLine +
                         " EventLog.Write('Port: ' + oClient.Port); " + Environment.NewLine +
                         " EventLog.Write('Address: ' + oClient.IPAddress); " + Environment.NewLine +
                         " EventLog.Write('Username: ' + oClient.Username); " + Environment.NewLine +
                         "}" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         var socket = new TcpConnection();
         Assert.IsTrue(socket.IsPortOpen(25));

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("Port: 25"));
         Assert.IsTrue(message.Contains("Address: 127"));
         Assert.IsTrue(message.Contains("Username: \"")); // Should be empty, Username isn't available at this time.
      }

      [Test]
      public void TestOnClientConnectVBScript()
      {
         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnClientConnect(oClient) " + Environment.NewLine +
                         " EventLog.Write(\"Port: \" & oClient.Port) " + Environment.NewLine +
                         " EventLog.Write(\"Address: \" & oClient.IPAddress) " + Environment.NewLine +
                         " EventLog.Write(\"Username: \" & oClient.Username) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         var socket = new TcpConnection();
         Assert.IsTrue(socket.IsPortOpen(25));

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("Port: 25"));
         Assert.IsTrue(message.Contains("Address: 127"));
         Assert.IsTrue(message.Contains("Username: \"")); // Should be empty, Username isn't available at this time.
      }

      [Test]
      public void TestOnDeliverMessageJScript()
      {
         Scripting scripting = _settings.Scripting;
         scripting.Language = "JScript";
         // First set up a script
         string script =
            @"function OnDeliverMessage(message)
                           {
                               message.HeaderValue('X-SpamResult') = 'TEST2';
                               message.Save();
                           }";


         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         // Add an account and send a message to it.
         Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");

         SmtpClientSimulator.StaticSend(account1.Address, account1.Address, "Test", "SampleBody");

         // Check that the message exists
         string message = Pop3ClientSimulator.AssertGetFirstMessageText(account1.Address, "test");
         Assert.IsNotEmpty(message);

         Assert.Less(0, message.IndexOf("X-SpamResult: TEST2"));
      }

      [Test]
      public void TestOnDeliveryFailedJScript()
      {
         Scripting scripting = _settings.Scripting;
         scripting.Language = "JScript";

         // First set up a script
         string script = "function OnDeliveryFailed(message, sRecipient, sErrorMessage) {" + Environment.NewLine +
                         " EventLog.Write('File: ' + message.FileName); " + Environment.NewLine +
                         " EventLog.Write('Recipient: ' + sRecipient); " + Environment.NewLine +
                         " EventLog.Write('Error: ' + sErrorMessage); " + Environment.NewLine +
                         "}";


         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         // Add an account and send a message to it.
         Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");
         SmtpClientSimulator.StaticSend(account1.Address, "user@dummy.example.com", "Test", "SampleBody");

         // Make sure that the message is deliverd and bounced.
         CustomAsserts.AssertRecipientsInDeliveryQueue(0);

         string eventLogText = TestSetup.ReadExistingTextFile(LogHandler.GetEventLogFileName());
         Assert.IsTrue(eventLogText.Contains("File: "), eventLogText);
         Assert.IsTrue(eventLogText.Contains("Recipient: user@dummy.example.com"), eventLogText);
         Assert.IsTrue(eventLogText.Contains("No mail servers appear to exists"), eventLogText);
      }

      [Test]
      public void TestOnDeliveryFailedVBScript()
      {
         // First set up a script
         string script = "Sub OnDeliveryFailed(message, sRecipient, sErrorMessage)" + Environment.NewLine +
                         " EventLog.Write(\"File: \" & message.FileName) " + Environment.NewLine +
                         " EventLog.Write(\"Recipient: \" & sRecipient) " + Environment.NewLine +
                         " EventLog.Write(\"Error: \" & sErrorMessage) " + Environment.NewLine +
                         " End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         // Add an account and send a message to it.
         Account account1 = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");
         SmtpClientSimulator.StaticSend(account1.Address, "user@dummy.example.com", "Test", "SampleBody");

         // Make sure that the message is deliverd and bounced.
         CustomAsserts.AssertRecipientsInDeliveryQueue(0);

         string eventLogText = TestSetup.ReadExistingTextFile(LogHandler.GetEventLogFileName());
         Assert.IsTrue(eventLogText.Contains("File: "));
         Assert.IsTrue(eventLogText.Contains("Recipient: user@dummy.example.com"));
         Assert.IsTrue(eventLogText.Contains("No mail servers appear to exists"));
      }

      [Test]
      public void TestOnDeliveryStartVBScript()
      {
         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnDeliveryStart(message) " + Environment.NewLine +
                         " EventLog.Write(\"Delivering message: \" & message.FileName) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");
         SmtpClientSimulator.StaticSend(account.Address, account.Address, "Test", "SampleBody");

         // Wait for the message to be delivered.
         Pop3ClientSimulator.AssertGetFirstMessageText(account.Address, "test");

         string eventLogText = TestSetup.ReadExistingTextFile(app.Settings.Logging.CurrentEventLog);
         Assert.IsTrue(eventLogText.Contains("Delivering message"));
      }

      [Test]
      public void TestOnErrorJScript()
      {
         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;
         scripting.Language = "JScript";
         string script = "function OnError(iSeverity, iError, sSource, sDescription) {" + Environment.NewLine +
                         " EventLog.Write('Severity: ' + iSeverity) " + Environment.NewLine +
                         " EventLog.Write('Error: ' + iError) " + Environment.NewLine +
                         " EventLog.Write('Source: ' + sSource) " + Environment.NewLine +
                         " EventLog.Write('Description: ' + sDescription) " + Environment.NewLine +
                         "}" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");
         IMAPFolder inbox = account.IMAPFolders.get_ItemByName("Inbox");


         string deletedMessageText = app.Settings.ServerMessages.get_ItemByName("MESSAGE_FILE_MISSING").Text;
         SmtpClientSimulator.StaticSend(account.Address, account.Address, "Test", "SampleBody");

         CustomAsserts.AssertFolderMessageCount(inbox, 1);
         AltimailServer.Message message = inbox.Messages[0];
         File.Delete(message.Filename);
         string text = Pop3ClientSimulator.AssertGetFirstMessageText(account.Address, "test");
         Assert.IsTrue(text.Contains(deletedMessageText.Replace("%MACRO_FILE%", message.Filename)));
         CustomAsserts.AssertReportedError("Message retrieval failed because message file");

         string eventLogText = TestSetup.ReadExistingTextFile(app.Settings.Logging.CurrentEventLog);
         Assert.IsTrue(eventLogText.Contains("Description: Message retrieval failed"));
      }

      [Test]
      public void TestOnErrorVBScript()
      {
         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnError(iSeverity, iError, sSource, sDescription) " + Environment.NewLine +
                         " EventLog.Write(\"Severity: \" & iSeverity) " + Environment.NewLine +
                         " EventLog.Write(\"Error: \" & iError) " + Environment.NewLine +
                         " EventLog.Write(\"Source: \" & sSource) " + Environment.NewLine +
                         " EventLog.Write(\"Description: \" & sDescription) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");
         IMAPFolder inbox = account.IMAPFolders.get_ItemByName("Inbox");


         string deletedMessageText = app.Settings.ServerMessages.get_ItemByName("MESSAGE_FILE_MISSING").Text;
         SmtpClientSimulator.StaticSend(account.Address, account.Address, "Test", "SampleBody");

         CustomAsserts.AssertFolderMessageCount(inbox, 1);
         AltimailServer.Message message = inbox.Messages[0];
         File.Delete(message.Filename);
         string text = Pop3ClientSimulator.AssertGetFirstMessageText(account.Address, "test");
         Assert.IsTrue(text.Contains(deletedMessageText.Replace("%MACRO_FILE%", message.Filename)));
         CustomAsserts.AssertReportedError("Message retrieval failed because message file");

         string eventLogText = TestSetup.ReadExistingTextFile(app.Settings.Logging.CurrentEventLog);
         Assert.IsTrue(eventLogText.Contains("Description: Message retrieval failed"));
      }

      [Test]
      public void TestOnExternalAccountDownload()
      {
         LogHandler.DeleteCurrentDefaultLog();


         var messages = new List<string>();

         messages.Add("From: Martin@example1.com\r\n" +
                      "To: Martin@example.com\r\n" +
                      "Subject: Message 1\r\n" +
                      "\r\n" +
                      "Message 1!");

         messages.Add("From: Martin@example2.com\r\n" +
                      "To: Martin@example.com\r\n" +
                      "Subject: Message 2\r\n" +
                      "\r\n" +
                      "Message 2!");

         messages.Add("From: Martin@example3.com\r\n" +
                      "To: Martin@example.com\r\n" +
                      "Subject: Message 3\r\n" +
                      "\r\n" +
                      "Message 3!");


         // The second message should be deleted after 5 days.
         string script = "Sub OnExternalAccountDownload(oFetchAccount, message, sRemoteUID)" + Environment.NewLine +
                         " EventLog.Write(\"UID: \" & sRemoteUID) " + Environment.NewLine +
                         " EventLog.Write(\"FetchAccount: \" & oFetchAccount.Name) " + Environment.NewLine +
                         " If Not message Is Nothing Then " + Environment.NewLine +
                         "   EventLog.Write(\"From: \" & message.FromAddress) " + Environment.NewLine +
                         "   EventLog.Write(\"Filename: \" & message.FileName) " + Environment.NewLine +
                         " Else " + Environment.NewLine +
                         "   EventLog.Write(\"Message details missing\") " + Environment.NewLine +
                         " End If" + Environment.NewLine +
                         " if sRemoteUID = \"UniqueID-" + messages[1].GetHashCode() + "\" Then " +
                         Environment.NewLine +
                         "   Result.Value = 2  " + Environment.NewLine +
                         "   Result.Parameter = 5  " + Environment.NewLine +
                         " End If " + Environment.NewLine +
                         " End Sub";

         Scripting scripting = _settings.Scripting;
         string file = scripting.CurrentScriptFile;
         File.WriteAllText(file, script);
         scripting.Enabled = true;
         scripting.Reload();

         Account account = SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "user@test.com", "test");

         FetchAccount fa;

         int port = TestSetup.GetNextFreePort();
         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();


            fa = account.FetchAccounts.Add();

            fa.Enabled = true;
            fa.MinutesBetweenFetch = 10;
            fa.Name = "TestFA";
            fa.Username = "test@example.com";
            fa.Password = "test";
            fa.UseSSL = false;
            fa.ServerAddress = "localhost";
            fa.Port = port;
            fa.ProcessMIMERecipients = false;
            fa.DaysToKeepMessages = -1;
            fa.Save();
            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            string eventLogFile = _settings.Logging.CurrentEventLog;
            string logContents = TestSetup.ReadExistingTextFile(eventLogFile);

            Assert.IsTrue(logContents.Contains("FetchAccount: " + fa.Name));

            Assert.IsTrue(logContents.Contains("From: Martin@example1.com"));
            Assert.IsTrue(logContents.Contains("From: Martin@example2.com"));
            Assert.IsTrue(logContents.Contains("From: Martin@example3.com"));

            string appLogContent = LogHandler.ReadCurrentDefaultLog();

            Assert.IsTrue(pop3Server.DeletedMessages.Contains(1));
            Assert.IsFalse(pop3Server.DeletedMessages.Contains(2));
            Assert.IsTrue(pop3Server.DeletedMessages.Contains(3));

            Assert.IsTrue(pop3Server.RetrievedMessages.Contains(1));
            Assert.IsTrue(pop3Server.RetrievedMessages.Contains(2));
            Assert.IsTrue(pop3Server.RetrievedMessages.Contains(3));

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 3);


         }

         using (var pop3Server = new Pop3ServerSimulator(1, port, messages))
         {
            pop3Server.StartListen();

            // Download again...
            fa.DownloadNow();

            pop3Server.WaitForCompletion();

            // Make sure that no messages are deleted.
            Assert.AreEqual(0, pop3Server.DeletedMessages.Count);
            Assert.AreEqual(0, pop3Server.RetrievedMessages.Count);

            Pop3ClientSimulator.AssertMessageCount(account.Address, "test", 3);
         }
      }

      [Test]
      public void TestOnClientLogon_POP3()
      {
         var domain = SingletonProvider<TestSetup>.Instance.AddTestDomain();
         SingletonProvider<TestSetup>.Instance.AddAccount(domain, "test@test.com", "test");

         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnClientLogon(oClient) " + Environment.NewLine +
                         " EventLog.Write(\"OnClientLogin-POP3\")" + Environment.NewLine +
                         " EventLog.Write(\"IsAuthenticated: \" & oClient.Authenticated) " + Environment.NewLine +
                         " EventLog.Write(\"Username: \" & oClient.Username) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // Log on once to trigger event.
         Pop3ClientSimulator.AssertMessageCount("test@test.com", "test", 0);

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("OnClientLogin-POP3"));
         Assert.IsTrue(message.Contains("IsAuthenticated: True"));
         Assert.IsTrue(message.Contains("Username: test@test.com")); // Should be empty, Username isn't available at this time.
      }

      [Test]
      public void TestOnClientLogon_IMAP()
      {
         var domain = SingletonProvider<TestSetup>.Instance.AddTestDomain();
         SingletonProvider<TestSetup>.Instance.AddAccount(domain, "test@test.com", "test");

         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnClientLogon(oClient) " + Environment.NewLine +
                         " EventLog.Write(\"OnClientLogin-IMAP\")" + Environment.NewLine +
                         " EventLog.Write(\"IsAuthenticated: \" & oClient.Authenticated) " + Environment.NewLine +
                         " EventLog.Write(\"Username: \" & oClient.Username) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // Log on once to trigger event.
         ImapClientSimulator.AssertMessageCount("test@test.com", "test", "Inbox", 0);

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("OnClientLogin-IMAP"));
         Assert.IsTrue(message.Contains("IsAuthenticated: True"));
         Assert.IsTrue(message.Contains("Username: test@test.com")); // Should be empty, Username isn't available at this time.
      }

      [Test]
      public void TestOnClientLogon_SMTP()
      {
         var domain = SingletonProvider<TestSetup>.Instance.AddTestDomain();
         SingletonProvider<TestSetup>.Instance.AddAccount(domain, "test@test.com", "test");

         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnClientLogon(oClient) " + Environment.NewLine +
                         " EventLog.Write(\"OnClientLogin-SMTP\")" + Environment.NewLine +
                         " EventLog.Write(\"IsAuthenticated: \" & oClient.Authenticated) " + Environment.NewLine +
                         " EventLog.Write(\"Username: \" & oClient.Username) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // Log on once to trigger event.

         string base64Username = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("test@test.com"));
         string base64Password = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("test"));

         var clientSimulator = new SmtpClientSimulator();
         string errMsg;
         clientSimulator.ConnectAndLogon(base64Username, base64Password, out errMsg);

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("OnClientLogin-SMTP"));
         Assert.IsTrue(message.Contains("IsAuthenticated: True"));
         Assert.IsTrue(message.Contains("Username: test@test.com")); // Should be empty, Username isn't available at this time.
      }

      [Test]
      public void TestOnHelo_WithHelo()
      {
         var domain = SingletonProvider<TestSetup>.Instance.AddTestDomain();
         SingletonProvider<TestSetup>.Instance.AddAccount(domain, "test@test.com", "test");

         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnHelo(oClient) " + Environment.NewLine +
                         " EventLog.Write(\"OnHelo\")" + Environment.NewLine +
                         " EventLog.Write(\"HeloHost: \" & oClient.HELO) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // Log on once to trigger event.
         var clientSimulator = new SmtpClientSimulator();
         clientSimulator.Connect();
         clientSimulator.SendAndReceive("HELO WORLD\r\n");

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("OnHelo"));
         Assert.IsTrue(message.Contains("HeloHost: WORLD"));
      }

      [Test]
      public void TestOnHelo_WithEhlo()
      {
         var domain = SingletonProvider<TestSetup>.Instance.AddTestDomain();
         SingletonProvider<TestSetup>.Instance.AddAccount(domain, "test@test.com", "test");

         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script = "Sub OnHelo(oClient) " + Environment.NewLine +
                         " EventLog.Write(\"OnHelo\")" + Environment.NewLine +
                         " EventLog.Write(\"HeloHost: \" & oClient.HELO) " + Environment.NewLine +
                         "End Sub" + Environment.NewLine + Environment.NewLine;

         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         string eventLogFile = app.Settings.Logging.CurrentEventLog;
         if (File.Exists(eventLogFile))
            File.Delete(eventLogFile);

         // Log on once to trigger event.
         var clientSimulator = new SmtpClientSimulator();
         clientSimulator.Connect();
         clientSimulator.SendAndReceive("EHLO WORLD2\r\n");

         // Check that the message exists
         string message = TestSetup.ReadExistingTextFile(eventLogFile);

         Assert.IsNotEmpty(message);
         Assert.IsTrue(message.Contains("OnHelo"));
         Assert.IsTrue(message.Contains("HeloHost: WORLD2"));
      }

      [Test]
      public void TestOnClientValidatePasswordVBScript_ValidPassword()
      {
         SingletonProvider<TestSetup>.Instance.AddAccount(_domain, "test@test.com", "test");

         // First verify log on works with proper password ("test") but fails with incorrect ("MySecretPassword")
         Assert.IsTrue(ImapClientSimulator.ValidatePassword("test@test.com", "test"));
         Assert.IsFalse(ImapClientSimulator.ValidatePassword("test@test.com", "MySecretPassword"));

         // Create a script which override password validation to allow MySecretPassword as valid password
         Application app = SingletonProvider<TestSetup>.Instance.GetApp();
         Scripting scripting = app.Settings.Scripting;

         string script =
            @"Sub OnClientValidatePassword(account, password)  
                 EventLog.Write(""Account: "" & account.Address)
                 EventLog.Write(""Password: "" & password)
                 If password = ""MySecretPassword"" Then
                   Result.Value = 0
                 Else
                   Result.Value = 1
                 End If
              End Sub";


         File.WriteAllText(scripting.CurrentScriptFile, script);

         scripting.Enabled = true;
         scripting.Reload();

         // Now verify we can log on using the new password
         Assert.IsTrue(ImapClientSimulator.ValidatePassword("test@test.com", "MySecretPassword"));
         Assert.IsFalse(ImapClientSimulator.ValidatePassword("test@test.com", "test"));

         string eventLogText = TestSetup.ReadExistingTextFile(app.Settings.Logging.CurrentEventLog);
         Assert.IsTrue(eventLogText.Contains("Account: test@test.com"));
         Assert.IsTrue(eventLogText.Contains("Password: MySecretPassword"));
      }


   }
}