// Modified, Juan Davel/ringwood-dsg, 2025/06/07
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once


#include "..\Threading\Task.h"

namespace HM
{
   class Socket;
   class SocketCompletionPort;

   class IOCPQueueWorkerTask : public Task
   {
   public:

      IOCPQueueWorkerTask(boost::asio::io_context &io_service);

      virtual void DoWork();
      void DoWorkInner();

   private:

      boost::asio::io_context &io_service_;
   };
}