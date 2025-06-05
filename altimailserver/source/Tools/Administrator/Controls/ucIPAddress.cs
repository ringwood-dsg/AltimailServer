// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Shared;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Controls
{
   public partial class ucIPAddress : TextBox, IPropertyEditor
   {
      private string internalText;

      public ucIPAddress()
      {
         internalText = "";
      }

      public new string Text
      {
         get
         {
            return base.Text;
         }

         set
         {
            internalText = value;
            base.Text = value;
         }
      }

      public void Validate()
      {
         if (internalText.Length == 0)
         {
            // TODO: Show message.  
         }
      }

      public bool Dirty
      {
         get
         {
            if (this.Text != internalText)
               return true;
            else
               return false;

         }
      }

      public void SetClean()
      {
         internalText = this.Text;
      }


   }
}
