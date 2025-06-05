// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

#include <crtdbg.h>

namespace HM
{
   class HeapChecker
   {
   public:
      HeapChecker(void);
      ~HeapChecker(void);

      static void CheckHeapOnAllocation();

      void Reset();
      void Report();

   private:
#ifdef _DEBUG
       _CrtMemState start_;
#endif
   };
}