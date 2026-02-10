// Modified, Juan Davel/ringwood-dsg, 2025/06/08
// https://altimailserver.org
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System;
using System.Collections.Generic;
using System.Text;

namespace AltimailServer.Shared
{
   [Obsolete("We are using the Open-Source AeroWizard to make it more modern.")]
   public interface IWizardPage
   {
      void OnShowPage(Dictionary<string, string> _state);
      bool OnLeavePage(bool next);
      string Title { get; }

   }

}
