// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Dialogs;
using AltimailServer.Administrator.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   class NodeAccounts : INode
   {
      private int _domainID;

      public NodeAccounts(int domainID)
      {
         _domainID = domainID;
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
            return "Accounts";
         }
         set { }
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
         return new ucAccounts(_domainID);
      }

      public List<INode> SubNodes
      {
         get
         {
            List<INode> subNodes = new List<INode>();

            AltimailServer.Domain domain = APICreator.GetDomain(_domainID);

            AltimailServer.Accounts accounts = domain.Accounts;

            for (int i = 0; i < accounts.Count; i++)
            {
               AltimailServer.Account account = accounts[i];

               subNodes.Add(new NodeAccount(domain.ID, account.Address, account.ID));

               Marshal.ReleaseComObject(account);
            }

            Marshal.ReleaseComObject(domain);
            Marshal.ReleaseComObject(accounts);

            return subNodes;

         }
      }

      public ContextMenuStrip CreateContextMenu()
      {
         ContextMenuStrip menu = new ContextMenuStrip();
         ToolStripItem itemAdd = menu.Items.Add(Strings.Localize("Add..."));
         itemAdd.Click += new EventHandler(OnAddAccount);

         ToolStripItem itemAdd2 = menu.Items.Add(Strings.Localize("Add AD account"));
         itemAdd2.Click += new EventHandler(OnAddADAccount);

         return menu;
      }

      internal void OnAddAccount(object sender, EventArgs e)
      {
         NodeAccount newAccountNode = new NodeAccount(_domainID, "", 0);
         Instances.MainForm.ShowItem(newAccountNode);
      }

      internal void OnAddADAccount(object sender, EventArgs e)
      {
         formActiveDirectoryAccounts accountsDlg = new formActiveDirectoryAccounts();
         if (accountsDlg.ShowDialog() == DialogResult.OK)
         {
            AltimailServer.Domain domain = APICreator.GetDomain(_domainID);
            AltimailServer.Accounts accounts = domain.Accounts;

            Instances.MainForm.Cursor = Cursors.WaitCursor;

            string domainName = accountsDlg.DomainName;
            List<string> accountNames = accountsDlg.AccountNames;

            foreach (string accountName in accountNames)
            {
               try
               {
                  AltimailServer.Account account = accounts.Add();

                  account.IsAD = true;
                  account.ADDomain = domainName;
                  account.ADUsername = accountName;
                  account.Active = true;

                  string address = accountName;
                  address = address.Replace(" ", ".");
                  address = address + "@" + domain.Name;
                  account.Address = address;

                  account.Save();

                  Marshal.ReleaseComObject(account);
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message, EnumStrings.hMailServerAdministrator);
               }

            }

            Marshal.ReleaseComObject(domain);
            Marshal.ReleaseComObject(accounts);

            Instances.MainForm.Cursor = Cursors.Default;
         }

         IMainForm mainForm = Instances.MainForm;
         mainForm.RefreshCurrentNode(null);

         mainForm.ShowItem(mainForm.GetCurrentNode());
      }
   }
}
