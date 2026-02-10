// Modified, Juan Davel/ringwood-dsg, 08/06/2025.
// https://altimailserver.org
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Shared;
using System;
using System.Windows.Forms;

namespace DBSetup
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         CommandLineParser.Parse();

         AltimailServer.Application application = new AltimailServer.Application();
         if (!Authenticator.AuthenticateUser(application))
            return;

         Globals.SetApp(application);

         Application.Run(new frmWizard());
         //Application.Run(new formMain());
      }
   }
}