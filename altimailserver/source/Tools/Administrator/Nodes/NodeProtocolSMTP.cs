// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeProtocolSMTP : INode
   {
      public string Title
      {
         get
         {
            return "SMTP";
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
            return "connect.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucProtocolSMTP();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();
            subNodes.Add(new NodeRoutes());
            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         return null;
      }
   }
}
