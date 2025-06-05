// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

#include "DiagnosticResult.h"

namespace HM
{

   class TestIPRanges
   {
   public:
	   TestIPRanges();
	   virtual ~TestIPRanges();

      DiagnosticResult PerformTest();

   private:
   };


}
