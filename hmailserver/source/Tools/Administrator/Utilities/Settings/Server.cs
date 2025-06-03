// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

namespace hMailServer.Administrator.Utilities.Settings
{
   public class Server
   {
      public string hostName;
      public string userName;
      public string encryptedPassword;
      public bool savePassword;

      public Server()
      {
         hostName = "";
         userName = "";
         encryptedPassword = "";
         savePassword = false;
      }
   }
}
