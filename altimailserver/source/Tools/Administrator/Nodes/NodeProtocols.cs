// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeProtocols : INode
   {

      public NodeProtocols()
      {

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
            return "Protocols";
         }
         set { }
      }

      public string Icon
      {
         get
         {
            return "server_connect.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucProtocols();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            subNodes.Add(new NodeProtocolSMTP());
            subNodes.Add(new NodeProtocolPOP3());
            subNodes.Add(new NodeProtocolIMAP());

            return subNodes;
         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         return null;
      }

   }
}
