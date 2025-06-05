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
   public partial class ucSSLCertificates : ucItemsView
   {
      public ucSSLCertificates()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }


      protected override void LoadList()
      {
         listObjects.Items.Clear();

         AltimailServer.Application app = APICreator.Application;
         AltimailServer.Settings settings = app.Settings;
         AltimailServer.SSLCertificates sslCertificates = settings.SSLCertificates;

         for (int i = 0; i < sslCertificates.Count; i++)
         {
            AltimailServer.SSLCertificate sslCertificate = sslCertificates[i];
            ListViewItem item = listObjects.Items.Add(sslCertificate.Name);
            item.Tag = sslCertificate.ID;
            Marshal.ReleaseComObject(sslCertificate);
         }

         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(sslCertificates);
      }

      protected override ListView GetListView()
      {
         return listObjects;
      }

      protected override void DeleteItems(List<ListViewItem> items)
      {
         AltimailServer.Settings settings = APICreator.Settings;
         AltimailServer.SSLCertificates sslCertificates = settings.SSLCertificates;

         foreach (ListViewItem item in items)
         {
            int id = Convert.ToInt32(item.Tag);
            sslCertificates.DeleteByDBID(id);
         }

         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(sslCertificates);
      }

      protected override void AddItem()
      {
         IMainForm mainForm = Instances.MainForm;

         // Show the new account.
         NodeSSLCertificate newNode = new NodeSSLCertificate(0, "");
         mainForm.ShowItem(newNode);
      }
   }
}
