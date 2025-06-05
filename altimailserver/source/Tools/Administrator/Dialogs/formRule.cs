// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Dialogs
{
   public partial class formRule : Form
   {
      private AltimailServer.Rule _rule;

      private bool _forcedDirty = false;

      public formRule(AltimailServer.Rule rule)
      {
         InitializeComponent();

         _rule = rule;

         this.DialogResult = DialogResult.None;

         LoadRuleProperties();
         ListRuleCriterias();
         ListRuleActions();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         DirtyChecker.SubscribeToChange(this, OnContentChanged);

         Strings.Localize(this);

         EnableDisable();
      }


      private void OnContentChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

      private void LoadRuleProperties()
      {
         textName.Text = _rule.Name;
         checkEnabled.Checked = _rule.Active;
         radioUseAND.Checked = _rule.UseAND;
         radioUseOR.Checked = !_rule.UseAND;
      }

      private void SaveRuleProperties()
      {
         _rule.Name = textName.Text;
         _rule.Active = checkEnabled.Checked;
         _rule.UseAND = radioUseAND.Checked;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         SaveRuleProperties();
      }

      private void buttonAddCriteria_Click(object sender, EventArgs e)
      {
         AltimailServer.RuleCriteria ruleCriteria = _rule.Criterias.Add();

         formRuleCriteria ruleCriteriaDialog = new formRuleCriteria(ruleCriteria);

         if (ruleCriteriaDialog.ShowDialog() == DialogResult.OK)
         {
            ruleCriteria.Save();

            ListRuleCriterias();

            _forcedDirty = true;
            EnableDisable();
         }

         Marshal.ReleaseComObject(ruleCriteria);

      }

      private void ListRuleCriterias()
      {
         listCriterias.Items.Clear();

         AltimailServer.RuleCriterias ruleCriterias = _rule.Criterias;
         for (int i = 0; i < ruleCriterias.Count; i++)
         {
            AltimailServer.RuleCriteria ruleCriteria = ruleCriterias[i];

            string name = null;

            if (ruleCriteria.UsePredefined)
               name = EnumStrings.GetPredefinedFieldString(ruleCriteria.PredefinedField);
            else
               name = ruleCriteria.HeaderField;

            ListViewItem listViewItem = listCriterias.Items.Add(name);
            listViewItem.SubItems.Add(EnumStrings.GetMatchTypeString(ruleCriteria.MatchType));
            listViewItem.SubItems.Add(ruleCriteria.MatchValue);

            listViewItem.Tag = ruleCriteria;

         }
      }

      private void ListRuleActions()
      {
         listActions.Items.Clear();

         AltimailServer.RuleActions ruleActions = _rule.Actions;
         for (int i = 0; i < ruleActions.Count; i++)
         {
            AltimailServer.RuleAction ruleAction = ruleActions[i];

            string name = EnumStrings.GetRuleActionString(ruleAction.Type);

            ListViewItem listViewItem = listActions.Items.Add(name);
            listViewItem.Tag = ruleAction;

         }
      }

      private void buttonEditCriteria_Click(object sender, EventArgs e)
      {
         EditSelectedCriteria();


      }

      private void EditSelectedCriteria()
      {
         if (listCriterias.SelectedItems.Count == 0)
            return;

         AltimailServer.RuleCriteria ruleCriteria = listCriterias.SelectedItems[0].Tag as AltimailServer.RuleCriteria;

         formRuleCriteria ruleCriteriaDialog = new formRuleCriteria(ruleCriteria);

         if (ruleCriteriaDialog.ShowDialog() == DialogResult.OK)
         {
            ruleCriteria.Save();

            ListRuleCriterias();

            _forcedDirty = true;
            EnableDisable();
         }
      }

      private void buttonDeleteCriteria_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listCriterias.SelectedItems)
         {
            AltimailServer.RuleCriteria ruleCriteria = item.Tag as RuleCriteria;

            ruleCriteria.Delete();
         }

         ListRuleCriterias();

         _forcedDirty = true;
         EnableDisable();
      }

      private void listCriterias_DoubleClick(object sender, EventArgs e)
      {
         EditSelectedCriteria();
      }

      private void buttonAddAction_Click(object sender, EventArgs e)
      {
         AltimailServer.RuleAction ruleAction = _rule.Actions.Add();

         formRuleAction ruleActionDialog = new formRuleAction(_rule, ruleAction);

         if (ruleActionDialog.ShowDialog() == DialogResult.OK)
         {
            ruleAction.Save();

            ListRuleActions();

            _forcedDirty = true;
            EnableDisable();
         }

      }

      private void buttonEditAction_Click(object sender, EventArgs e)
      {
         EditSelectedAction();
      }

      private void EditSelectedAction()
      {
         if (listActions.SelectedItems.Count == 0)
            return;

         AltimailServer.RuleAction ruleAction = listActions.SelectedItems[0].Tag as AltimailServer.RuleAction;
         formRuleAction ruleActionDialog = new formRuleAction(_rule, ruleAction);
         if (ruleActionDialog.ShowDialog() == DialogResult.OK)
         {
            ruleAction.Save();

            ListRuleActions();

            _forcedDirty = true;
            EnableDisable();
         }
      }

      private void listActions_DoubleClick(object sender, EventArgs e)
      {
         EditSelectedAction();
      }

      private void buttonDeleteAction_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listActions.SelectedItems)
         {
            AltimailServer.RuleAction ruleAction = item.Tag as RuleAction;

            ruleAction.Delete();
         }

         ListRuleActions();

         _forcedDirty = true;
         EnableDisable();
      }

      private void listCriterias_SelectedIndexChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

      private void listActions_SelectedIndexChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

      private void EnableDisable()
      {
         buttonEditCriteria.Enabled = listCriterias.SelectedItems.Count == 1;
         buttonDeleteCriteria.Enabled = listCriterias.SelectedItems.Count > 0;

         buttonEditAction.Enabled = listActions.SelectedItems.Count == 1;
         buttonDeleteAction.Enabled = listActions.SelectedItems.Count > 0;

         buttonMoveUp.Enabled = listActions.SelectedItems.Count == 1 && listActions.SelectedItems[0].Index > 0 && listActions.Items.Count > 1;
         buttonMoveDown.Enabled = listActions.SelectedItems.Count == 1 && listActions.SelectedItems[0].Index < listActions.Items.Count - 1 && listActions.Items.Count > 1;

         btnOK.Enabled = (DirtyChecker.IsDirty(this) || _forcedDirty) && textName.Text.Length > 0;
      }

      private void buttonMoveUp_Click(object sender, EventArgs e)
      {
         if (listActions.SelectedItems.Count != 1)
            return;

         AltimailServer.RuleAction action = listActions.SelectedItems[0].Tag as AltimailServer.RuleAction;
         action.MoveUp();

         ListRuleActions();

         _forcedDirty = true;
         EnableDisable();
      }

      private void buttonMoveDown_Click(object sender, EventArgs e)
      {
         if (listActions.SelectedItems.Count != 1)
            return;

         AltimailServer.RuleAction action = listActions.SelectedItems[0].Tag as AltimailServer.RuleAction;
         action.MoveDown();

         ListRuleActions();

         _forcedDirty = true;
         EnableDisable();
      }

      private void formRule_Load(object sender, EventArgs e)
      {

      }

   }
}