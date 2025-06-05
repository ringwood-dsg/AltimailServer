// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AltimailServer.Shared;


namespace DBSetup.Pages
{
   public partial class ucWelcome : UserControl, IWizardPage
   {
      private Dictionary<string, string> _state;

      public ucWelcome()
      {
         InitializeComponent();
      }

      public string Title
      {
         get
         {
            return "Welcome";
         }
      }

      public void OnShowPage(Dictionary<string, string> state)
      {
         _state = state;
      }

      public bool OnLeavePage(bool next)
      {


         return true;
      }
   }
}
