// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Shared;
using System;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Dialogs
{
   public partial class formAccountFolders : Form
   {
      public formAccountFolders(AltimailServer.IMAPFolders imapFolders, bool publicFolders)
      {
         InitializeComponent();

         ucIMAPFolders1.LoadProperties(imapFolders, publicFolders);

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

         Strings.Localize(this.buttonClose);
         this.Text = Strings.Localize(this.Text);
         ucIMAPFolders1.Localize();
      }

      private void buttonClose_Click(object sender, EventArgs e)
      {
         if (ucIMAPFolders1.SaveCurrentFolder())
         {
            this.Close();
         }
      }
   }
}