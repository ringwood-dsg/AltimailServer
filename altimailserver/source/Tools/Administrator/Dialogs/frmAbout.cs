using AltimailServer.Administrator.Utilities;
using System;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Dialogs
{
   public partial class frmAbout : Form
   {
      public frmAbout()
      {
         InitializeComponent();
      }

      private void frmAbout_Load(object sender, EventArgs e)
      {
         lblCopyright.Text = lblCopyright.Text.Replace("[y]", (DateTime.UtcNow.Year == 2025 ? "2025" : $"2025-{DateTime.UtcNow.Year}"));

         AltimailServer.Application application = APICreator.Application;
         string serverVersion = application.Version;
         lblVersion.Text = $"version {serverVersion.Split('-')[0]} (Build {serverVersion.Split('-')[1].TrimStart('B')}) x64";

         listBox1.Items.Add("Altimail Server Administration Utility - version 6.0 (Build 2602)");
         //listBox1.Items.Add("Altimail Server DB Upgrade Utility - version 1.0");

         Strings.Localize(this);
      }

      private void btnContribute_Click(object sender, EventArgs e)
      {
         string url = "https://github.com/ringwood-dsg/AltimailServer";

         try
         {
            System.Diagnostics.Process.Start(url);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Web browser could not be started." + Environment.NewLine + ex.Message, EnumStrings.AltimailServerAdministrator, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void btnShowContributors_Click(object sender, EventArgs e)
      {
         string url = "https://github.com/ringwood-dsg/AltimailServer";

         try
         {
            System.Diagnostics.Process.Start(url);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Web browser could not be started." + Environment.NewLine + ex.Message, EnumStrings.AltimailServerAdministrator, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
