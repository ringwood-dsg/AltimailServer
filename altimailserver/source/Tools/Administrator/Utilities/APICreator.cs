// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com


using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Utilities
{
   internal class APICreator
   {
      private static AltimailServer.Application application;

      public static AltimailServer.Application Create(string hostName)
      {
         try
         {
            Type obj = Type.GetTypeFromProgID("AltimailServer.Application", hostName);
            AltimailServer.Application app = (AltimailServer.Application)Activator.CreateInstance(obj);

            application = app;

            return app;
         }
         catch (COMException comException)
         {
            if (comException.ErrorCode == -2147023174)
            {
               MessageBox.Show("Unable to connect to the specified server.", EnumStrings.hMailServerAdministrator);
            }
            else
            {
               MessageBox.Show(comException.Message, EnumStrings.hMailServerAdministrator);
            }

         }
         catch (Exception e)
         {
            MessageBox.Show(e.Message, EnumStrings.hMailServerAdministrator);
         }

         return null;
      }

      public static AltimailServer.Application Application
      {
         get
         {
            return application;
         }
      }

      public static bool Authenticate(AltimailServer.Application app, Settings.Server server)
      {
         string password = server.encryptedPassword;

         if (password.Length > 0)
         {
            password = Encryption.Decrypt(password);
         }

         bool wrongPassword = false;

         while (true)
         {
            if (!server.savePassword || wrongPassword)
            {
               // The user must input the password.
               formEnterPassword dlg = new formEnterPassword();
               if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                  return false;

               password = dlg.Password;
            }

            try
            {
               AltimailServer.Account account = app.Authenticate(server.userName, password);

               if (account == null)
               {
                  // Wrong password, try again.
                  MessageBox.Show("The specified user name or password is incorrect.", EnumStrings.hMailServerAdministrator, MessageBoxButtons.OK);

                  wrongPassword = true;
               }
               else
               {
                  try
                  {
                     if (account.AdminLevel != eAdminLevel.hAdminLevelServerAdmin)
                     {
                        // Wrong password, try again.
                        MessageBox.Show("hMailServer server administration rights are required to run hMailServer Administrator.", EnumStrings.hMailServerAdministrator, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                     }
                     return true;
                  }
                  finally
                  {
                     Marshal.ReleaseComObject(account);
                  }
               }

            }
            catch (Exception e)
            {
               // Wrong password, try again.
               MessageBox.Show("The specified user name or password is incorrect." + Environment.NewLine + e.Message, EnumStrings.hMailServerAdministrator, MessageBoxButtons.OK);

               wrongPassword = true;
            }


         }
      }

      public static AltimailServer.Settings Settings
      {
         get
         {
            return application.Settings;
         }
      }

      public static AltimailServer.AntiSpam AntiSpamSettings
      {
         get
         {
            AltimailServer.Settings settings = Application.Settings;

            AltimailServer.AntiSpam antiSpam = settings.AntiSpam;

            Marshal.ReleaseComObject(settings);

            return antiSpam;
         }
      }

      public static AltimailServer.TCPIPPorts TCPIPPortsSettings
      {
         get
         {
            AltimailServer.Settings settings = Application.Settings;

            AltimailServer.TCPIPPorts tcpIPPorts = settings.TCPIPPorts;

            Marshal.ReleaseComObject(settings);

            return tcpIPPorts;
         }
      }

      public static AltimailServer.DNSBlackLists DNSBlackLists
      {
         get
         {
            AltimailServer.Settings settings = Application.Settings;
            AltimailServer.AntiSpam antiSpam = settings.AntiSpam;
            AltimailServer.DNSBlackLists dnsBlackLists = antiSpam.DNSBlackLists;

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(antiSpam);

            return dnsBlackLists;
         }
      }

      public static AltimailServer.SURBLServers SURBLServers
      {
         get
         {
            AltimailServer.Settings settings = Application.Settings;
            AltimailServer.AntiSpam antiSpam = settings.AntiSpam;
            AltimailServer.SURBLServers surblServers = antiSpam.SURBLServers;

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(antiSpam);

            return surblServers;
         }
      }

      public static AltimailServer.Groups Groups
      {
         get
         {
            AltimailServer.Settings settings = Application.Settings;
            AltimailServer.Groups groups = settings.Groups;

            Marshal.ReleaseComObject(settings);

            return groups;
         }
      }

      public static AltimailServer.SecurityRanges SecurityRanges
      {
         get
         {
            AltimailServer.Settings settings = Application.Settings;
            AltimailServer.SecurityRanges secRanges = settings.SecurityRanges;

            Marshal.ReleaseComObject(settings);

            return secRanges;
         }
      }

      public static AltimailServer.Routes Routes
      {
         get
         {
            AltimailServer.Settings settings = Application.Settings;
            AltimailServer.Routes routes = settings.Routes;

            Marshal.ReleaseComObject(settings);

            return routes;
         }
      }

      public static AltimailServer.GreyListingWhiteAddresses GreylistingWhiteAddresses
      {
         get
         {
            AltimailServer.Settings settings = APICreator.Application.Settings;
            AltimailServer.AntiSpam antiSpamSettings = settings.AntiSpam;
            AltimailServer.GreyListingWhiteAddresses whiteAddresses = antiSpamSettings.GreyListingWhiteAddresses;

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(antiSpamSettings);

            return whiteAddresses;

         }
      }

      public static AltimailServer.Links Links
      {
         get
         {
            AltimailServer.Links links = APICreator.Application.Links;

            return links;

         }
      }

      public static AltimailServer.Domain GetDomain(int domainID)
      {
         AltimailServer.Links links = APICreator.Application.Links;

         AltimailServer.Domain domain = links.get_Domain(domainID);

         Marshal.ReleaseComObject(links);

         return domain;
      }

   }
}
