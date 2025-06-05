// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

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
