// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Collections.Generic;
using System.Text;

namespace DataDirectorySynchronizer
{
   class Globals
   {
      public enum ModeType
      {
         Import = 1,
         Delete = 2
      };

      public const string AllDomains = "All domains";

      public static ModeType Mode { get; set; }
      public static List<string> SelectedDomains { get; set; }

      private static AltimailServer.Application _application;

      static Globals()
      {
         SelectedDomains = new List<string>();
      }

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
