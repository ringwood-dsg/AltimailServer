// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Shared;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Dialogs
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