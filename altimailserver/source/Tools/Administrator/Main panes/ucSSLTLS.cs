// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucSSLTLS : UserControl, ISettingsControl
   {
      public ucSSLTLS()
      {
         InitializeComponent();

         DirtyChecker.SubscribeToChange(this, OnContentChanged);

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      public void OnLeavePage()
      {

      }

      public bool Dirty
      {
         get
         {
            return DirtyChecker.IsDirty(this);
         }
      }

      public void LoadData()
      {
         AltimailServer.Application app = APICreator.Application;

         AltimailServer.Settings settings = app.Settings;

         checkVerifyRemoteServerSslCertificate.Checked = settings.VerifyRemoteSslCertificate;
         textSslCipherList.Text = settings.SslCipherList;
         checkTlsVersion10.Checked = settings.TlsVersion10Enabled;
         checkTlsVersion11.Checked = settings.TlsVersion11Enabled;
         checkTlsVersion12.Checked = settings.TlsVersion12Enabled;
         checkTlsVersion13.Checked = settings.TlsVersion13Enabled;
         checkTlsOptionPreferServerCiphers.Checked = settings.TlsOptionPreferServerCiphersEnabled;
         checkTlsOptionPrioritizeChaCha.Enabled = (settings.TlsVersion12Enabled || settings.TlsVersion13Enabled) && settings.TlsOptionPreferServerCiphersEnabled;
         checkTlsOptionPrioritizeChaCha.Checked = settings.TlsOptionPrioritizeChaChaEnabled;

         Marshal.ReleaseComObject(settings);
      }

      public bool SaveData()
      {
         AltimailServer.Application app = APICreator.Application;

         AltimailServer.Settings settings = app.Settings;

         bool restartRequired =
           textSslCipherList.Dirty ||
           checkTlsVersion10.Dirty ||
           checkTlsVersion11.Dirty ||
           checkTlsVersion12.Dirty ||
           checkTlsVersion13.Dirty ||
           checkTlsOptionPreferServerCiphers.Dirty ||
           checkTlsOptionPrioritizeChaCha.Dirty;

         settings.VerifyRemoteSslCertificate = checkVerifyRemoteServerSslCertificate.Checked;
         settings.SslCipherList = textSslCipherList.Text;

         settings.TlsVersion10Enabled = checkTlsVersion10.Checked;
         settings.TlsVersion11Enabled = checkTlsVersion11.Checked;
         settings.TlsVersion12Enabled = checkTlsVersion12.Checked;
         settings.TlsVersion13Enabled = checkTlsVersion13.Checked;

         settings.TlsOptionPreferServerCiphersEnabled = checkTlsOptionPreferServerCiphers.Checked;
         settings.TlsOptionPrioritizeChaChaEnabled = checkTlsOptionPrioritizeChaCha.Enabled && checkTlsOptionPrioritizeChaCha.Checked;

         Marshal.ReleaseComObject(settings);

         if (restartRequired)
            Utility.AskRestartServer();

         DirtyChecker.SetClean(this);
         return true;

      }

      public void LoadResources()
      {
         // load the translated resources
      }


      private void OnContentChanged()
      {
         Instances.MainForm.OnContentChanged();

         checkTlsOptionPrioritizeChaCha.Enabled = (checkTlsVersion12.Checked || checkTlsVersion13.Checked) && checkTlsOptionPreferServerCiphers.Checked;
         if (!checkTlsOptionPrioritizeChaCha.Enabled && checkTlsOptionPrioritizeChaCha.Checked)
         {
            checkTlsOptionPrioritizeChaCha.Checked = false;
         }
      }

      private void OnContentChanged(object sender, EventArgs e)
      {
         OnContentChanged();
      }
   }
}