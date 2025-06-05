// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

#include <Boost\function.hpp>
#include "..\Application\SessionManager.h"
#include "..\Threading\Task.h"
#include "..\Util\Event.h"

#include "SocketConstants.h"



namespace HM
{
   class TCPServer;

   class IOService : public Task
   {
   public:
      IOService(void);
      ~IOService(void);

      void DoWork();

      void Initialize();

      // Session types
      bool RegisterSessionType(SessionType st);

      boost::asio::io_context &GetIOService();
      boost::asio::ssl::context &GetClientContext();
   private:

      const String asynchronous_tasks_queue_;

      std::set<SessionType> session_types_;
      boost::asio::io_context io_service_;

      std::vector<std::shared_ptr<TCPServer> > tcp_servers_;

      boost::condition_variable do_work_dummy;

      boost::asio::ssl::context client_context_;
   };


}