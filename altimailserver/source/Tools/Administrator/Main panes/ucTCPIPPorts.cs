// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using AltimailServer.Administrator.Utilities.Localization;
using AltimailServer.Shared;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucTCPIPPorts : ucItemsView
   {
      public ucTCPIPPorts()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }


      protected override void LoadList()
      {
         listObjects.Items.Clear();

         AltimailServer.TCPIPPorts tcpIPPorts = APICreator.TCPIPPortsSettings;
         for (int i = 0; i < tcpIPPorts.Count; i++)
         {
            AltimailServer.TCPIPPort tcpIPPort = tcpIPPorts[i];
            ListViewItem item = listObjects.Items.Add(InternalNames.GetPortName(tcpIPPort));
            item.Tag = tcpIPPort.ID;

            Marshal.ReleaseComObject(tcpIPPort);
         }

         Marshal.ReleaseComObject(tcpIPPorts);
      }

      protected override ListView GetListView()
      {
         return listObjects;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.TCPIPPorts tcpIPPorts = APICreator.TCPIPPortsSettings;

         foreach (ListViewItem item in items)
         {
            int id = Convert.ToInt32(item.Tag);
            tcpIPPorts.DeleteByDBID(id);
         }

         Marshal.ReleaseComObject(tcpIPPorts);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeTCPIPPort newNode = new NodeTCPIPPort(0, "");
         mainForm.ShowItem(newNode);
      }

      private void buttonDefault_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show(Strings.Localize("This operation will change the configuration of the TCP/IP ports to their default values. Are you sure you want to do this?"), EnumStrings.hMailServerAdministrator, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
         {
            AltimailServer.Application app = APICreator.Application;

            AltimailServer.TCPIPPorts tcpIPPorts = APICreator.TCPIPPortsSettings;
            tcpIPPorts.SetDefault();
            Marshal.ReleaseComObject(tcpIPPorts);

            LoadList();

            Instances.MainForm.RefreshCurrentNode(null);
         }
      }
   }
}
