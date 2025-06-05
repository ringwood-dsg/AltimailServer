// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Nodes;
using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucDNSBlackList : UserControl, ISettingsControl
   {
      private AltimailServer.DNSBlackList _representedObject;

      public ucDNSBlackList(int dnsBlackListID)
      {
         InitializeComponent();

         if (dnsBlackListID > 0)
         {
            AltimailServer.DNSBlackLists dnsBlackLists = APICreator.DNSBlackLists;
            _representedObject = dnsBlackLists.get_ItemByDBID(dnsBlackListID);
         }

         DirtyChecker.SubscribeToChange(this, OnContentChanged);
         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

         checkEnabled.Checked = true;

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
                   textDNSHost.Text.Length > 0;
         }
      }

      public void LoadData()
      {
         if (_representedObject == null)
            return;

         checkEnabled.Checked = _representedObject.Active;

         textDNSHost.Text = _representedObject.DNSHost;
         textExpectedResult.Text = _representedObject.ExpectedResult;
         textRejectionMessage.Text = _representedObject.RejectMessage;
         textSpamScore.Number = _representedObject.Score;

         EnableDisable();
      }

      public bool SaveData()
      {
         bool newObject = false;
         if (_representedObject == null)
         {
            AltimailServer.Settings settings = APICreator.Application.Settings;
            AltimailServer.AntiSpam antiSpam = settings.AntiSpam;
            AltimailServer.DNSBlackLists dnsBlackLists = antiSpam.DNSBlackLists;

            _representedObject = dnsBlackLists.Add();
            newObject = true;

            Marshal.ReleaseComObject(settings);
            Marshal.ReleaseComObject(antiSpam);
            Marshal.ReleaseComObject(dnsBlackLists);
         }

         _representedObject.Active = checkEnabled.Checked;

         _representedObject.DNSHost = textDNSHost.Text;
         _representedObject.ExpectedResult = textExpectedResult.Text;
         _representedObject.RejectMessage = textRejectionMessage.Text;
         _representedObject.Score = textSpamScore.Number;

         _representedObject.Save();


         // Refresh the node in the tree if the name has changed.
         IMainForm mainForm = Instances.MainForm;
         mainForm.RefreshCurrentNode(_representedObject.DNSHost);

         // Set the object to clean.
         DirtyChecker.SetClean(this);

         if (newObject)
         {
            SearchNodeText crit = new SearchNodeText(_representedObject.DNSHost);
            mainForm.SelectNode(crit);
         }

         return true;
      }

      public void LoadResources()
      {
         // load the translated resources
      }

      private void checkEnabled_CheckedChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

      private void EnableDisable()
      {
         textDNSHost.Enabled = checkEnabled.Checked;
         textRejectionMessage.Enabled = checkEnabled.Checked;
         textSpamScore.Enabled = checkEnabled.Checked;
         textExpectedResult.Enabled = checkEnabled.Checked;
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
