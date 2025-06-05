// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System.Windows.Forms;

namespace AltimailServer.Administrator.Utilities
{
   internal class FocusChanger
   {
      public static void SetFocus(Control.ControlCollection controls)
      {
         if (controls.Count == 0)
            return;

         Control topMost = controls[0];
         foreach (Control control in controls)
         {
            if (control.GetType().ToString() == "System.Windows.Forms.Label")
               continue;

            if (control.Top < topMost.Top)
            {
               topMost = control;
            }
         }

         topMost.Focus();

      }
   }
}
