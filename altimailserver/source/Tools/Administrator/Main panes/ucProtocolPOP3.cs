// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucProtocolPOP3 : UserControl, ISettingsControl
   {
      public ucProtocolPOP3()
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

         textMaxPOP3Connections.Number = settings.MaxPOP3Connections;
         textWelcomeMessage.Text = settings.WelcomePOP3;

         Marshal.ReleaseComObject(settings);
      }

      public bool SaveData()
      {
         AltimailServer.Settings settings = APICreator.Application.Settings;

         settings.MaxPOP3Connections = textMaxPOP3Connections.Number;
         settings.WelcomePOP3 = textWelcomeMessage.Text;

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
