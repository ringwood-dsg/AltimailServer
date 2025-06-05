// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucSURBLServers : ucItemsView
   {
      public ucSURBLServers()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);


      }

      protected override void LoadList()
      {
         listObjects.Items.Clear();

         AltimailServer.SURBLServers surblServers = GetSurblServers();

         for (int i = 0; i < surblServers.Count; i++)
         {
            AltimailServer.SURBLServer surblServer = surblServers[i];

            ListViewItem item = listObjects.Items.Add(surblServer.DNSHost);
            item.SubItems.Add(EnumStrings.GetYesNoString(surblServer.Active));
            item.Tag = surblServer.ID;

            Marshal.ReleaseComObject(surblServer);
         }

         Marshal.ReleaseComObject(surblServers);
      }

      private AltimailServer.SURBLServers GetSurblServers()
      {
         AltimailServer.AntiSpam antiSpam = APICreator.AntiSpamSettings;
         AltimailServer.SURBLServers surblServers = antiSpam.SURBLServers;

         Marshal.ReleaseComObject(antiSpam);

         return surblServers;
      }

      protected override ListView GetListView()
      {
         return listObjects;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.SURBLServers surblServers = GetSurblServers();

         foreach (var item in items)
         {
            int id = Convert.ToInt32(item.Tag);
            surblServers.DeleteByDBID(id);
         }

         Marshal.ReleaseComObject(surblServers);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeSURBLServer newNode = new NodeSURBLServer(0, "");
         mainForm.ShowItem(newNode);
      }
   }
}
