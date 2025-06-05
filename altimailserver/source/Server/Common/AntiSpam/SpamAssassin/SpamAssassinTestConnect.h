// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class SpamAssassinTestConnect
   {
   public:

      bool TestConnect(const String &hostName, int port, String &message);

   private:

   };
}