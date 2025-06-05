// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class CrashSimulation
   {
   public:

      static void Execute(int simulation_mode);

   private:
      CrashSimulation(void);

    
   };
}