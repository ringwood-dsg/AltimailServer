// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

namespace AltimailServer.Administrator.Utilities.Settings
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
