// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucMirror : UserControl, ISettingsControl
   {
      public ucMirror()
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

      public void LoadData()
      {
         AltimailServer.Application app = APICreator.Application;

         AltimailServer.Settings settings = app.Settings;
         textMirrorAddress.Text = settings.MirrorEMailAddress;


         Marshal.ReleaseComObject(settings);
      }

      public bool SaveData()
      {
         AltimailServer.Application app = APICreator.Application;

         AltimailServer.Settings settings = app.Settings;
         settings.MirrorEMailAddress = textMirrorAddress.Text;

         Marshal.ReleaseComObject(settings);

         DirtyChecker.SetClean(this);
         return true;

      }

      public void LoadResources()
      {
         // load the translated resources
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
