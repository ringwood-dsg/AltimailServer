// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using hMailServer.Administrator.Utilities;
using System;
using System.Windows.Forms;

namespace hMailServer.Administrator
{
   public partial class formAbout : Form
   {
      public formAbout()
      {
         InitializeComponent();

         hMailServer.Application application = APICreator.Application;

         labelVersion.Text = "hMailServer " + application.Version;

         Strings.Localize(this);
      }

      private void linkVisitors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         string url = "http://www.hmailserver.com/documentation/?page=information_author";

         try
         {
            System.Diagnostics.Process.Start(url);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Web browser could not be started." + Environment.NewLine + ex.Message, EnumStrings.hMailServerAdministrator, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         string url = "https://github.com/ringwood-dsg/AltimailServer";

         try
         {
            System.Diagnostics.Process.Start(url);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Web browser could not be started." + Environment.NewLine + ex.Message, EnumStrings.hMailServerAdministrator, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }
   }
}