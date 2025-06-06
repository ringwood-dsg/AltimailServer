// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class SPF : public Singleton<SPF>
   {
   public:
      SPF(void);
      ~SPF(void);

      enum Result
      {
         Neutral = 0,
         Fail = 1,
         Pass = 2
      };

      String ReceivedSPFHeader(const String& sHostname, const String& sSenderIP, const String& sSenderEmail, const String& sHeloHost, String& sResult);
      Result Test(const String &sSenderIP, const String &sSenderEmail, const String &sHeloHost, String &sExplanation);  

   private:
      
   };

   class SPFTester
   {
   public :
      SPFTester () {};
      ~SPFTester () {};      

      void Test();
   };
}