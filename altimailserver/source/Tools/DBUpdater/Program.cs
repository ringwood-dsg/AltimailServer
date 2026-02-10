// Modified, Juan Davel/ringwood-dsg, 2025/06/08
// https://altimailserver.org
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Shared;
using System;
using System.Windows.Forms;

namespace DBUpdater
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

         string databaseOldErrorMessage = "is too old for this version";

         try
         {
            CommandLineParser.Parse();

            AltimailServer.Application application = new AltimailServer.Application();

            try
            {
               application.Connect();
            }
            catch (Exception ex)
            {
               if (!ex.Message.Contains(databaseOldErrorMessage))
                  throw ex;
            }


            int from = application.Database.CurrentVersion;
            int to = application.Database.RequiredVersion;

            if (from == to)
            {
               if (!CommandLineParser.ContainsArgument("/SilentIfOk") && !CommandLineParser.IsSilent())
                  MessageBox.Show("Good news!\n\nYour Altimail Server database is up-to-date and requires no upgrades.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Information);

               return;
            }

            if (!Authenticator.AuthenticateUser(application))
               return;

            formMain main = new formMain(application);

            if (!main.LoadSettings())
               return;

            if (!main.CreateUpgradePath())
               return;

            if (CommandLineParser.IsSilent())
            {
               // Silently perform the upgrade
               main.DoUpgrade();
               return;
            }

            // Do it the default way.
            Application.Run(main);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine + "Please check the Altimail Server error log for further details.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}