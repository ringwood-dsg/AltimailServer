// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#include "IMAPCommand.h"

namespace HM
{
   class IMAPCommandCLOSE : public IMAPCommand
   {
      virtual IMAPResult ExecuteCommand(std::shared_ptr<HM::IMAPConnection> pConnection, std::shared_ptr<IMAPCommandArgument> pArgument);
   };

}

