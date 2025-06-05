// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucIncomingRelays : ucItemsView
   {
      public ucIncomingRelays()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      protected override void LoadList()
      {
         listObjects.Items.Clear();

         AltimailServer.Application app = APICreator.Application;
         AltimailServer.Settings settings = APICreator.Settings;

         AltimailServer.IncomingRelays IncomingRelays = settings.IncomingRelays;

         for (int i = 0; i < IncomingRelays.Count; i++)
         {
            AltimailServer.IncomingRelay IncomingRelay = IncomingRelays[i];

            ListViewItem item = listObjects.Items.Add(IncomingRelay.Name);
            item.SubItems.Add(IncomingRelay.LowerIP);
            item.SubItems.Add(IncomingRelay.UpperIP);
            item.Tag = IncomingRelay.ID;


            Marshal.ReleaseComObject(IncomingRelay);
         }

         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(IncomingRelays);
      }

      protected override ListView GetListView()
      {
         return listObjects;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.Settings settings = APICreator.Settings;
         AltimailServer.IncomingRelays IncomingRelays = settings.IncomingRelays;

         foreach (var item in items)
         {
            int id = Convert.ToInt32(item.Tag);
            IncomingRelays.DeleteByDBID(id);
         }

         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(IncomingRelays);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeIncomingRelay newNode = new NodeIncomingRelay(0, "");
         mainForm.ShowItem(newNode);
      }

   }
}
