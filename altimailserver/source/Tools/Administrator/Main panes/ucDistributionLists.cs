// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucDistributionLists : ucItemsView
   {
      private int _domainID;

      public ucDistributionLists(int domainID)
      {
         InitializeComponent();

         _domainID = domainID;
      }

      protected override void LoadList()
      {
         listDistributionLists.Items.Clear();

         AltimailServer.Links links = APICreator.Links;
         AltimailServer.Domain domain = links.get_Domain(_domainID);
         AltimailServer.DistributionLists lists = domain.DistributionLists;

         for (int i = 0; i < lists.Count; i++)
         {
            AltimailServer.DistributionList list = lists[i];

            ListViewItem item = listDistributionLists.Items.Add(list.Address);

            item.SubItems.Add(EnumStrings.GetYesNoString(list.Active));

            item.Tag = list.ID;

            Marshal.ReleaseComObject(list);
         }

         Marshal.ReleaseComObject(lists);
         Marshal.ReleaseComObject(domain);
         Marshal.ReleaseComObject(links);
      }


      protected override ListView GetListView()
      {
         return listDistributionLists;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.Domain domain = APICreator.GetDomain(_domainID);
         AltimailServer.DistributionLists lists = domain.DistributionLists;

         foreach (var item in items)
         {
            int listID = Convert.ToInt32(item.Tag);
            lists.DeleteByDBID(listID);
         }

         Marshal.ReleaseComObject(lists);
         Marshal.ReleaseComObject(domain);

      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeDistributionList newNode = new NodeDistributionList(_domainID, "", 0);
         mainForm.ShowItem(newNode);
      }


   }
}
