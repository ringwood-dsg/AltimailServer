// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Dialogs
{
   public partial class formRuleAction : Form
   {
      private AltimailServer.RuleAction _ruleAction;
      private bool _isAccountLevelRule = false;

      public formRuleAction(AltimailServer.Rule rule, AltimailServer.RuleAction ruleAction)
      {
         InitializeComponent();

         _ruleAction = ruleAction;
         _isAccountLevelRule = rule.AccountID > 0;

         FillCombo();

         LoadProperties();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }

      private void FillCombo()
      {
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRADeleteEmail), eRuleActionType.eRADeleteEmail);
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRAForwardEmail), eRuleActionType.eRAForwardEmail);
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRAMoveToImapFolder), eRuleActionType.eRAMoveToImapFolder);
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRAReply), eRuleActionType.eRAReply);
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRARunScriptFunction), eRuleActionType.eRARunScriptFunction);
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRASetHeaderValue), eRuleActionType.eRASetHeaderValue);
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRAStopRuleProcessing), eRuleActionType.eRAStopRuleProcessing);
         comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRACreateCopy), eRuleActionType.eRACreateCopy);


         if (_isAccountLevelRule == false)
         {
            comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRABindToAddress), eRuleActionType.eRABindToAddress);
            comboAction.AddItem(EnumStrings.GetRuleActionString(eRuleActionType.eRASendUsingRoute), eRuleActionType.eRASendUsingRoute);
         }


         comboAction.SelectedIndex = 0;

         // Fill routes
         comboRouteName.AddItem("None", 0);

         AltimailServer.Settings settings = APICreator.Application.Settings;
         AltimailServer.Routes routes = settings.Routes;

         for (int i = 0; i < routes.Count; i++)
         {
            AltimailServer.Route route = routes[i];

            comboRouteName.AddItem(route.DomainName, route.ID);

            Marshal.ReleaseComObject(route);
         }
         comboRouteName.SelectedIndex = 0;
         Marshal.ReleaseComObject(routes);
      }

      private void LoadProperties()
      {
         textForwardTo.Text = _ruleAction.To;
         textIMAPFolder.Text = _ruleAction.IMAPFolder;

         txtActionScriptFunction.Text = _ruleAction.ScriptFunction;

         textActionFromName.Text = _ruleAction.FromName;
         textActionFromAddress.Text = _ruleAction.FromAddress;
         textActionSubject.Text = _ruleAction.Subject;
         textActionBody.Text = _ruleAction.Body;

         textHeaderName.Text = _ruleAction.HeaderName;

         if (_ruleAction.Type == eRuleActionType.eRASetHeaderValue)
            textHeaderValue.Text = _ruleAction.Value;
         else if (_ruleAction.Type == eRuleActionType.eRABindToAddress)
            textBindToAddress.Text = _ruleAction.Value;

         if (_ruleAction.Type == eRuleActionType.eRAForwardEmail)
            checkForwardAbortSpamFlagged.Checked = _ruleAction.AbortSpamFlagged;
         else if (_ruleAction.Type == eRuleActionType.eRAReply)
            checkReplyAbortSpamFlagged.Checked = _ruleAction.AbortSpamFlagged;

         comboAction.SelectedValue = _ruleAction.Type;
         comboRouteName.SelectedValue = _ruleAction.RouteID;
      }

      private void SaveProperties()
      {
         var ruleActionType = (eRuleActionType)comboAction.SelectedValue;

         _ruleAction.To = textForwardTo.Text;
         _ruleAction.IMAPFolder = textIMAPFolder.Text;

         _ruleAction.ScriptFunction = txtActionScriptFunction.Text;

         _ruleAction.FromName = textActionFromName.Text;
         _ruleAction.FromAddress = textActionFromAddress.Text;
         _ruleAction.Subject = textActionSubject.Text;
         _ruleAction.Body = textActionBody.Text;

         _ruleAction.HeaderName = textHeaderName.Text;

         switch (ruleActionType)
         {
            case eRuleActionType.eRASetHeaderValue:
               _ruleAction.Value = textHeaderValue.Text;
               break;
            case eRuleActionType.eRABindToAddress:
               _ruleAction.Value = textBindToAddress.Text;
               break;
            case eRuleActionType.eRAForwardEmail:
               _ruleAction.AbortSpamFlagged = checkForwardAbortSpamFlagged.Checked;
               break;
            case eRuleActionType.eRAReply:
               _ruleAction.AbortSpamFlagged = checkReplyAbortSpamFlagged.Checked;
               break;
         }

         _ruleAction.RouteID = (int)comboRouteName.SelectedValue;

         _ruleAction.Type = ruleActionType;

      }

      private bool ValidateForm()
      {
         char delimiter = APICreator.Settings.IMAPHierarchyDelimiter[0];

         List<char> delimitors = new List<char>();
         delimitors.Add('.');
         delimitors.Add('\\');
         delimitors.Add('/');
         delimitors.Remove(delimiter);

         if ((eRuleActionType)comboAction.SelectedValue == eRuleActionType.eRAMoveToImapFolder)
         {
            foreach (char otherDelim in delimitors)
            {
               if (textIMAPFolder.Text.Contains(otherDelim.ToString()))
               {
                  string message = "The hMailServer IMAP hierarchy delimiter is %S1. The folder name you have specified contains the character %S2 which is not a hierarchy delimiter but may be a part of a folder name. If you choose to save the current folder name, a single folder named %S3 will be created when this action is executed. Do you want to use this folder name?";

                  message = message.Replace("%S1", "\"" + delimiter.ToString() + "\"");
                  message = message.Replace("%S2", "\"" + otherDelim.ToString() + "\"");
                  message = message.Replace("%S3", "\"" + textIMAPFolder.Text + "\"");

                  if (MessageBox.Show(message, EnumStrings.hMailServerAdministrator, MessageBoxButtons.YesNo) == DialogResult.No)
                     return false;

                  break;
               }
            }
         }

         return true;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if (!ValidateForm())
            return;

         SaveProperties();

         this.DialogResult = DialogResult.OK;

         this.Close();
      }

      private void comboAction_SelectedIndexChanged(object sender, EventArgs e)
      {
         eRuleActionType ra = (eRuleActionType)comboAction.SelectedValue;

         panelForward.Visible = false;
         panelIMAP.Visible = false;
         panelScriptFunction.Visible = false;
         panelReply.Visible = false;
         panelSetHeaderValue.Visible = false;
         panelSendUsingRoute.Visible = false;
         panelBindToAddress.Visible = false;

         Panel panelToShow = null;

         switch (ra)
         {
            case eRuleActionType.eRADeleteEmail:
            case eRuleActionType.eRACreateCopy:
               break;
            case eRuleActionType.eRAForwardEmail:
               panelToShow = panelForward;
               break;
            case eRuleActionType.eRAMoveToImapFolder:
               panelToShow = panelIMAP;
               break;
            case eRuleActionType.eRAReply:
               panelToShow = panelReply;
               break;
            case eRuleActionType.eRARunScriptFunction:
               panelToShow = panelScriptFunction;
               break;
            case eRuleActionType.eRASetHeaderValue:
               panelToShow = panelSetHeaderValue;
               break;
            case eRuleActionType.eRASendUsingRoute:
               panelToShow = panelSendUsingRoute;
               break;
            case eRuleActionType.eRAStopRuleProcessing:
               break;
            case eRuleActionType.eRABindToAddress:
               panelToShow = panelBindToAddress;
               break;
            case eRuleActionType.eRAUnknown:
               break;
         }

         if (panelToShow != null)
         {
            panelToShow.Location = new Point(7, 34);
            panelToShow.Visible = true;

         }
      }

      private void label2_Click(object sender, EventArgs e)
      {

      }

      private void formRuleAction_Load(object sender, EventArgs e)
      {

      }
   }
}