// Modified, Juan Davel/ringwood-dsg, 2025/06/07
// https://altimailserver.org
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Shared;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DBUpdater
{
   public partial class formMain : Form
   {
      private AltimailServer.Application _application;
      private UpgradeScripts _upgradeScripts;
      private UpgradeScripts _upgradePath;
      private string _databaseType;
      private string _scriptPath;

      private const string DatabaseTypeMSSQL = "MSSQL";
      private const string DatabaseTypePGSQL = "PGSQL";


      public formMain(AltimailServer.Application application)
      {
         InitializeComponent();

         _application = application;
         _databaseType = null;
      }

      public bool CreateUpgradePath()
      {
         _upgradePath = new UpgradeScripts();

         int from = _application.Database.CurrentVersion;
         int to = _application.Database.RequiredVersion;


         // Actually create the path.
         while (from != to)
         {
            UpgradeScript script = _upgradeScripts.GetScriptUpgradingFrom(from);

            if (script == null)
            {
               MessageBox.Show("A suitable upgrade path was not found for your database.\n\nThis is often due to the database being too old and this utility not supporting its version. It can easily be fixed by updating your database to the minimum supported version by Altimail Server and then retrying this upgrade.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }

            string fileName = GetScriptFileName(script);

            if (!File.Exists(fileName))
            {
               MessageBox.Show($"A required upgrade file ({fileName}) was not found. Please re-run your Altimail Server installer to repair any issues.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }

            _upgradePath.Add(script);

            from = script.To;
         }

         DisplayUpgradePath();

         return true;
      }

      public bool LoadSettings()
      {
         _upgradeScripts = new UpgradeScripts();

         switch (_application.Database.DatabaseType)
         {
            case AltimailServer.eDBtype.hDBTypeMSSQL:
               _databaseType = DatabaseTypeMSSQL;
               break;
            case AltimailServer.eDBtype.hDBTypeMSSQLCE:
               _databaseType = "MSSQLCE";
               break;
            case AltimailServer.eDBtype.hDBTypeMySQL:
               _databaseType = "MySQL";
               break;
            case AltimailServer.eDBtype.hDBTypeMariaDB:
               _databaseType = "MariaDB";
               break;
            case AltimailServer.eDBtype.hDBTypePostgreSQL:
               _databaseType = DatabaseTypePGSQL;
               break;
            default:
               MessageBox.Show("E1001: Unknown database type. Please contact us for further assistance.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
         }

         LoadScripts();

         _scriptPath = _application.Settings.Directories.DBScriptDirectory;
         if (_scriptPath == null || _scriptPath.Length == 0)
         {
            MessageBox.Show("Database script directory could not be found." + Environment.NewLine + "Please check the Altimail Server error log.", "Altimail Server");
            return false;
         }

         return true;
      }

      private void DisplayUpgradePath()
      {
         foreach (UpgradeScript script in _upgradePath.GetList())
         {
            ListViewItem item = listRequiredUpgrades.Items.Add(GetDatabaseVersionName(script.From));
            item.SubItems.Add(GetDatabaseVersionName(script.To));
            item.Tag = script;
         }
      }

      private void LoadScripts()
      {
         //We only support "official" upgrade paths for hMailServer releases. The minimum supported database is 5400.
         #region xx to 5708
         _upgradeScripts.Add(new UpgradeScript(5400, 5708));
         _upgradeScripts.Add(new UpgradeScript(5500, 5708));
         _upgradeScripts.Add(new UpgradeScript(5501, 5708));
         _upgradeScripts.Add(new UpgradeScript(5502, 5708));
         _upgradeScripts.Add(new UpgradeScript(5600, 5708));
         _upgradeScripts.Add(new UpgradeScript(5601, 5708));
         _upgradeScripts.Add(new UpgradeScript(5605, 5708));
         _upgradeScripts.Add(new UpgradeScript(5606, 5708));
         _upgradeScripts.Add(new UpgradeScript(5700, 5708));
         _upgradeScripts.Add(new UpgradeScript(5702, 5708));
         _upgradeScripts.Add(new UpgradeScript(5703, 5708));
         _upgradeScripts.Add(new UpgradeScript(5704, 5708));
         _upgradeScripts.Add(new UpgradeScript(5705, 5708));
         #endregion
      }

      private void buttonClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private string GetDatabaseVersionName(int version)
      {
         switch (version)
         {
            case 5400:
               return "hMailServer 5.4";
            case 5500:
               return "hMailServer 5.5 (Alpha 1)";
            case 5501:
               return "hMailServer 5.5 (Alpha 2)";
            case 5502:
               return "hMailServer 5.5";
            case 5600:
               return "hMailServer 5.6 (Alpha 1)";
            case 5601:
               return "hMailServer 5.6";
            case 5605:
               return "hMailServer 5.6.9 (5605)";
            case 5606:
               return "hMailServer 5.6.9 (5606)";
            case 5700:
               return "hMailServer 5.7 (5700)";
            case 5702:
               return "hMailServer 5.7 (5702)";
            case 5703:
               return "hMailServer 5.7 (5703)";
            case 5704:
               return "hMailServer 5.7 (5704)";
            case 5705:
               return "hMailServer 5.7 (5705)";
            case 5708:
               return "hMailServer 5.7/Altimail Server 6.0 (5708)";
            default:
               return "Unknown Version";
         }
      }

      private string GetScriptFileName(UpgradeScript script)
      {
         string fileName = $"Upgrade{script.From}to{script.To}{_databaseType}.sql";
         string fullPath = Path.Combine(_scriptPath, fileName);

         return fullPath;
      }


      public void DoUpgrade()
      {
         using (new WaitCursor())
         {
            buttonClose.Enabled = false;
            buttonUpgrade.Enabled = false;

            AltimailServer.Database database = _application.Database;

            try
            {
               database.BeginTransaction();
            }
            catch (Exception e)
            {
               HandleUpgradeError(database, e, "Transaction");
               return;
            }

            // Run the prerequisites script.
            string prerequisitesScript = GetPrerequisitesScript();
            if (!string.IsNullOrEmpty(prerequisitesScript))
            {
               string fullScriptPath = Path.Combine(_scriptPath, prerequisitesScript);

               try
               {
                  database.ExecuteSQLScript(fullScriptPath);
               }
               catch (Exception ex)
               {
                  HandleUpgradeError(database, ex, fullScriptPath);
                  return;
               }

            }


            foreach (ListViewItem item in listRequiredUpgrades.Items)
            {
               UpgradeScript script = item.Tag as UpgradeScript;

               string scriptToExecute = GetScriptFileName(script);

               try
               {
                  // Make sure the 
                  database.EnsurePrerequisites(script.To);

                  database.ExecuteSQLScript(scriptToExecute);

                  item.SubItems.Add("Complete");

                  Application.DoEvents();
               }
               catch (Exception e)
               {
                  item.SubItems.Add("Error");

                  HandleUpgradeError(database, e, scriptToExecute);
                  return;
               }

            }

            try
            {
               database.CommitTransaction();
            }
            catch (Exception e)
            {
               HandleUpgradeError(database, e, "Transaction");
               return;
            }

            Marshal.ReleaseComObject(database);

            // Database has been upgraded. Reinitialize the connections.
            _application.Reinitialize();

            RemoveErrorLog();

            buttonClose.Enabled = true;
         }

      }

      private void HandleUpgradeError(AltimailServer.Database database, Exception error, string scriptToExecute)
      {
         try
         {
            database.RollbackTransaction();
         }
         catch (Exception)
         {
            // When an error occurs in MSSQL, the rollback will be done 
            // automatically. Hence it's not always an error that we cannot
            // rollback.
            //
            // Maybe we should check the actual cause of the rollback failure...
            //
         }
         finally
         {
            MessageBox.Show(error.Message, scriptToExecute);
         }

         buttonClose.Enabled = true;
         return;
      }

      private void RemoveErrorLog()
      {
         try
         {
            // Kill the error file, so user isn't notified about old db version.
            string errorFile = _application.Settings.Logging.CurrentErrorLog;

            if (System.IO.File.Exists(errorFile))
               System.IO.File.Delete(errorFile);
         }
         catch (Exception)
         {

         }

      }

      private void formMain_Shown(object sender, EventArgs e)
      {
         labelCurrentDatabaseVersion.Text = GetDatabaseVersionName(_application.Database.CurrentVersion);
         labelRequiredDatabaseVersion.Text = GetDatabaseVersionName(_application.Database.RequiredVersion);
      }

      private void buttonUpgrade_Click(object sender, EventArgs e)
      {
         DialogResult result = MessageBox.Show("Have you taken a backup of the Altimail Server database?", "Altimail Server", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

         if (result == DialogResult.Yes)
            DoUpgrade();
         else if (result == DialogResult.No)
            MessageBox.Show(labelRunBackup.Text, "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      private void listRequiredUpgrades_DoubleClick(object sender, EventArgs e)
      {
         if (listRequiredUpgrades.SelectedItems.Count != 1)
            return;

         UpgradeScript script = listRequiredUpgrades.SelectedItems[0].Tag as UpgradeScript;
         string scriptToExecute = GetScriptFileName(script);

         try
         {
            System.Diagnostics.Process.Start("notepad.exe", scriptToExecute);
         }
         catch (Exception)
         {
            MessageBox.Show("Notepad could not be started.");
         }
      }

      private string GetPrerequisitesScript()
      {
         switch (_databaseType)
         {
            case DatabaseTypeMSSQL:
               return "ScriptPrerequisitesMSSQL.sql";
            case DatabaseTypePGSQL:
               return "ScriptPrerequisitesPGSQL.sql";
            default:
               return null;
         }
      }
   }
}