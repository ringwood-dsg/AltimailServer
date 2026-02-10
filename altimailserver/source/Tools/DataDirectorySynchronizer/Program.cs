// Modified, Juan Davel/ringwood-dsg, 2025/06/08
// https://altimailserver.org
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AltimailServer.Shared;

namespace DataDirectorySynchronizer
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

         //Application.Run(new formMain());
         Application.Run(new frmWizard());
      }
   }
}