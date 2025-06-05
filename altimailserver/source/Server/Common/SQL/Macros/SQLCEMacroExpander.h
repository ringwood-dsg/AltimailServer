// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

#include "IMacroExpander.h"

namespace HM
{
   class Macro;

   class SQLCEMacroExpander : public IMacroExpander
   {
   public:

      bool ProcessMacro(std::shared_ptr<DALConnection> connection, const Macro &macro, String &sErrorMessage);

   private:
   };
}
