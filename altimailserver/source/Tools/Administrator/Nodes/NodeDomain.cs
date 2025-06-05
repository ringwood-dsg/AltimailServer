// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeDomain : INode
   {
      private IMainForm _mainForm;

      private int _representedObjectID;
      private string _representedObjectName;

      public NodeDomain(IMainForm mainForm, int representedObjectID, string representedObjectName)
      {
         _mainForm = mainForm;
         _representedObjectID = representedObjectID;
         _representedObjectName = representedObjectName;
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
            return _representedObjectName;
         }
         set
         {
            _representedObjectName = value;
         }
      }



      public string Icon
      {
         get
         {
            return "server.ico";
         }
      }

      public UserControl CreateControl()
      {
         AltimailServer.Domain domain = GetDomain();

         return new ucDomain(domain);
      }

      public AltimailServer.Domain GetDomain()
      {

         AltimailServer.Domain domain = null;
         if (_representedObjectID > 0)
         {
            domain = APICreator.GetDomain(_representedObjectID);
         }

         return domain;

      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            subNodes.Add(new NodeAccounts(_representedObjectID));
            subNodes.Add(new NodeAliases(_representedObjectID));
            subNodes.Add(new NodeDistributionLists(_representedObjectID));

            return subNodes;
         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Remove"));
         itemAdd.Click += OnDeleteDomain;

         return menu;
      }

      public void OnDeleteDomain(object sender, EventArgs args)
      {
         // Delete the domain.
         AltimailServer.Domain domain = GetDomain();
         if (domain == null)
            return;

         if (Utility.AskDeleteItem(domain.Name))
         {
            domain.Delete();
            _mainForm.RefreshParentNode();
         }
      }

   }
}
