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
   public partial class ucAliases : ucItemsView
   {
      private int _domainID;

      public ucAliases(int domainID)
      {
         InitializeComponent();

         _domainID = domainID;

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      protected override void LoadList()
      {
         listAliases.Items.Clear();

         AltimailServer.Links links = APICreator.Links;
         AltimailServer.Domain domain = links.get_Domain(_domainID);
         Marshal.ReleaseComObject(links);

         AltimailServer.Aliases aliases = domain.Aliases;
         Marshal.ReleaseComObject(domain);

         for (int i = 0; i < aliases.Count; i++)
         {
            AltimailServer.Alias alias = aliases[i];

            ListViewItem item = listAliases.Items.Add(alias.Name);
            item.SubItems.Add(alias.Value);
            item.SubItems.Add(EnumStrings.GetYesNoString(alias.Active));

            item.Tag = alias.ID;

            Marshal.ReleaseComObject(alias);
         }


         Marshal.ReleaseComObject(aliases);
      }


      protected override ListView GetListView()
      {
         return listAliases;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.Links links = APICreator.Links;
         AltimailServer.Domain domain = links.get_Domain(_domainID);
         Marshal.ReleaseComObject(links);

         AltimailServer.Aliases aliases = domain.Aliases;
         foreach (ListViewItem item in items)
         {
            int aliasID = Convert.ToInt32(item.Tag);
            aliases.DeleteByDBID(aliasID);
         }

         Marshal.ReleaseComObject(domain);
         Marshal.ReleaseComObject(aliases);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeAlias aliasNode = new NodeAlias(_domainID, "", 0);
         mainForm.ShowItem(aliasNode);
      }




   }
}
