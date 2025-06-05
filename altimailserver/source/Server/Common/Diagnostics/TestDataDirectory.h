// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

#include "DiagnosticResult.h"

namespace HM
{

   class TestDataDirectory
   {
   public:
	   TestDataDirectory();
	   virtual ~TestDataDirectory();

      DiagnosticResult PerformTest();

   private:
   };


}
