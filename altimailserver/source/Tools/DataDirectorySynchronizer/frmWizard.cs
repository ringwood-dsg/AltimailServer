// Copyright (c) 2025 Juan Davel / Altimail Server.
// Portions (c) Martin Knafve and contributors.
// https://altimailserver.org

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DataDirectorySynchronizer
{
   public partial class frmWizard : Form
   {
      AltimailServer.Application _application;
      AltimailServer.Domains _domains;
      AltimailServer.Utilities _utilities;

      private DateTime _startTime;
      private int _counter;

      public frmWizard()
      {
         InitializeComponent();

         _application = Globals.GetApp();
         _utilities = _application.Utilities;
         _domains = _application.Domains;
         _counter = 0;
      }

      private void wizardMain_SelectedPageChanged(object sender, EventArgs e)
      {
         AeroWizard.WizardControl senderCtl = (AeroWizard.WizardControl)sender;
         switch (senderCtl.SelectedPage.Name)
         {
            case "wpDomains":
               AltimailServer.Application application = Globals.GetApp();
               AltimailServer.Domains domains = application.Domains;

               for (int i = 0; i < domains.Count; i++)
               {
                  AltimailServer.Domain domain = domains[i];
                  listViewDomains.Items.Add(domain.Name);

                  Marshal.ReleaseComObject(domain);
               }

               Marshal.ReleaseComObject(domains);

               foreach (ListViewItem item in listViewDomains.Items)
               {
                  if (Globals.SelectedDomains.Contains(item.Text)) item.Checked = true;
                  else item.Checked = false;
               }

               break;
            //case "wpFinish":


            //   break;
            default: break;
         }
      }

      private void WizardPage_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
      {
         AeroWizard.WizardPage senderPg = (AeroWizard.WizardPage)sender;
         switch (senderPg.Name)
         {
            case "wpAction":
               Globals.Mode = (optImportMail.Checked ? Globals.ModeType.Import : Globals.ModeType.Delete);

               break;
            case "wpDomains":
               Globals.SelectedDomains.Clear();

               foreach (ListViewItem item in listViewDomains.Items)
                  if (item.Checked) 
                     Globals.SelectedDomains.Add(item.Text);

               if (Globals.SelectedDomains.Count == 0)
               {
                  MessageBox.Show("You need to select at least one (1) domain.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  e.Cancel = true;
                  return;
               }

               break;
            case "wpFinish":
               wpFinish.AllowBack = false;
               wpFinish.AllowCancel = false;

               imgStatus.Visible = true;
               imgStatus.Image = Properties.Resources.progress_running;

               labelStatus.Visible = labelExecutionTime.Visible = true;
               listProcess.Visible = true;

               try
               {
                  timer1.Enabled = true;
                  _startTime = DateTime.Now;

                  AltimailServer.Application application = Globals.GetApp();

                  string dataDirectory = application.Settings.Directories.DataDirectory;
                  DirectoryInfo dirInfo = new DirectoryInfo(dataDirectory);

                  // Process the queue first.
                  ProcessFilesInFolder(dirInfo, 0);

                  // Process all domains
                  IterateDomainFolders(dirInfo);

                  timer1.Enabled = false;

                  application.Reinitialize();
                  TimerTick();

                  imgStatus.Image = Properties.Resources.progress_done;
                  labelStatus.Text = "Synchronisation completed.";

               }
               catch (Exception ex)
               {
                  imgStatus.Image = Properties.Resources.progress_error;
                  MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                  e.Cancel = true;
               }

               break;
            default: break;
         }
      }

      private void WizardPage_Rollback(object sender, AeroWizard.WizardPageConfirmEventArgs e)
      {
         AeroWizard.WizardPage senderPg = (AeroWizard.WizardPage)sender;
         switch (senderPg.Name)
         {
            //case "wpDatabaseService":
            //   ComboBoxDataItem selService = cboDatabaseService.SelectedItem as ComboBoxDataItem;
            //   if (selService != null && _state.ContainsKey("ServiceDependency"))
            //   {
            //      if (selService.Value.ToString() != cboDatabaseService.Text)
            //         cboDatabaseService.SelectedItem = null;
            //   }

            //   break;
            default: break;
         }
      }

      private void wizardMain_Finished(object sender, EventArgs e)
      {
         MessageBox.Show("The selected action was executed successfully.", "Altimail Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void wizardMain_Cancelling(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (MessageBox.Show("Are you sure you want to cancel this wizard?", "Altimail Server Data Synchronisation Utility", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            this.Close();
      }

      private void btnSelectNone_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewDomains.Items)
            item.Checked = false;
      }

      private void btnSelectAll_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewDomains.Items)
            item.Checked = true;
      }

      private void timer1_Tick(object sender, EventArgs e)
      {
         TimerTick();
      }

      private void TimerTick()
      {
         TimeSpan ts = DateTime.Now - _startTime;

         string hours = ts.Hours.ToString();
         string minutes = ts.Minutes.ToString();
         string seconds = ts.Seconds.ToString();

         if (hours.Length == 1) hours = "0" + hours;
         if (minutes.Length == 1) minutes = "0" + minutes;
         if (seconds.Length == 1) seconds = "0" + seconds;

         labelExecutionTime.Text = hours + ":" + minutes + ":" + seconds;
      }

      private void AddProcessedFile(string file, bool processed)
      {
         if (processed == false)
         {
            listProcess.Items.Add(file);
         }

         _counter++;

         if (_counter % 10 == 0)
            Application.DoEvents();

      }

      private void ProcessFilesInFolder(DirectoryInfo dirInfo, int accountID)
      {
         labelStatus.Text = dirInfo.FullName;
         foreach (FileInfo file in dirInfo.GetFiles())
         {
            string fullName = file.FullName;

            bool imported = false;

            if (fullName.ToLower().EndsWith(".eml") ||
                fullName.ToLower().EndsWith(".hma"))
            {
               if (Globals.Mode == Globals.ModeType.Import)
                  imported = _utilities.ImportMessageFromFile(fullName, accountID);
               else
               {
                  // does it exist?
                  long messageID = _utilities.RetrieveMessageID(fullName);

                  if (messageID == 0)
                  {
                     // no. delete the file.
                     File.Delete(file.FullName);
                  }

                  imported = true;
               }
            }

            AddProcessedFile(fullName, imported);
         }
      }

      private void IterateDomainFolders(DirectoryInfo dirRoot)
      {
         foreach (DirectoryInfo domainFolder in dirRoot.GetDirectories())
         {

            try
            {
               // Should we process this domain?
               if (Globals.SelectedDomains.Contains(domainFolder.Name))
               {
                  AltimailServer.Domain domain = _domains.get_ItemByName(domainFolder.Name);

                  DirectoryInfo accountsFolder = new DirectoryInfo(domainFolder.FullName);
                  IterateAccounts(domain, accountsFolder);

                  Marshal.ReleaseComObject(domain);
               }
            }
            catch (Exception)
            {
               AddProcessedFile(domainFolder.FullName, false);
            }
         }
      }

      private void IterateAccounts(AltimailServer.Domain domain, DirectoryInfo folder)
      {
         string domainName = domain.Name;
         foreach (DirectoryInfo directory in folder.GetDirectories())
         {
            try
            {
               AltimailServer.Account account =
                  domain.Accounts.get_ItemByAddress(directory.Name + "@" + domainName);

               IterateAccountFolders(account.ID, directory);

               Marshal.ReleaseComObject(account);
            }
            catch (Exception)
            {
               AddProcessedFile(directory.FullName, false);
            }
         }
      }

      private void IterateAccountFolders(int accountID, DirectoryInfo folder)
      {
         try
         {

            ProcessFilesInFolder(folder, accountID);

            foreach (DirectoryInfo accountSubFolder in folder.GetDirectories())
            {
               ProcessFilesInFolder(accountSubFolder, accountID);
            }
         }
         catch (Exception)
         {
            AddProcessedFile(folder.FullName, false);
         }
      }
   }
}
