// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Collections.Generic;
using System.Text;

namespace AltimailServer.Shared
{
   public interface IWizardPage
   {
      void OnShowPage(Dictionary<string, string> _state);
      bool OnLeavePage(bool next);
      string Title { get; }

   }

}
