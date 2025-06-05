// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class GreyListing
   {
   public:
      GreyListing(void);
      ~GreyListing(void);
   
      bool GetAllowSend(const String &sSenderAddress, const String &sRecipientAddress, const IPAddress & remoteIP);

   private:
   };
}