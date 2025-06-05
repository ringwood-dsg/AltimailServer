using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class ucServerMessage : UserControl, ISettingsControl
   {
      AltimailServer.ServerMessage _representedObject;

      public ucServerMessage(int serverMessageID)
      {
         InitializeComponent();

         AltimailServer.Settings settings = APICreator.Settings;
         AltimailServer.ServerMessages serverMessages = settings.ServerMessages;
         _representedObject = serverMessages.get_ItemByDBID(serverMessageID);
         Marshal.ReleaseComObject(settings);
         Marshal.ReleaseComObject(serverMessages);

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


         textMessage.Text = _representedObject.Text;
      }

      public bool SaveData()
      {
         _representedObject.Text = textMessage.Text;

         _representedObject.Save();

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
