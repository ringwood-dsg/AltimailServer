﻿using System;
using System.Diagnostics;

namespace RegressionTests.Shared
{
   /// <summary>
   /// Detects if the hMailServer service has been restarted.
   /// This is often an indication of a bug.
   /// </summary>
   public class ServiceRestartDetector
   {
      public static int? ExpectedProcessId;
      private static readonly object LockObj = new object();

      public static void ValidateProcessId()
      {
         lock (LockObj)
         {
            var matchingProcesses = Process.GetProcessesByName("hmailserver");
            if (matchingProcesses.Length > 1)
               throw new Exception("Multiple AltimailServer.exe processes are running");
            if (matchingProcesses.Length == 0)
               throw new Exception("No AltimailServer.exe processes are running");

            var currentProcessId = matchingProcesses[0].Id;

            if (ExpectedProcessId.HasValue)
            {
               // Validate that it has not changed
               if (currentProcessId != ExpectedProcessId.Value)
               {
                  throw new Exception(string.Format("AltimailServer.exe has restarted. Old process id: {0}, New process id: {1}", ExpectedProcessId.Value, currentProcessId));
               }
            }
            else
            {
               ExpectedProcessId = currentProcessId;
            }

         }
      }
   }
}
