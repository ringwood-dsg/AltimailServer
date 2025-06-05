// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Administrator.Utilities.Localization;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeTCPIPPorts : INode
   {
      public string Title
      {
         get
         {
            return "TCP/IP ports";
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
         return new ucTCPIPPorts();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            AltimailServer.TCPIPPorts tcpIPPorts = APICreator.TCPIPPortsSettings;
            for (int i = 0; i < tcpIPPorts.Count; i++)
            {
               AltimailServer.TCPIPPort tcpIPPort = tcpIPPorts[i];
               subNodes.Add(new NodeTCPIPPort(tcpIPPort.ID, InternalNames.GetPortName(tcpIPPort)));
               Marshal.ReleaseComObject(tcpIPPort);
            }
            Marshal.ReleaseComObject(tcpIPPorts);

            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Add..."));
         itemAdd.Click += new EventHandler(OnAddTCPIPPort);
         return menu;
      }

      internal void OnAddTCPIPPort(object sender, EventArgs e)
      {
         IMainForm mainForm = Instances.MainForm;
         NodeTCPIPPort newRouteNode = new NodeTCPIPPort(0, "");
         mainForm.ShowItem(newRouteNode);
      }
   }
}
