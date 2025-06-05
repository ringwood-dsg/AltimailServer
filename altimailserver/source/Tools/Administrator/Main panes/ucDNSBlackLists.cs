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
   public partial class ucDNSBlackLists : ucItemsView
   {
      public ucDNSBlackLists()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      protected override void LoadList()
      {
         listObjects.Items.Clear();

         AltimailServer.DNSBlackLists dnsBlackLists = GetDNSBlackLists();
         for (int i = 0; i < dnsBlackLists.Count; i++)
         {
            AltimailServer.DNSBlackList dnsBlackList = dnsBlackLists[i];

            ListViewItem item = listObjects.Items.Add(dnsBlackList.DNSHost);
            item.SubItems.Add(EnumStrings.GetYesNoString(dnsBlackList.Active));

            item.Tag = dnsBlackList.ID;

            Marshal.ReleaseComObject(dnsBlackList);
         }

         Marshal.ReleaseComObject(dnsBlackLists);
      }

      private AltimailServer.DNSBlackLists GetDNSBlackLists()
      {
         AltimailServer.Application app = APICreator.Application;
         AltimailServer.Settings settings = app.Settings;
         AltimailServer.AntiSpam antiSpam = settings.AntiSpam;
         AltimailServer.DNSBlackLists dnsBlackLists = antiSpam.DNSBlackLists;

         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(antiSpam);

         return dnsBlackLists;
      }


      protected override ListView GetListView()
      {
         return listObjects;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.DNSBlackLists lists = GetDNSBlackLists();

         foreach (var item in items)
         {
            lists.DeleteByDBID(Convert.ToInt32(item.Tag));
         }

         Marshal.ReleaseComObject(lists);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeDNSBlackList newNode = new NodeDNSBlackList("", 0);
         mainForm.ShowItem(newNode);
      }

      private void listObjects_DoubleClick(object sender, EventArgs e)
      {

      }
   }
}
