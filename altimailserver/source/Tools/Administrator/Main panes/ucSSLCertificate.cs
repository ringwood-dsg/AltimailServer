// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucSSLCertificate : UserControl, ISettingsControl
   {
      private SSLCertificate _representedObject;

      public ucSSLCertificate(int certificateID)
      {
         InitializeComponent();

         if (certificateID > 0)
         {
            AltimailServer.Settings settings = APICreator.Settings;
            AltimailServer.SSLCertificates sslCertificates = settings.SSLCertificates;

            _representedObject = sslCertificates.get_ItemByDBID(certificateID);

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(sslCertificates);
         }


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
            return DirtyChecker.IsDirty(this) &&
                   textCertificateFile.Text.Length > 0 &&
                   textName.Text.Length > 0;
         }
      }

      public void LoadData()
      {
         if (_representedObject == null)
            return;

         textName.Text = _representedObject.Name;
         textCertificateFile.Text = _representedObject.CertificateFile;
         textPrivateKeyFile.Text = _representedObject.PrivateKeyFile;
      }

      public bool SaveData()
      {
         bool newObject = false;
         if (_representedObject == null)
         {
            AltimailServer.Settings settings = APICreator.Application.Settings;
            AltimailServer.SSLCertificates sslCertificates = settings.SSLCertificates;

            _representedObject = sslCertificates.Add();

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(sslCertificates);

            newObject = true;
         }

         _representedObject.Name = textName.Text;

         _representedObject.CertificateFile = textCertificateFile.Text;
         _representedObject.PrivateKeyFile = textPrivateKeyFile.Text;

         _representedObject.Save();


         // Refresh the node in the tree if the name has changed.
         IMainForm mainForm = Instances.MainForm;
         mainForm.RefreshCurrentNode(textName.Text);

         // Set the object to clean.
         DirtyChecker.SetClean(this);

         if (newObject)
         {
            SearchNodeText crit = new SearchNodeText(_representedObject.Name);
            mainForm.SelectNode(crit);
         }

         return true;
      }

      public void LoadResources()
      {
         // load the translated resources
      }

      private void buttonSelectCertificate_Click(object sender, EventArgs e)
      {
         openFileDialog.Title = Strings.Localize("Certificate file");
         openFileDialog.Filter = "*.*|*.*";
         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            textCertificateFile.Text = openFileDialog.FileName;
         }
      }

      private void buttonSelectKey_Click(object sender, EventArgs e)
      {
         openFileDialog.Title = Strings.Localize("Private key file");
         openFileDialog.Filter = "*.*|*.*";
         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            textPrivateKeyFile.Text = openFileDialog.FileName;
         }
      }
      private void OnContentChanged()
      {
         Instances.MainForm.OnContentChanged();
      }

      private void OnContentChanged(object sender, EventArgs e)
      {
         OnContentChanged();
      }


   }
}
