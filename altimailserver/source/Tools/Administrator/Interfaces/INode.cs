// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System.Collections.Generic;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public interface INode
   {
      string Title
      {
         get;
         set;
      }

      string Icon
      {
         get;
      }

      UserControl CreateControl();

      List<INode> SubNodes
      {
         get;
      }

      bool IsUserCreated
      {
         get;
      }

      System.Drawing.Color ForeColor
      {
         get;
         set;
      }

      ContextMenuStrip CreateContextMenu();
   }
}
