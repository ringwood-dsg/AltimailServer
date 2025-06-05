// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeSSLCertificates : INode
   {
      public string Title
      {
         get
         {
            return "SSL certificates";
         }
         set { }
      }

      public System.Drawing.Color ForeColor { get { return System.Drawing.SystemColors.WindowText; } set { } }

      public bool IsUserCreated
      {
         get { return false; }
      }

      public string Icon
      {
         get
         {
            return "folder.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucSSLCertificates();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            AltimailServer.Settings settings = APICreator.Settings;
            AltimailServer.SSLCertificates sslCertificates = settings.SSLCertificates;

            for (int i = 0; i < sslCertificates.Count; i++)
            {
               AltimailServer.SSLCertificate sslCertificate = sslCertificates[i];
               subNodes.Add(new NodeSSLCertificate(sslCertificate.ID, sslCertificate.Name));
               Marshal.ReleaseComObject(sslCertificate);
            }

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(sslCertificates);

            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Add..."));
         itemAdd.Click += new EventHandler(OnAddSSLCertificate);
         return menu;
      }

      internal void OnAddSSLCertificate(object sender, EventArgs e)
      {
         IMainForm mainForm = Instances.MainForm;
         NodeSSLCertificate newSSLCertificateNode = new NodeSSLCertificate(0, "");
         mainForm.ShowItem(newSSLCertificateNode);
      }
   }
}
