// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using System.Collections.Generic;

namespace hMailServer.Administrator.Utilities.Settings
{
   public class Servers
   {
      private List<Server> listServers;

      public Servers()
      {
         listServers = new List<Server>();
      }

      public List<Server> List
      {
         get
         {
            return listServers;
         }
         set
         {
            listServers = value;
         }
      }


   }
}
