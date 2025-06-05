// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Dialogs
{
   public partial class formSelectUsers : Form
   {
      private bool _onlyUsers;
      private int _specificDomainID;

      private List<int> _selectedIDs;
      private List<string> _selectedTexts;

      public formSelectUsers(bool onlyUsers, int specificDomainID)
      {
         InitializeComponent();

         _specificDomainID = specificDomainID;
         _onlyUsers = onlyUsers;
         _selectedIDs = null;
         _selectedTexts = null;

         FillCombos();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }

      public List<int> GetSelectedIDs()
      {
         return _selectedIDs;
      }

      public List<string> GetSelectedTexts()
      {
         return _selectedTexts;
      }


      private void FillCombos()
      {

         comboType.AddItem(EnumStrings.GetPermissionTypeString(eACLPermissionType.ePermissionTypeUser), eACLPermissionType.ePermissionTypeUser);

         if (_onlyUsers == false)
         {
            comboType.AddItem(EnumStrings.GetPermissionTypeString(eACLPermissionType.ePermissionTypeGroup), eACLPermissionType.ePermissionTypeGroup);
            comboType.AddItem(EnumStrings.GetPermissionTypeString(eACLPermissionType.ePermissionTypeAnyone), eACLPermissionType.ePermissionTypeAnyone);
         }

         comboType.SelectedIndex = 0;


         AltimailServer.Domains domains = APICreator.Application.Domains;
         string domainNames = domains.Names;
         Marshal.ReleaseComObject(domains);

         string[] rows = Microsoft.VisualBasic.Strings.Split(domainNames, "\r\n", -1, Microsoft.VisualBasic.CompareMethod.Binary);

         foreach (string row in rows)
         {
            if (string.IsNullOrEmpty(row))
               continue;

            string[] properties = Microsoft.VisualBasic.Strings.Split(row, "\t", -1, Microsoft.VisualBasic.CompareMethod.Text);

            int id = Convert.ToInt32(properties[0]);
            string name = properties[1];

            if (_specificDomainID == 0 || _specificDomainID == id)
            {
               comboDomains.AddItem(name, id);
            }
         }


         if (comboDomains.Items.Count > 0)
            comboDomains.SelectedIndex = 0;
      }

      public eACLPermissionType Type
      {
         get
         {
            eACLPermissionType permType = (eACLPermissionType)comboType.SelectedValue;
            return permType;
         }
      }

      private void ListSelectedType()
      {
         eACLPermissionType permType = (eACLPermissionType)comboType.SelectedValue;

         switch (permType)
         {
            case eACLPermissionType.ePermissionTypeUser:
               ListUsers();
               break;
            case eACLPermissionType.ePermissionTypeGroup:
               ListGroups();
               break;
            case eACLPermissionType.ePermissionTypeAnyone:
               ListAnyone();
               break;
         }
      }

      private void ListGroups()
      {
         EnableDomainsAndList(false);
         listItems.Enabled = true;

         listItems.Items.Clear();

         AltimailServer.Settings settings = APICreator.Application.Settings;
         AltimailServer.Groups groups = settings.Groups;

         for (int i = 0; i < groups.Count; i++)
         {
            AltimailServer.Group group = groups[i];

            ListViewItem item = listItems.Items.Add(group.Name);
            item.Tag = group.ID;

            Marshal.ReleaseComObject(group);
         }

         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(groups);
      }

      private void ListUsers()
      {
         EnableDomainsAndList(true);

         if (comboDomains.Items.Count == 0)
            return;

         listItems.Items.Clear();

         int domainID = Convert.ToInt32(comboDomains.SelectedValue);


         AltimailServer.Domain domain = APICreator.GetDomain(domainID);
         AltimailServer.Accounts accounts = domain.Accounts;

         for (int i = 0; i < accounts.Count; i++)
         {
            AltimailServer.Account account = accounts[i];

            ListViewItem item = listItems.Items.Add(account.Address);
            item.Tag = account.ID;

            Marshal.ReleaseComObject(account);
         }

         Marshal.ReleaseComObject(accounts);
         Marshal.ReleaseComObject(domain);

      }

      private void ListAnyone()
      {
         EnableDomainsAndList(false);
      }

      private void EnableDomainsAndList(bool enable)
      {
         comboDomains.Enabled = enable;
         listItems.Enabled = enable;

         if (enable == false)
            listItems.Items.Clear();
      }

      private void comboDomains_SelectedIndexChanged(object sender, EventArgs e)
      {
         ListSelectedType();
      }

      private void comboType_SelectedIndexChanged(object sender, EventArgs e)
      {
         ListSelectedType();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         AddSelectedUsers();

      }

      private void AddSelectedUsers()
      {
         _selectedIDs = new List<int>();
         _selectedTexts = new List<string>();
         foreach (ListViewItem item in listItems.SelectedItems)
         {
            _selectedIDs.Add(Convert.ToInt32(item.Tag));
            _selectedTexts.Add(item.Text);
         }
      }

      private void listItems_DoubleClick(object sender, EventArgs e)
      {
         AddSelectedUsers();

         this.DialogResult = DialogResult.OK;
         this.Close();
      }
   }
}