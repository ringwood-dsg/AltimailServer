// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class DefaultDomain
   {
   public:
      DefaultDomain(void);
      ~DefaultDomain(void);

      static String ApplyDefaultDomain(const String &sAddress);
   };
}