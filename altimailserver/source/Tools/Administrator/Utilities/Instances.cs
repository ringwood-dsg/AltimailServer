// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

namespace AltimailServer.Administrator
{

   static class Instances
   {
      private static IMainForm _mainForm;

      public static IMainForm MainForm
      {
         get
         {
            return _mainForm;
         }
         set
         {
            _mainForm = value;
         }
      }
   }
}
