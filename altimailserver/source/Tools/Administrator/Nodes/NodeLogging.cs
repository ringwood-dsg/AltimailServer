// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeLogging : INode
   {
      public string Title
      {
         get
         {
            return "Logging";
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
            return "directory_listing.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucLogging();
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
         return null;
      }
   }
}
