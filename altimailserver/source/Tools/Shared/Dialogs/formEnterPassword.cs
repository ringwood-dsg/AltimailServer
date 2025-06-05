// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AltimailServer.Shared
{
   public partial class formEnterPassword : Form
   {
      private string password;

      public formEnterPassword()
      {
         InitializeComponent();

         password = "";
      }

      public string Password
      {
         get
         {
            return password;
         }

      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         password = textPassword.Text;

         DialogResult = DialogResult.OK;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      private void formEnterPassword_Load(object sender, EventArgs e)
      {

      }

      private void linkWhatIsThis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start("https://www.AltimailServer.com/documentation/latest/?page=reference_dialoghelp_hmailserver_password");
      }
   }
}
