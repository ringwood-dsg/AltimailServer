// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

#include "../Common/BO/ScheduledTask.h"

namespace HM
{
   class GreyListCleanerTask : public ScheduledTask
   {
   public:
      GreyListCleanerTask(void);
      ~GreyListCleanerTask(void);

      virtual void DoWork();
   private:
   };
}