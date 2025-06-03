// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using hMailServer.Shared;
using System.Windows.Forms;

namespace hMailServer.Administrator.Dialogs
{
   public partial class formUserAccounts : Form
   {
      public formUserAccounts()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }
   }
}