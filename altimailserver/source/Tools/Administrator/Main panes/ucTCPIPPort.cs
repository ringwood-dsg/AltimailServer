// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Administrator.Utilities.Localization;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucTCPIPPort : UserControl, ISettingsControl
   {
      private AltimailServer.TCPIPPort _representedObject;

      public ucTCPIPPort(int portID)
      {
         InitializeComponent();

         DirtyChecker.SubscribeToChange(this, OnContentChanged);

         if (portID > 0)
         {
            AltimailServer.TCPIPPorts ports = APICreator.TCPIPPortsSettings;
            _representedObject = ports.get_ItemByDBID(portID);
            Marshal.ReleaseComObject(ports);
         }

         comboProtocol.AddItem("SMTP", eSessionType.eSTSMTP);
         comboProtocol.AddItem("POP3", eSessionType.eSTPOP3);
         comboProtocol.AddItem("IMAP", eSessionType.eSTIMAP);

         comboConnectionSecurity.AddItems(ConnectionSecurityTypes.Get(true));

         ListSSLCertificates();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

         EnableDisable();
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
         if (_representedObject == null)
            return;

         textIPAddress.Text = _representedObject.Address;
         textTCPIPPort.Number = _representedObject.PortNumber;
         comboProtocol.SelectedValue = _representedObject.Protocol;
         comboSSLCertificate.SelectedValue = _representedObject.SSLCertificateID;
         comboConnectionSecurity.SelectedValue = _representedObject.ConnectionSecurity;

         EnableDisable();
      }

      private void ListSSLCertificates()
      {
         comboSSLCertificate.Items.Clear();

         AltimailServer.Settings settings = APICreator.Settings;
         AltimailServer.SSLCertificates sslCertificates = settings.SSLCertificates;

         for (int i = 0; i < sslCertificates.Count; i++)
         {
            AltimailServer.SSLCertificate certificate = sslCertificates[i];

            comboSSLCertificate.AddItem(certificate.Name, certificate.ID);

            Marshal.ReleaseComObject(certificate);
         }

         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(sslCertificates);



      }

      public bool SaveData()
      {
         if (_representedObject == null)
         {
            AltimailServer.TCPIPPorts tcpIPPorts = APICreator.TCPIPPortsSettings;
            _representedObject = tcpIPPorts.Add();
            Marshal.ReleaseComObject(tcpIPPorts);
         }

         _representedObject.Address = textIPAddress.Text;
         _representedObject.PortNumber = textTCPIPPort.Number;
         _representedObject.ConnectionSecurity = (eConnectionSecurity)comboConnectionSecurity.SelectedValue;
         _representedObject.Protocol = (AltimailServer.eSessionType)comboProtocol.SelectedValue;

         if (comboSSLCertificate.SelectedValue == null)
            _representedObject.SSLCertificateID = 0;
         else
            _representedObject.SSLCertificateID = (int)comboSSLCertificate.SelectedValue;

         _representedObject.Save();

         DirtyChecker.SetClean(this);

         Utility.RefreshNode(InternalNames.GetPortName(_representedObject));

         Utility.AskRestartServer();

         return true;

      }

      public void LoadResources()
      {
         // load the translated resources
      }


      private void OnContentChanged()
      {
         Instances.MainForm.OnContentChanged();
      }

      private void OnContentChanged(object sender, EventArgs e)
      {
         OnContentChanged();
      }

      private void EnableDisable()
      {
         comboSSLCertificate.Enabled = comboConnectionSecurity.SelectedIndex > 0;
      }

      private void comboConnectionSecurity_SelectedIndexChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

   }
}

