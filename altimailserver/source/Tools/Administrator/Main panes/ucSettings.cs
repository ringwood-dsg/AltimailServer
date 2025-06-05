// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Shared;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucSettings : UserControl, ISettingsControl
   {
      public ucSettings()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
      }

      public void OnLeavePage()
      {

      }

      public bool Dirty
      {
         get { return false; }
      }

      public void LoadData()
      {
         // nothing to load
      }

      public bool SaveData()
      {
         // nothing to save
         return true;
      }

      public void LoadResources()
      {
         // load the translated resources
      }
   }
}
