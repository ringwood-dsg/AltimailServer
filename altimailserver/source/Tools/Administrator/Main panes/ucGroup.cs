// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Dialogs;
using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucGroup : UserControl, ISettingsControl
   {
      private AltimailServer.Group representedObject;

      public ucGroup(int groupID)
      {
         InitializeComponent();

         if (groupID > 0)
         {
            AltimailServer.Groups groups = APICreator.Groups;
            representedObject = groups.get_ItemByDBID(groupID);
            Marshal.ReleaseComObject(groups);
         }

         DirtyChecker.SubscribeToChange(this, OnContentChanged);
         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         EnableDisable();
      }

      public void OnLeavePage()
      {

      }

      public bool Dirty
      {
         get
         {
            return DirtyChecker.IsDirty(this) &&
                   textName.Text.Length > 0;
         }
      }

      private void OnContentChanged()
      {
         Instances.MainForm.OnContentChanged();
      }

      private void OnContentChanged(object sender, EventArgs e)
      {
         OnContentChanged();
      }

      public void LoadData()
      {
         if (representedObject == null)
            return;

         textName.Text = representedObject.Name;

         ListGroupMembers();
      }

      private void ListGroupMembers()
      {
         listMembers.Items.Clear();

         AltimailServer.GroupMembers members = representedObject.Members;

         for (int i = 0; i < members.Count; i++)
         {
            AltimailServer.GroupMember member = members[i];

            try
            {
               AltimailServer.Account account = member.Account;
               ListViewItem item = listMembers.Items.Add(account.Address);
               item.Tag = member.ID;

               Marshal.ReleaseComObject(account);

            }
            catch (Exception)
            {
               ListViewItem item = listMembers.Items.Add("Unknown");
               item.Tag = member.ID;
            }

            Marshal.ReleaseComObject(member);

         }

         Marshal.ReleaseComObject(members);
      }

      public bool SaveData()
      {
         bool newObject = false;
         if (representedObject == null)
         {
            AltimailServer.Settings settings = APICreator.Application.Settings;
            AltimailServer.Groups groups = settings.Groups;
            representedObject = groups.Add();

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(groups);

            newObject = true;
         }

         representedObject.Name = textName.Text;

         representedObject.Save();

         // Refresh the node in the tree if the name has changed.
         IMainForm mainForm = Instances.MainForm;
         mainForm.RefreshCurrentNode(textName.Text);

         // Set the object to clean.
         DirtyChecker.SetClean(this);

         if (newObject)
         {
            SearchNodeText crit = new SearchNodeText(representedObject.Name);
            mainForm.SelectNode(crit);
         }

         EnableDisable();

         return true;
      }

      public void LoadResources()
      {

      }

      private void buttonSelect_Click(object sender, EventArgs e)
      {
         formSelectUsers selectUsers = new formSelectUsers(true, 0);

         if (selectUsers.ShowDialog() == DialogResult.OK)
         {
            AltimailServer.GroupMembers members = representedObject.Members;

            List<int> listUsers = selectUsers.GetSelectedIDs();

            foreach (int userID in listUsers)
            {
               AltimailServer.GroupMember member = members.Add();
               member.AccountID = userID;
               member.Save();

               Marshal.ReleaseComObject(member);
            }

            Marshal.ReleaseComObject(members);

            ListGroupMembers();
         }



      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         AltimailServer.GroupMembers members = representedObject.Members;

         foreach (ListViewItem item in listMembers.SelectedItems)
         {
            int id = Convert.ToInt32(item.Tag);
            members.DeleteByDBID(id);
         }

         Marshal.ReleaseComObject(members);

         ListGroupMembers();
      }

      private void EnableDisable()
      {
         buttonDelete.Enabled = listMembers.SelectedItems.Count > 0;
         buttonSelect.Enabled = representedObject != null;
      }

      private void listMembers_SelectedIndexChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

      private void textName_Load(object sender, EventArgs e)
      {

      }

   }
}
