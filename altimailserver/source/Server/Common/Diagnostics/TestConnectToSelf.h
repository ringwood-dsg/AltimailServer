// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

#include "DiagnosticResult.h"

namespace HM
{

   class TestConnectToSelf
   {
   public:
	   TestConnectToSelf(const String &localDomainName);
	   virtual ~TestConnectToSelf();

      DiagnosticResult PerformTest();

   private:

      String local_domain_name_;
   };


}
