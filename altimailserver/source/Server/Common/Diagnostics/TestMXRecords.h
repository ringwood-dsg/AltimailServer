// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

#include "DiagnosticResult.h"

namespace HM
{

   class TestMXRecords
   {
   public:
	   TestMXRecords(const String &localDomainName);
	   virtual ~TestMXRecords();

      DiagnosticResult PerformTest();

   private:

      String local_domain_name_;
   };


}
