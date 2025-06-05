// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeSettings : INode
   {
      public string Title
      {
         get
         {
            return "Settings";
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
            return "setting_tools.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucSettings();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            subNodes.Add(new NodeProtocols());
            subNodes.Add(new NodeAntiSpam());
            subNodes.Add(new NodeAntiVirus());
            subNodes.Add(new NodeLogging());
            subNodes.Add(new NodeAdvanced());

            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         return null;
      }
   }
}
