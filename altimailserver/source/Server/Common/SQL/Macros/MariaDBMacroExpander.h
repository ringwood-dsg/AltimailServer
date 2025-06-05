// (c) 2025 Ringwood Digital Solutions Group (Pty) Ltd.
// https://www.ringwoodgroup.co.za

#pragma once

#include "IMacroExpander.h"

namespace HM
{
   class Macro;

   class MariaDBMacroExpander : public IMacroExpander
   {
   public:

      bool ProcessMacro(std::shared_ptr<DALConnection> connection, const Macro &macro, String &sErrorMessage);

   private:
   };
}
