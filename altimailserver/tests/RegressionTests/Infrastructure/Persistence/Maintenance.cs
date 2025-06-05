﻿// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer;
using NUnit.Framework;
using RegressionTests.Shared;
using System.Runtime.InteropServices;

namespace RegressionTests.Infrastructure.Persistence
{
   [TestFixture]
   public class Maintenance : TestFixtureBase
   {
      [Test]
      public void TestUnknownOperation()
      {
         var ex = Assert.Throws<COMException>(() => _application.Utilities.PerformMaintenance((eMaintenanceOperation)234));
         StringAssert.Contains("Unknown maintenance operation.", ex.Message);
      }

      [Test]
      public void TestUpdateIMAPFolderUID()
      {
         // Set up a basic environment which we can work with.
         var backupRestore = new BackupRestore();
         backupRestore.SetUp();
         backupRestore.SetupEnvironment();

         _application.Utilities.PerformMaintenance(eMaintenanceOperation.eUpdateIMAPFolderUID);
      }
   }
}