﻿using NUnit.Framework;
using RegressionTests.Shared;
using System;
using System.IO;

namespace RegressionTests.Infrastructure
{
   [TestFixture]
   public class ExceptionHandlerTests : TestFixtureBase
   {
      [SetUp]
      public new void SetUp()
      {
         if (Environment.OSVersion.Version.Major == 5 &&
             Environment.OSVersion.Version.Minor == 0)
         {
            Assert.Pass("This functionality is not supported on Windows 2000.");
         }
      }

      [TearDown]
      public new void TearDown()
      {
         _settings.CrashSimulationMode = 0;
      }

      private void DeleteAllMinidumps()
      {
         var minidumps = GetMinidumps();

         foreach (var minidump in minidumps)
            File.Delete(minidump);
      }

      private string[] GetMinidumps()
      {
         var logDirectory = _settings.Directories.LogDirectory;

         var minidumps = Directory.GetFiles(logDirectory, "minidump*.dmp");
         return minidumps;
      }

      [Test]
      public void HelpShouldNotResultInErrorIfCrashSimulationDisabled()
      {
         _settings.CrashSimulationMode = 0;

         TriggerCrashSimulationError();

         AssertMinidumpsGeneratedAndErrorsLogged(0, false);
      }

      [Test]
      public void ThrowIntShouldResultInErrorDump()
      {
         _settings.CrashSimulationMode = 1;

         TriggerCrashSimulationError();

         AssertMinidumpsGeneratedAndErrorsLogged(1, true,
            "Description: An error occured while parsing data.",
            "An error occured while executing 'IOCPQueueWorkerTask'",
            "An error has been detected. A mini dump has been written");
      }


      [Test]
      public void ThrowLogicErrorShouldResultInErrorDump()
      {
         _settings.CrashSimulationMode = 2;

         TriggerCrashSimulationError();
         AssertMinidumpsGeneratedAndErrorsLogged(1, true, "Message: Crash simulation test");


      }

      [Test]
      public void AccessViolationShouldResultInErrorDump()
      {
         _settings.CrashSimulationMode = 3;

         TriggerCrashSimulationError();

         AssertMinidumpsGeneratedAndErrorsLogged(1, true,
            "An error has been detected. A mini dump has been written");
      }

      [Test]
      public void DisconnectedExceptionShouldNotExitRunningThreads()
      {
         _settings.CrashSimulationMode = 4;

         for (int i = 0; i < 20; i++)
         {
            TriggerCrashSimulationError();
         }

         AssertMinidumpsGeneratedAndErrorsLogged(0, false);

         var defaultLog = LogHandler.ReadCurrentDefaultLog();
         Assert.IsTrue(defaultLog.Contains("Connection was terminated - Client is disconnected."));
      }

      [Test]
      public void AtMost10MinidumpsAreGenerated()
      {
         _settings.CrashSimulationMode = 3;

         // 11 errors triggered, but only 10 should generate minidumps.
         for (int i = 1; i <= 11; i++)
            TriggerCrashSimulationError();

         AssertMinidumpsGeneratedAndErrorsLogged(10, false);

         // We should log info that we skipped minidump generation.
         RetryHelper.TryAction(TimeSpan.FromSeconds(5), () =>
            {
               var log = LogHandler.ReadCurrentDefaultLog();

               RetryableAssert.IsTrue(log.Contains("Minidump creation aborted. The max count (10) is reached and no log is older than 4 hours."));
            });


         // Delete one minidump, so only 9 remains.
         var minidumps = GetMinidumps();
         File.Delete(minidumps[0]);

         // Now we should be able to create another.
         TriggerCrashSimulationError();

         AssertMinidumpsGeneratedAndErrorsLogged(10, true);
      }

      [Test]
      public void MinidumpsOlderThan4HoursMayBeDeleted()
      {
         _settings.CrashSimulationMode = 3;

         // 11 errors triggered, but only 10 should generate minidumps.
         for (int i = 1; i <= 11; i++)
            TriggerCrashSimulationError();

         AssertMinidumpsGeneratedAndErrorsLogged(10, false);

         // We should log info that we skipped minidump generation.
         RetryHelper.TryAction(TimeSpan.FromSeconds(5), () =>
         {
            var log = LogHandler.ReadCurrentDefaultLog();
            RetryableAssert.IsTrue(log.Contains("Minidump creation aborted. The max count (10) is reached and no log is older than 4 hours."));
         });

         // Pretend one minidump is really old.
         var minidumps = GetMinidumps();
         var testminidump = minidumps[0];
         File.SetCreationTime(testminidump, new DateTime(2014, 01, 01));


         // Now we should be able to create another.
         TriggerCrashSimulationError();

         RetryHelper.TryAction(TimeSpan.FromSeconds(10), () =>
            {
               if (File.Exists(testminidump))
                  throw new Exception("Mini dump exists");
            });

         AssertMinidumpsGeneratedAndErrorsLogged(10, true);
      }


      private static void TriggerCrashSimulationError()
      {
         using (var tcpConnection = new TcpConnection())
         {
            tcpConnection.Connect(25);
            tcpConnection.Send("help\r\n");
            tcpConnection.Receive();
         }
      }

      private void AssertMinidumpsGeneratedAndErrorsLogged(int count, bool delete, params string[] expectedLoggedErrors)
      {
         RetryHelper.TryAction(TimeSpan.FromSeconds(10), () =>
         {
            var minidumps = GetMinidumps();
            if (count != minidumps.Length)
               throw new Exception(string.Format("Unexpected minidump count, Actual: {0}, Expected: {1}", minidumps.Length, count));

            if (count > 0 || expectedLoggedErrors.Length > 0)
            {
               string errorLog = LogHandler.ReadErrorLog();
               foreach (var minidump in minidumps)
               {
                  if (!errorLog.Contains(minidump))
                     throw new Exception(errorLog);
               }

               foreach (var expectedLoggedError in expectedLoggedErrors)
               {
                  if (!errorLog.Contains(expectedLoggedError))
                     throw new Exception(errorLog);
               }
            }

         });

         if (delete)
         {
            DeleteAllMinidumps();
            LogHandler.DeleteErrorLog();
         }
      }

   }
}
