// Copyright (c) 2025 Juan Davel / Altimail Server.
// Portions (c) Martin Knafve and contributors.
// https://altimailserver.org

using Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;

namespace DBSetup
{
   public partial class frmWizard : Form
   {
      private readonly Dictionary<string, string> _state = new Dictionary<string, string>();

      public frmWizard()
      {
         InitializeComponent();
      }

      private void wizardMain_SelectedPageChanged(object sender, EventArgs e)
      {
         AeroWizard.WizardControl senderCtl = (AeroWizard.WizardControl)sender;
         switch (senderCtl.SelectedPage.Name)
         {
            case "wpAction":
               if (_state.ContainsKey("CreateNew"))
               {
                  if (_state["CreateNew"] == "Yes")
                     optNewDatabase.Checked = true;
                  else
                     optExistingDatabase.Checked = true;
               }

               break;
            case "wpDatabaseType":
               if (_state.ContainsKey("ServerType"))
               {
                  switch (_state["ServerType"])
                  {
                     case "MSSQL":
                        optMSSQL.Checked = true;
                        break;
                     case "MySQL":
                        optMySQL.Checked = true;
                        if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "libmysql.dll")))
                           txtMySqlConnectorPath.Text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "libmysql.dll");

                        break;
                     case "MariaDB":
                        optMariaDB.Checked = true;
                        break;
                     case "PGSQL":
                        optPostgreSQL.Checked = true;
                        break;
                  }
               }

               break;
            case "wpDatabaseConnection":
               if (_state.ContainsKey("ServerAddress"))
                  txtDbServerAddress.Text = _state["ServerAddress"];
               if (_state.ContainsKey("ServerPort"))
                  txtDbPort.Text = _state["ServerPort"];
               if (_state.ContainsKey("DatabaseName"))
                  txtDbName.Text = _state["DatabaseName"];

               if (_state.ContainsKey("Authentication"))
               {
                  if (_state["Authentication"] == "Server")
                     optServerAuth.Checked = true;
                  else if (_state["Authentication"] == "Windows")
                     optIntegratedAuth.Checked = true;
               }

               if (_state.ContainsKey("Username"))
                  txtAuthUsername.Text = _state["Username"];

               if (_state.ContainsKey("Password"))
                  txtAuthPassword.Text = _state["Password"];

               AltimailServer.eDBtype dbType = Globals.GetDatabaseType(_state["ServerType"]);
               switch (dbType)
               {
                  case AltimailServer.eDBtype.hDBTypeMySQL:
                  case AltimailServer.eDBtype.hDBTypeMariaDB:
                     optIntegratedAuth.Enabled = false;
                     optServerAuth.Checked = true;
                     break;
                  case AltimailServer.eDBtype.hDBTypePostgreSQL:
                     optIntegratedAuth.Enabled = false;
                     optServerAuth.Checked = true;
                     break;
                  case AltimailServer.eDBtype.hDBTypeMSSQL:
                     optIntegratedAuth.Enabled = true;
                     optServerAuth.Checked = true;
                     break;
               }

               if (string.IsNullOrWhiteSpace(txtDbPort.Text) ||
                   txtDbPort.Text.Trim() == "3306" ||
                   txtDbPort.Text.Trim() == "5432" ||
                   txtDbPort.Text.Trim() == "1433")
               {
                  switch (dbType)
                  {
                     case AltimailServer.eDBtype.hDBTypeMySQL:
                     case AltimailServer.eDBtype.hDBTypeMariaDB:
                        txtDbPort.Text = "3306";
                        break;
                     case AltimailServer.eDBtype.hDBTypePostgreSQL:
                        txtDbPort.Text = "5432";
                        break;
                     case AltimailServer.eDBtype.hDBTypeMSSQL:
                        txtDbPort.Text = "1433";
                        break;
                  }
               }

               txtAuthUsername.Enabled = optServerAuth.Checked;
               txtAuthPassword.Enabled = optServerAuth.Checked;
               txtDbServerAddress.Focus();

               break;
            case "wpDatabaseService":
               ServiceController[] services = ServiceController.GetServices();

               List<ComboBoxDataItem> dataItems = new List<ComboBoxDataItem>();
               foreach (ServiceController controller in services)
               {
                  if (controller.ServiceName.ToLower() == "altimailserver") continue;
                  if (controller.ServiceName.ToLower() == "hmailserver") continue;

                  dataItems.Add(new ComboBoxDataItem(controller.DisplayName, controller.ServiceName));
               }

               cboDatabaseService.BeginUpdate();
               cboDatabaseService.Items.Clear();
               cboDatabaseService.Items.AddRange(dataItems.ToArray());
               cboDatabaseService.EndUpdate();

               if (_state.ContainsKey("ServiceDependency"))
                  cboDatabaseService.SelectedItem = dataItems.FirstOrDefault(f => f.Value.ToString() == _state["ServiceDependency"]);


               break;
            case "wpFinish":


               break;
            default: break;
         }
      }

      private void WizardPage_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
      {
         AeroWizard.WizardPage senderPg = (AeroWizard.WizardPage)sender;
         switch (senderPg.Name)
         {
            case "wpAction":
               if (optNewDatabase.Checked) _state["CreateNew"] = "Yes";
               else _state["CreateNew"] = "No";

               break;
            case "wpDatabaseType":
               if (optMySQL.Checked)
               {
                  if (string.IsNullOrWhiteSpace(txtMySqlConnectorPath.Text) || !File.Exists(txtMySqlConnectorPath.Text))
                  {
                     MessageBox.Show("Altimail Server does not ship with the MySQL Connector!\r\nPlease specify the libmysql.dll file that should be used by Altimail Server to connect to your MySQL database.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     e.Cancel = true;
                     return;
                  }

                  if (!Is64BitConnector(txtMySqlConnectorPath.Text))
                  {
                     MessageBox.Show("The selected MySQL connector you have provided is not 64-bit.\n\nAltimail Server is a 64-bit application and requires a compatible 64-bit MySQL connector.", "MySQL Connector Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     e.Cancel = true;
                     return;
                  }
               }

               if (optMSSQL.Checked)
                  _state["ServerType"] = "MSSQL";
               else if (optMySQL.Checked)
                  _state["ServerType"] = "MySQL";
               else if (optMariaDB.Checked)
                  _state["ServerType"] = "MariaDB";
               else if (optPostgreSQL.Checked)
                  _state["ServerType"] = "PGSQL";

               break;
            case "wpDatabaseConnection":
               if (string.IsNullOrWhiteSpace(txtDbServerAddress.Text))
               {
                  errNew.SetError(txtDbServerAddress, "The server address requires a value.");
                  e.Cancel = true;
                  txtDbServerAddress.Focus();
                  return;
               }
               else if (string.IsNullOrWhiteSpace(txtDbPort.Text))
               {
                  errNew.SetError(txtDbPort, "The database port requires a value.");
                  e.Cancel = true;
                  txtDbPort.Focus();
                  return;
               }
               else if (!int.TryParse(txtDbPort.Text, out _))
               {
                  errNew.SetError(txtDbPort, "Only numeric values are allowed.");
                  txtDbPort.Focus();
                  e.Cancel = true;
                  return;
               }
               else if (string.IsNullOrWhiteSpace(txtDbName.Text))
               {
                  errNew.SetError(txtDbName, "The database name requires a value.");
                  e.Cancel = true;
                  txtDbName.Focus();
                  return;
               }

               if (optServerAuth.Checked)
                  if (string.IsNullOrWhiteSpace(txtAuthUsername.Text))
                  {
                     errNew.SetError(txtAuthUsername, "Enter an authentication username.");
                     e.Cancel = true;
                     txtAuthUsername.Focus();
                     return;
                  }
                  else if (string.IsNullOrWhiteSpace(txtAuthPassword.Text))
                  {
                     errNew.SetError(txtAuthPassword, "Enter an authentication password.");
                     e.Cancel = true;
                     txtAuthPassword.Focus();
                     return;
                  }

               //Flush data.
               _state["ServerAddress"] = txtDbServerAddress.Text;
               _state["ServerPort"] = txtDbPort.Text;
               _state["DatabaseName"] = txtDbName.Text;

               if (optServerAuth.Checked)
                  _state["Authentication"] = "Server";
               else
                  _state["Authentication"] = "Windows";

               _state["Username"] = txtAuthUsername.Text;
               _state["Password"] = txtAuthPassword.Text;

               break;
            case "wpDatabaseService":
               ComboBoxDataItem selService = cboDatabaseService.SelectedItem as ComboBoxDataItem;
               if (selService != null) _state["ServiceDependency"] = selService.Value.ToString();
               else
               {
                  if (!string.IsNullOrWhiteSpace(cboDatabaseService.Text))
                  {
                     errNew.SetError(cboDatabaseService, "Invalid service name. Choose one from the list.");
                     e.Cancel = true;
                     cboDatabaseService.Focus();
                     return;
                  }

                  _state["ServiceDependency"] = "";
               }

               break;
            case "wpFinish":
               wpFinish.AllowBack = false;
               wpFinish.AllowCancel = false;
               wpFinish.AllowNext = false;

               try
               {
                  //1. Check if the connector requires copying.
                  if (optMySQL.Checked && Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) != Path.GetDirectoryName(txtMySqlConnectorPath.Text))
                     //1.1 Copy the connector to the bin directory (where AltimailServer.exe is).
                     File.Copy(txtMySqlConnectorPath.Text, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Path.GetFileName(txtMySqlConnectorPath.Text)));

                  lblProgress1.Text = "Starting...";
                  imgProgress1.Image = Properties.Resources.progress_running;
                  lblProgress1.Visible = true;
                  imgProgress1.Visible = true;

                  // Perform the task...
                  AltimailServer.eDBtype dbType = Globals.GetDatabaseType(_state["ServerType"]);
                  string serverName = _state["ServerAddress"];
                  string portString = _state["ServerPort"];
                  int port = 0;
                  int.TryParse(portString, out port);
                  string databaseName = _state["DatabaseName"];

                  string userName = _state["Username"];
                  string passWord = _state["Password"];

                  string serviceDependency = _state["ServiceDependency"];
                  if (!string.IsNullOrWhiteSpace(serviceDependency))
                  {
                     lblProgress1.Text = "Setting service dependencies...";
                     SetDependency(serviceDependency);
                  }

                  if (_state["Authentication"] == "Windows")
                  {
                     userName = "";
                     passWord = "";
                  }

                  AltimailServer.Database database = Globals.GetApp().Database;
                  if (_state["CreateNew"] == "Yes")
                  {
                     lblProgress1.Text = $"Creating database '{txtDbName.Text}' on '{txtDbServerAddress.Text}:{txtDbPort.Text}'...";

                     //AddToLog("Please wait while creating database...");
                     database.CreateExternalDatabase(dbType, serverName, port, databaseName, userName, passWord);
                     //AddToLog("Database created.");
                  }
                  else
                  {
                     //AddToLog("Please wait while updating database settings...");
                     lblProgress1.Text = $"Changing default database to '{txtDbName.Text}' on '{txtDbServerAddress.Text}:{txtDbPort.Text}'...";

                     database.SetDefaultDatabase(dbType, serverName, port, databaseName, userName, passWord);
                     //AddToLog("Settings updated.");
                  }

                  //AddToLog("Restarting server...");
                  lblProgress1.Text = "Restarting Altimail Server...";
                  Globals.GetApp().Reinitialize();
                  //AddToLog("Server restarted.");
                  //AddToLog("");
                  //AddToLog("Task completed.");

                  lblProgress1.Text = "All tasks completed successfully.";
                  imgProgress1.Image = Properties.Resources.progress_done;

               }
               catch (Exception ex)
               {
                  //AddToLog(ex.Message);
                  //return false;

                  imgProgress1.Image = Properties.Resources.progress_error;
                  lblProgress1.Text = $"One or more tasks failed. The reported error was:\n\n{ex.Message}";

                  wpFinish.AllowBack = true;
                  wpFinish.AllowCancel = true;

                  e.Cancel = true;
               }

               break;
            default: break;
         }
      }

      private bool Is64BitConnector(string path)
      {
         using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
         using (var reader = new BinaryReader(stream))
         {
            // Skip to PE header offset (at 0x3C)
            stream.Seek(0x3C, SeekOrigin.Begin);
            int peOffset = reader.ReadInt32();

            // Seek to PE header and check signature
            stream.Seek(peOffset, SeekOrigin.Begin);
            uint peHead = reader.ReadUInt32();
            if (peHead != 0x00004550) // "PE\0\0"
               throw new Exception("Invalid PE header");

            // Skip Machine and NumberOfSections
            reader.ReadUInt16(); // Machine
            reader.ReadUInt16(); // NumberOfSections

            // Skip TimeDateStamp, PointerToSymbolTable, NumberOfSymbols, SizeOfOptionalHeader
            stream.Seek(12, SeekOrigin.Current);

            ushort magic = reader.ReadUInt16(); // This is the OptionalHeader.Magic
            switch (magic)
            {
               case 224:
                  return false;
               case 240:
                  return true;
               default:
                  return false;
            }
         }
      }

      private void WizardPage_Rollback(object sender, AeroWizard.WizardPageConfirmEventArgs e)
      {
         AeroWizard.WizardPage senderPg = (AeroWizard.WizardPage)sender;
         switch (senderPg.Name)
         {
            case "wpDatabaseService":
               ComboBoxDataItem selService = cboDatabaseService.SelectedItem as ComboBoxDataItem;
               if (selService != null && _state.ContainsKey("ServiceDependency"))
               {
                  if (selService.Value.ToString() != cboDatabaseService.Text)
                     cboDatabaseService.SelectedItem = null;
               }

               break;
            default: break;
         }
      }

      private void wizardMain_Finished(object sender, EventArgs e)
      {

      }

      private void wizardMain_Cancelling(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (MessageBox.Show("Are you sure you want to cancel this wizard?", "Altimail Server Database Setup Utility", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            this.Close();
      }

      private void SetDependency(string service)
      {
         try
         {
            if (service.Length == 0)
               return;

            //int paranthesisStart = service.LastIndexOf("(") + 1;
            //int paranthesisEnd = service.IndexOf(")", paranthesisStart);
            //int len = paranthesisEnd - paranthesisStart;

            //string serviceName = service.Substring(paranthesisStart, len);

            //Globals.GetApp().Utilities.MakeDependent(serviceName);
            Globals.GetApp().Utilities.MakeDependent(service);
         }
         catch (Exception)
         {
            MessageBox.Show("The set-up failed to set the service dependency.", "Altimail Server");
         }

      }

      private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         errNew.Clear();
      }

      private void AuthenticationMode_CheckedChanged(object sender, EventArgs e)
      {
         errNew.Clear();
         if (optIntegratedAuth.Checked) txtAuthUsername.Text = txtAuthPassword.Text = "";
         txtAuthUsername.Enabled = txtAuthPassword.Enabled = optServerAuth.Checked;
      }

      private void cboDatabaseService_SelectedIndexChanged(object sender, EventArgs e)
      {
         errNew.Clear();
      }

      private void btnBrowseMySqlConnector_Click(object sender, EventArgs e)
      {
         if (dlgBrowseMySqlConnector.ShowDialog() == DialogResult.OK)
         {
            txtMySqlConnectorPath.Text = dlgBrowseMySqlConnector.FileName;
         }
      }

      private void DatabaseEngineType_CheckedChanged(object sender, EventArgs e)
      {
         RadioButton selOpt = (RadioButton)sender;
         switch (selOpt.Name)
         {
            case "optMySQL":


               txtMySqlConnectorPath.Enabled = btnBrowseMySqlConnector.Enabled = true;

               break;
            default:
               if (txtMySqlConnectorPath.Enabled) txtMySqlConnectorPath.Enabled = false;
               if (btnBrowseMySqlConnector.Enabled) btnBrowseMySqlConnector.Enabled = false;

               break;
         }
      }
   }
}
