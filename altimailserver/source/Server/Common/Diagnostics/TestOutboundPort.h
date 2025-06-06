// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

#include "DiagnosticResult.h"

namespace HM
{

   class TestOutboundPort
   {
   public:
	   TestOutboundPort(const String &TestDomainName);
	   virtual ~TestOutboundPort();

      DiagnosticResult PerformTest();

   private:

      String local_test_domain_name_;

   };


}
