// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucProtocols : UserControl, ISettingsControl
   {
      public ucProtocols()
      {
         InitializeComponent();

         DirtyChecker.SubscribeToChange(this, OnContentChanged);

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      public void OnLeavePage()
      {

      }

      public bool Dirty
      {
         get
         {
            return DirtyChecker.IsDirty(this);
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
         AltimailServer.Application app = APICreator.Application;

         AltimailServer.Settings settings = app.Settings;
         checkSMTP.Checked = settings.ServiceSMTP;
         checkPOP3.Checked = settings.ServicePOP3;
         checkIMAP.Checked = settings.ServiceIMAP;

         Marshal.ReleaseComObject(settings);
      }

      public bool SaveData()
      {
         AltimailServer.Settings settings = APICreator.Application.Settings;
         settings.ServiceSMTP = checkSMTP.Checked;
         settings.ServicePOP3 = checkPOP3.Checked;
         settings.ServiceIMAP = checkIMAP.Checked;

         DirtyChecker.SetClean(this);

         Marshal.ReleaseComObject(settings);

         return true;
      }

      public void LoadResources()
      {
         // load the translated resources
      }
   }
}
