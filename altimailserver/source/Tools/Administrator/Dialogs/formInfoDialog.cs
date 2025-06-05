// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System.Windows.Forms;

namespace AltimailServer.Administrator.Dialogs
{
   public partial class formInfoDialog : Form
   {
      public formInfoDialog()
      {
         InitializeComponent();
         Strings.Localize(this);
      }

      public string Title
      {
         set
         {
            this.Text = value;
            Strings.Localize(this);
         }
         get
         {
            return this.Text;
         }
      }

      public string Message
      {
         set
         {
            textMessage.Text = value;
            Strings.Localize(this);
         }
         get
         {
            return textMessage.Text;
         }
      }
   }
}