// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

namespace hMailServer.Administrator
{
   public interface ISettingsControl
   {
      bool Dirty
      {
         get;
      }

      // Load and save the displayed data
      void LoadData();
      bool SaveData();

      // Load all translated resources
      void LoadResources();

      void OnLeavePage();
   }
}
