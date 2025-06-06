// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AltimailServer.Shared;


namespace DBSetup.Pages
{
   public partial class ucDBConnectionInfo : UserControl, IWizardPage
   {
      private Dictionary<string, string> _state;

      public ucDBConnectionInfo()
      {
         InitializeComponent();
      }

      public string Title
      {
         get
         {
            return "Enter server connection information";
         }
      }

      public void OnShowPage(Dictionary<string, string> state)
      {
         _state = state;

         if (_state.ContainsKey("ServerAddress"))
            textServerAddress.Text = _state["ServerAddress"];
         if (_state.ContainsKey("ServerPort"))
            textServerPort.Text = _state["ServerPort"];
         if (_state.ContainsKey("DatabaseName"))
            textDatabaseName.Text = _state["DatabaseName"];

         if (_state.ContainsKey("Authentication"))
         {
            if (_state["Authentication"] == "Server")
               radioUseServerAuthentication.Checked = true;
            else if (_state["Authentication"] == "Windows")
               radioUseWindowsAuthentication.Checked = true;
         }

         if (_state.ContainsKey("Username"))
            textUsername.Text = _state["Username"];

         if (_state.ContainsKey("Password"))
            textPassword.Text = _state["Password"];

         AltimailServer.eDBtype dbType = Globals.GetDatabaseType(_state["ServerType"]);
         switch (dbType)
         {
            case AltimailServer.eDBtype.hDBTypeMySQL:
            case AltimailServer.eDBtype.hDBTypeMariaDB:
               radioUseWindowsAuthentication.Enabled = false;
               radioUseServerAuthentication.Checked = true;
               break;
            case AltimailServer.eDBtype.hDBTypePostgreSQL:
               radioUseWindowsAuthentication.Enabled = false;
               radioUseServerAuthentication.Checked = true;
               break;
            case AltimailServer.eDBtype.hDBTypeMSSQL:
               radioUseWindowsAuthentication.Enabled = true;
               textServerPort.Text = "";
               break;
         }

         if (textServerPort.Text.Length == 0 || 
             textServerPort.Number == 3306 ||
             textServerPort.Number == 5432)
         {
            switch (dbType)
            {
               case AltimailServer.eDBtype.hDBTypeMySQL:
               case AltimailServer.eDBtype.hDBTypeMariaDB:
                  textServerPort.Number = 3306;
                  break;
               case AltimailServer.eDBtype.hDBTypePostgreSQL:
                  textServerPort.Number = 5432;
                  break;
            }
         }

         EnableDisable();
      }

      public bool OnLeavePage(bool next)
      {
         if (next)
         {
            if (textDatabaseName.Text.Length == 0)
            {
               MessageBox.Show("You must enter the name of the database to create.", "hMailServer");
               return false;
            }

            if (textServerAddress.Text.Length == 0)
            {
               MessageBox.Show("You must enter the name of the database server to connect to.", "hMailServer");
               return false;
            }
         }

         _state["ServerAddress"] = textServerAddress.Text;
         _state["ServerPort"] = textServerPort.Text;
         _state["DatabaseName"] = textDatabaseName.Text;
         
         if (radioUseServerAuthentication.Checked)
            _state["Authentication"] = "Server";
         else
            _state["Authentication"] = "Windows";

         _state["Username"] = textUsername.Text;
         _state["Password"] = textPassword.Text;

         return true;
      }

      private void EnableDisable()
      {
         textUsername.Enabled = radioUseServerAuthentication.Checked;
         textPassword.Enabled = radioUseServerAuthentication.Checked;

         AltimailServer.eDBtype dbType = Globals.GetDatabaseType(_state["ServerType"]);
         textServerPort.Enabled = dbType != AltimailServer.eDBtype.hDBTypeMSSQL;
      }

      private void radioUseServerAuthentication_CheckedChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

      private void radioUseWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

   }
}
