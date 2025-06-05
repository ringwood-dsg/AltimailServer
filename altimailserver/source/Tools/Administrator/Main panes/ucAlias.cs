// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucAlias : UserControl, ISettingsControl
   {
      private int _domainID;
      private AltimailServer.Alias representedObject = null;

      public ucAlias(int domainID, int aliasID)
      {
         InitializeComponent();

         _domainID = domainID;

         AltimailServer.Domain domain = APICreator.GetDomain(domainID);

         if (aliasID > 0)
         {
            AltimailServer.Aliases aliases = domain.Aliases;
            representedObject = aliases.get_ItemByDBID(aliasID);
            Marshal.ReleaseComObject(aliases);
         }

         textName.Text = "@" + domain.Name;
         Marshal.ReleaseComObject(domain);

         DirtyChecker.SubscribeToChange(this, OnContentChanged);

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      public void OnLeavePage()
      {
         if (representedObject != null)
            Marshal.ReleaseComObject(representedObject);
      }

      public bool Dirty
      {
         get
         {
            return DirtyChecker.IsDirty(this) &&
                   textName.Valid &&
                   textValue.Valid;
         }
      }

      public void LoadData()
      {
         if (representedObject == null)
            return;

         textName.Text = representedObject.Name;
         textValue.Text = representedObject.Value;
         checkEnabled.Checked = representedObject.Active;
      }



      public bool SaveData()
      {

         bool newObject = false;
         if (representedObject == null)
         {
            AltimailServer.Domain domain = APICreator.GetDomain(_domainID);

            AltimailServer.Aliases aliases = domain.Aliases;
            representedObject = aliases.Add();
            newObject = true;

            Marshal.ReleaseComObject(domain);
            Marshal.ReleaseComObject(aliases);
         }


         representedObject.Name = textName.Text;
         representedObject.Value = textValue.Text;
         representedObject.Active = checkEnabled.Checked;

         representedObject.Save();

         // Refresh the node in the tree if the name has changed.
         IMainForm mainForm = Instances.MainForm;
         mainForm.RefreshCurrentNode(representedObject.Name);

         // Set the object to clean.
         DirtyChecker.SetClean(this);

         if (newObject)
         {
            SearchNodeText crit = new SearchNodeText(representedObject.Name);
            mainForm.SelectNode(crit);
         }

         return true;

      }

      public void LoadResources()
      {

      }

      private void OnContentChanged()
      {
         Instances.MainForm.OnContentChanged();
      }

      private void OnContentChanged(object sender, EventArgs e)
      {
         OnContentChanged();
      }




   }
}
