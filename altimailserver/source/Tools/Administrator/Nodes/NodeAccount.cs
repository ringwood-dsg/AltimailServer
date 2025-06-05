// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeAccount : INode
   {
      private int _domainID;
      private int _accountID;
      private string _accountName;

      public NodeAccount(int domainID, string accountName, int accountID)
      {
         _domainID = domainID;
         _accountName = accountName;
         _accountID = accountID;
      }


      public System.Drawing.Color ForeColor { get { return System.Drawing.SystemColors.WindowText; } set { } }

      public bool IsUserCreated
      {
         get { return true; }
      }

      public string Title
      {
         get
         {
            return _accountName;
         }
         set
         {
            _accountName = value;
         }
      }

      public string Icon
      {
         get
         {
            return "user.ico";
         }
      }

      public UserControl CreateControl()
      {
         return new ucAccount(_domainID, _accountID);
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
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Remove"));
         itemAdd.Click += OnDeleteAccount;

         return menu;
      }

      public void OnDeleteAccount(object sender, EventArgs args)
      {
         // Delete the domain.
         AltimailServer.Links links = APICreator.Links;
         AltimailServer.Account account = links.get_Account(_accountID);

         if (Utility.AskDeleteItem(account.Address))
         {
            account.Delete();

            Marshal.ReleaseComObject(links);
            Marshal.ReleaseComObject(account);

            Instances.MainForm.RefreshParentNode();
         }
      }
   }
}
