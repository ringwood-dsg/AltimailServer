// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

#include "Macro.h"

namespace HM
{
   class MacroParser
   {
   public:
	   MacroParser(const String &macro);
	   virtual ~MacroParser();

      Macro Parse();

   private:

      String macro_string_;
   };
}
