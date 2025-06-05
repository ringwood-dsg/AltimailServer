// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Collections.Generic;
using System.Text;

namespace DBSetup
{
   class Globals
   {
      private static AltimailServer.Application _application;

      public static void SetApp(AltimailServer.Application application)
      {
         _application = application;
      }

      public static AltimailServer.Application GetApp()
      {
         return _application;
      }

      public static AltimailServer.eDBtype GetDatabaseType(string type)
      {
         switch (type)
         {
            case "MSSQL":
               return AltimailServer.eDBtype.hDBTypeMSSQL;
            case "MySQL":
               return AltimailServer.eDBtype.hDBTypeMySQL;
            case "PGSQL":
               return AltimailServer.eDBtype.hDBTypePostgreSQL;
            default:
               throw new Exception("Unknown database type");

         }
      }

      
   }
}
