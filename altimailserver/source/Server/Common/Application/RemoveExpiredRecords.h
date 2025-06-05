// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

#include "../BO/ScheduledTask.h"

namespace HM
{
   class RemoveExpiredRecords : public ScheduledTask
   {
   public:
      RemoveExpiredRecords(void);
      ~RemoveExpiredRecords(void);

      virtual void DoWork();

   private:
   };
}