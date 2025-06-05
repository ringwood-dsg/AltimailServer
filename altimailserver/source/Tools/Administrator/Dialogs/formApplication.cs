// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class formApplication : Form
   {
      public formApplication()
      {
         InitializeComponent();
         Strings.Localize(this);
      }

      private void formApplication_Load(object sender, EventArgs e)
      {

      }


   }
}