// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeSSLCertificate : INode
   {
      private int _certificateID = 0;
      private string _certificateName = "";

      public NodeSSLCertificate(int certificateID, string certificateName)
      {
         _certificateID = certificateID;
         _certificateName = certificateName;
      }

      public System.Drawing.Color ForeColor { get { return System.Drawing.SystemColors.WindowText; } set { } }

      public bool IsUserCreated
      {
         get { return true; }
      }

      public string Title
      {
         get
         {
            return _certificateName;
         }
         set
         {
            _certificateName = value;
         }
      }

      public string Icon
      {
         get
         {
            return "rosette.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucSSLCertificate(_certificateID);
      }


      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();
            return subNodes;

         }
      }

      public ContextMenuStrip CreateContextMenu()
      {
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Remove"));
         itemAdd.Click += OnDeleteObject;

         return menu;
      }

      public void OnDeleteObject(object sender, EventArgs args)
      {
         if (!Utility.AskDeleteItem(_certificateName))
            return;

         AltimailServer.Settings settings = APICreator.Settings;
         AltimailServer.SSLCertificates sslCertificates = settings.SSLCertificates;
         sslCertificates.DeleteByDBID(_certificateID);
         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(sslCertificates);

         Instances.MainForm.RefreshParentNode();
      }
   }
}
