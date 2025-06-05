// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeGroups : INode
   {
      private IMainForm _mainForm;

      public NodeGroups(IMainForm mainForm)
      {
         _mainForm = mainForm;
      }

      public System.Drawing.Color ForeColor { get { return System.Drawing.SystemColors.WindowText; } set { } }

      public bool IsUserCreated
      {
         get { return false; }
      }

      public string Title
      {
         get
         {
            return "Groups";
         }
         set { }
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
         return new ucGroups();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            AltimailServer.Groups groups = APICreator.Groups;

            for (int i = 0; i < groups.Count; i++)
            {
               AltimailServer.Group group = groups[i];

               subNodes.Add(new NodeGroup(group.Name, group.ID));

               Marshal.ReleaseComObject(group);
            }

            Marshal.ReleaseComObject(groups);

            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Add..."));
         itemAdd.Click += new EventHandler(OnAddGroup);
         return menu;
      }

      internal void OnAddGroup(object sender, EventArgs e)
      {
         NodeGroup newGroupNode = new NodeGroup("", 0);
         _mainForm.ShowItem(newGroupNode);
      }
   }
}
