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
   public partial class ucRoutes : ucItemsView
   {
      public ucRoutes()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      protected override void LoadList()
      {
         listObjects.Items.Clear();

         AltimailServer.Application app = APICreator.Application;
         AltimailServer.Settings settings = app.Settings;
         AltimailServer.Routes routes = settings.Routes;
         for (int i = 0; i < routes.Count; i++)
         {
            AltimailServer.Route route = routes[i];

            ListViewItem item = listObjects.Items.Add(route.DomainName);
            item.Tag = route.ID;

            Marshal.ReleaseComObject(route);
         }

         Marshal.ReleaseComObject(routes);
         Marshal.ReleaseComObject(settings);
      }

      protected override ListView GetListView()
      {
         return listObjects;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.Routes routes = APICreator.Routes;

         foreach (ListViewItem item in items)
         {
            int id = Convert.ToInt32(item.Tag);
            routes.DeleteByDBID(id);
         }

         Marshal.ReleaseComObject(routes);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeRoute newNode = new NodeRoute(0, "");
         mainForm.ShowItem(newNode);
      }

   }
}
