// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using hMailServer.Shared;
using System;
using System.Windows.Forms;

namespace hMailServer.Administrator.Controls
{
   public partial class ucDateTimePicker : DateTimePicker, IPropertyEditor
   {
      private DateTime internalValue;

      public ucDateTimePicker()
      {

      }

      public new DateTime Value
      {
         get
         {
            return base.Value;
         }

         set
         {
            base.Value = value;
            internalValue = value;
         }
      }

      public string FormattedValue
      {
         get
         {
            return base.Value.ToString("yyyy-MM-dd");
         }
      }

      public bool Dirty
      {
         get
         {
            if (base.Value != internalValue)
               return true;
            else
               return false;

         }
      }

      public void SetClean()
      {
         internalValue = base.Value;
      }

   }
}
