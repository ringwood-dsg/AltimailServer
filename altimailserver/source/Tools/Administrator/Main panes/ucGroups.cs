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
   public partial class ucGroups : ucItemsView
   {
      public ucGroups()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      protected override void LoadList()
      {
         listGroups.Items.Clear();

         AltimailServer.Groups groups = APICreator.Groups;

         for (int i = 0; i < groups.Count; i++)
         {
            AltimailServer.Group group = groups[i];

            ListViewItem item = listGroups.Items.Add(group.Name);
            item.Tag = group.ID;
         }

         Marshal.ReleaseComObject(groups);
      }

      protected override ListView GetListView()
      {
         return listGroups;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.Groups groups = APICreator.Groups;

         foreach (var item in items)
         {
            int id = Convert.ToInt32(item.Tag);
            groups.DeleteByDBID(id);
         }

         Marshal.ReleaseComObject(groups);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeGroup newNode = new NodeGroup("", 0);
         mainForm.ShowItem(newNode);
      }


   }
}
