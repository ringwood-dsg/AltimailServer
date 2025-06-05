// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class OutOfMemoryHandler
   {
   public:
      OutOfMemoryHandler(void);
      ~OutOfMemoryHandler(void);

      static void Initialize();
      static void Terminate();

   private:

      static _PNH pOriginalNewHandler;
   };
}