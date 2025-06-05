﻿// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace StressTest
{
   public static class Shared
   {
      public static long AssertLowMemoryUsage(long max)
      {
         System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("hMailServer");
         if (process.Length != 1)
            throw new Exception("AltimailServer.exe not running");

         long l = process[0].PrivateMemorySize64 / 1024 / 1024;

         Assert.Less(l, max);

         return process[0].PrivateMemorySize64;
      }

      public static int GetCurrentMemoryUsage()
      {
         System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("hMailServer");
         if (process.Length != 1)
            throw new Exception("AltimailServer.exe not running");

         return Convert.ToInt32((process[0].PrivateMemorySize64 / 1024 / 1024));
      }

      public static string GetExecutableName()
      {
         System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("hMailServer");
         if (process.Length != 1)
            throw new Exception("AltimailServer.exe not running");

         return process[0].MainModule.FileName;
         
      }
   }
}
