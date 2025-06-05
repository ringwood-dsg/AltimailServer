// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{

   class TestConnect
   {
   public:

      bool PerformTest(ConnectionSecurity connection_security, const String &localAddressStr, const String &server, int port, String &result);

   };


}
