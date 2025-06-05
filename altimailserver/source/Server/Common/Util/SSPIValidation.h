// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class SSPIValidation
   {
   public:
	   SSPIValidation();
	   virtual ~SSPIValidation();

      static bool ValidateUser(const String &sDomain, const String &sUsername, const String &sPassword);

   };

}
