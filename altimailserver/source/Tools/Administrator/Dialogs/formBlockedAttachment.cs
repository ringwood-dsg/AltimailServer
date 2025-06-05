// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Shared;
using System.Windows.Forms;


namespace AltimailServer.Administrator.Dialogs
{
   public partial class formBlockedAttachment : Form
   {

      public formBlockedAttachment()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }

      public void LoadProperties(AltimailServer.BlockedAttachment ba)
      {
         textDescription.Text = ba.Description;
         textWildcard.Text = ba.Wildcard;
      }

      public void SaveProperties(AltimailServer.BlockedAttachment ba)
      {
         ba.Description = textDescription.Text;
         ba.Wildcard = textWildcard.Text;
      }

   }
}