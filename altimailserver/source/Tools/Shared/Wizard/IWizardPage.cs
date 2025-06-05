// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

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
