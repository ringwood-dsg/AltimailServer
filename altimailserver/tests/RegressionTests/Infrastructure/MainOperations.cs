// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer;
using NUnit.Framework;
using RegressionTests.Shared;

namespace RegressionTests.Infrastructure
{
   [TestFixture]
   public class MainOperations : TestFixtureBase
   {
      #region Setup/Teardown

      [SetUp]
      public void Setup()
      {
         SingletonProvider<TestSetup>.Instance.PerformBasicSetup();
      }

      #endregion

      [Test]
      public void RestartServer()
      {
         Application application = SingletonProvider<TestSetup>.Instance.GetApp();
         for (int i = 0; i < 5; i++)
         {
            application.Stop();

            application.Start();
         }
      }

      [Test]
      public void TestInternals()
      {
         Application application = SingletonProvider<TestSetup>.Instance.GetApp();

         application.Utilities.RunTestSuite("I know what I am doing.");
      }

      [Test]
      public void TestLanguages()
      {
         Application application = SingletonProvider<TestSetup>.Instance.GetApp();

         Language oLanguageSwedish = application.GlobalObjects.Languages.get_ItemByName("swedish");
         Language oLanguageEnglish = application.GlobalObjects.Languages.get_ItemByName("english");

         string sSWE = oLanguageSwedish.get_String("File");
         string sENG = oLanguageEnglish.get_String("File");

         Assert.AreEqual(sENG, "File");
         Assert.AreNotEqual(sSWE, sENG);
         Assert.AreNotEqual(sSWE, "");
      }
   }
}