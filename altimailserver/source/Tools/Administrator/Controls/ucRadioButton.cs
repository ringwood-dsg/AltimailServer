// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Shared;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Controls
{
   public partial class ucRadioButton : RadioButton, IPropertyEditor
   {
      private bool internalChecked;

      public ucRadioButton()
      {

         internalChecked = false;
      }

      public new bool Checked
      {
         get
         {
            return base.Checked;
         }

         set
         {
            base.Checked = value;
            internalChecked = value;
         }
      }

      public bool Dirty
      {
         get
         {
            if (base.Checked != internalChecked)
               return true;
            else
               return false;

         }
      }

      public void SetClean()
      {
         internalChecked = base.Checked;
      }

   }
}

