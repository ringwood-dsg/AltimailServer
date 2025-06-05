﻿using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeIncomingRelays : INode
   {
      public string Title
      {
         get
         {
            return "Incoming relays";
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
         return new ucIncomingRelays();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            AltimailServer.Settings settings = APICreator.Settings;

            AltimailServer.IncomingRelays incomingRelays = settings.IncomingRelays;
            for (int i = 0; i < incomingRelays.Count; i++)
            {
               AltimailServer.IncomingRelay incomingRelay = incomingRelays[i];
               subNodes.Add(new NodeIncomingRelay(incomingRelay.ID, incomingRelay.Name));
               Marshal.ReleaseComObject(incomingRelay);
            }

            Marshal.ReleaseComObject(incomingRelays);

            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Add..."));
         itemAdd.Click += new EventHandler(OnAddIPRange);
         return menu;
      }

      internal void OnAddIPRange(object sender, EventArgs e)
      {
         IMainForm mainForm = Instances.MainForm;
         NodeIncomingRelay newRouteNode = new NodeIncomingRelay(0, "");
         mainForm.ShowItem(newRouteNode);
      }
   }
}
