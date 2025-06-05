// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

#include "DiagnosticResult.h"

namespace HM
{

   class TestInformationGatherer
   {
   public:
	   TestInformationGatherer();
	   virtual ~TestInformationGatherer();

      DiagnosticResult PerformTest();

   };


}
