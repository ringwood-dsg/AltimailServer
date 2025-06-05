// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class EventTester
   {
   public:
      void Test();
   private:

      void TestSetBeforeWait();
      void TestWaitTimeoutNotSet();
      void TestWaitTimeoutSet();
   };
}