// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Administrator.Utilities.Settings;
using AltimailServer.Shared;
using System;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class formServerInformation : Form
   {
      private Server server;

      public formServerInformation()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }

      public Server Server
      {
         get
         {
            return server;
         }
         set
         {
            server = value;

            textHostname.Text = server.hostName;
            textUsername.Text = server.userName;

            radioAskWhenConnecting.Checked = !server.savePassword;
            radioSavePassword.Checked = server.savePassword;

            textPassword.Enabled = radioSavePassword.Checked;
         }
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         server.hostName = textHostname.Text;
         server.userName = textUsername.Text;
         server.savePassword = radioSavePassword.Checked;

         if (textPassword.Dirty)
            server.encryptedPassword = Encryption.Encrypt(textPassword.Password);

         this.DialogResult = DialogResult.OK;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }

      private void radioSavePassword_CheckedChanged(object sender, EventArgs e)
      {
         textPassword.Enabled = radioSavePassword.Checked;
      }
   }
}