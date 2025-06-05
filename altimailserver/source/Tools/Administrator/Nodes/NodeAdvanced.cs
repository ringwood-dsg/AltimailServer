// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System.Collections.Generic;
using System.Windows.Forms;


namespace AltimailServer.Administrator.Nodes
{
   class NodeAdvanced : INode
   {
      public string Title
      {
         get
         {
            return "Advanced";
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
            return "understanding.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucAdvanced();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();
            subNodes.Add(new NodeAutoBan());
            subNodes.Add(new NodeSSLCertificates());
            subNodes.Add(new NodeIPRanges());
            subNodes.Add(new NodeIncomingRelays());
            subNodes.Add(new NodeMirror());
            subNodes.Add(new NodePerformance());
            subNodes.Add(new NodeServerMessages());
            subNodes.Add(new NodeSslTls());
            subNodes.Add(new NodeScripts());
            subNodes.Add(new NodeTCPIPPorts());
            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         return null;
      }
   }
}
