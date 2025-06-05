// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeDNSBlackList : INode
   {
      private string _title;
      private int _id;

      public NodeDNSBlackList(string title, int id)
      {
         _title = title;
         _id = id;
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
            return _title;
         }
         set
         {
            _title = value;
         }
      }

      public string Icon
      {
         get
         {
            return "email_delete.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucDNSBlackList(_id);
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
         if (Utility.AskDeleteItem(_title))
         {
            AltimailServer.DNSBlackLists dnsBlackLists = APICreator.DNSBlackLists;
            dnsBlackLists.DeleteByDBID(_id);
            Marshal.ReleaseComObject(dnsBlackLists);

            Instances.MainForm.RefreshParentNode();
         }
      }
   }
}
