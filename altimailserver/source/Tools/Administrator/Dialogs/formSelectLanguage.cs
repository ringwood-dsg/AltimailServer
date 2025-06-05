// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Administrator.Utilities;
using AltimailServer.Shared;
using System;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class formSelectLanguage : Form
   {
      private string _language;

      public string Language
      {
         get
         {
            return _language;
         }
      }
      public formSelectLanguage(string language)
      {
         InitializeComponent();

         _language = language;

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);

         AltimailServer.Languages languages = APICreator.Application.GlobalObjects.Languages;
         for (int i = 0; i < languages.Count; i++)
         {
            AltimailServer.Language lang = languages[i];

            comboLanguage.AddItem(lang.Name, lang);
         }

         comboLanguage.Text = _language;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         _language = comboLanguage.Text;
      }
   }
}