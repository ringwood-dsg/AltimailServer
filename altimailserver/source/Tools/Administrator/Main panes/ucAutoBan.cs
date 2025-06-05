﻿// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucAutoBan : UserControl, ISettingsControl
   {
      public ucAutoBan()
      {
         InitializeComponent();

         DirtyChecker.SubscribeToChange(this, OnContentChanged);

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      public void OnLeavePage()
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

      public bool Dirty
      {
         get
         {
            return DirtyChecker.IsDirty(this);
         }
      }

      public void LoadData()
      {
         AltimailServer.Settings settings = APICreator.Application.Settings;

         checkAutoBanOnLogonFailure.Checked = settings.AutoBanOnLogonFailure;
         textMaxInvalidLogonAttempts.Number = settings.MaxInvalidLogonAttempts;
         textMaxInvalidLogonAttemptsWithin.Number = settings.MaxInvalidLogonAttemptsWithin;
         textAutoBanMinutes.Number = settings.AutoBanMinutes;

         EnableDisable();

         Marshal.ReleaseComObject(settings);
      }

      private void EnableDisable()
      {
         textAutoBanMinutes.Enabled = checkAutoBanOnLogonFailure.Checked;
         textMaxInvalidLogonAttempts.Enabled = checkAutoBanOnLogonFailure.Checked;
         textMaxInvalidLogonAttemptsWithin.Enabled = checkAutoBanOnLogonFailure.Checked;
      }

      public bool SaveData()
      {
         AltimailServer.Settings settings = APICreator.Application.Settings;

         settings.AutoBanOnLogonFailure = checkAutoBanOnLogonFailure.Checked;
         settings.MaxInvalidLogonAttempts = textMaxInvalidLogonAttempts.Number;
         settings.MaxInvalidLogonAttemptsWithin = textMaxInvalidLogonAttemptsWithin.Number;
         settings.AutoBanMinutes = textAutoBanMinutes.Number;

         DirtyChecker.SetClean(this);

         Marshal.ReleaseComObject(settings);

         return true;

      }

      public void LoadResources()
      {
         // load the translated resources
      }

      private void checkAutoBanOnLogonFailure_CheckedChanged(object sender, EventArgs e)
      {
         EnableDisable();
      }

      private void linkMoreDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         try
         {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "http://www.AltimailServer.com/documentation/?page=reference_autoban";
            process.StartInfo.UseShellExecute = true;
            process.Start();
         }
         catch (Exception err)
         {
            MessageBox.Show(err.Message, EnumStrings.hMailServerAdministrator);
         }
      }

   }
}
