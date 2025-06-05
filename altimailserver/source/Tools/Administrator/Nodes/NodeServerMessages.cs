// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeServerMessages : INode
   {
      public string Title
      {
         get
         {
            return "Server messages";
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
         return new ucServerMessages();
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            AltimailServer.Settings settings = APICreator.Settings;
            AltimailServer.ServerMessages serverMessages = settings.ServerMessages;
            for (int i = 0; i < serverMessages.Count; i++)
            {
               AltimailServer.ServerMessage serverMessage = serverMessages[i];
               subNodes.Add(new NodeServerMessage(serverMessage.ID, serverMessage.Name));
               Marshal.ReleaseComObject(serverMessage);
            }

            Marshal.ReleaseComObject(serverMessages);
            Marshal.ReleaseComObject(settings);

            return subNodes;

         }
      }


      public ContextMenuStrip CreateContextMenu()
      {
         return null;
      }
   }
}
