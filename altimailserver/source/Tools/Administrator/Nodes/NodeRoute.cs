// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeRoute : INode
   {
      private int _routeID;
      private string _routeName;

      public NodeRoute(int routeID, string routeName)
      {
         _routeID = routeID;
         _routeName = routeName;
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
            return _routeName;
         }
         set
         {
            _routeName = value;
         }
      }

      public string Icon
      {
         get
         {
            return "routing_intersection_right.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucRoute(_routeID);
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
         if (Utility.AskDeleteItem(_routeName))
         {
            AltimailServer.Routes routes = APICreator.Routes;
            routes.DeleteByDBID(_routeID);
            Instances.MainForm.RefreshParentNode();
         }
      }
   }
}
