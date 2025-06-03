// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using hMailServer.Shared;
using System.Windows.Forms;

namespace hMailServer.Administrator
{
   public partial class ucUtilities : UserControl, ISettingsControl
   {
      public ucUtilities()
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
