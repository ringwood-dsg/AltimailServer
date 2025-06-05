// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeScripts : INode
   {
      public string Title
      {
         get
         {
            return "Scripts";
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
            return "source_code.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucScripts();
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
