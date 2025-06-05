// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

namespace VMwareIntegration.Common
{
   public class FileCopyCommand
   {
      private string _from;
      private string _to;

      public FileCopyCommand(string fromHost, string toGuest)
      {
         _from = fromHost;
         _to = toGuest;
      }

      public string From
      {
         get
         {
            return _from;
         }
      }

      public string To
      {
         get
         {
            return _to;
         }
      }
   }
}
