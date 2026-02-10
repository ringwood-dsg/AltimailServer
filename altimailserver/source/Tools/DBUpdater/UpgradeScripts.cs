// Modified, Juan Davel/ringwood-dsg, 2025/06/08
// https://altimailserver.org
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System.Collections.Generic;

namespace DBUpdater
{
   class UpgradeScripts
   {
      List<UpgradeScript> _upgradeScripts;

      public UpgradeScripts()
      {
         _upgradeScripts = new List<UpgradeScript>();
      }

      public void Add(UpgradeScript script)
      {
         _upgradeScripts.Add(script);
      }

      public List<UpgradeScript> GetList()
      {
         return _upgradeScripts;
      }

      public UpgradeScript GetScriptUpgradingFrom(int from)
      {
         foreach (UpgradeScript script in _upgradeScripts)
         {
            if (script.From == from)
               return script;
         }

         return null;
      }
   }
}