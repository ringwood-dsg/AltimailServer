// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucGlobalRules : UserControl, ISettingsControl
   {
      public ucGlobalRules()
      {
         InitializeComponent();

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
         AltimailServer.Rules globalRules = APICreator.Application.Rules;
         rules.LoadRules(globalRules);
      }

      public bool SaveData()
      {
         return true;
      }

      public void LoadResources()
      {
         // load the translated resources
      }
   }
}
