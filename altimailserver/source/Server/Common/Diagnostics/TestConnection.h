// Modified, Juan Davel/ringwood-dsg, 2025/06/03
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

#include "../TCPIP/TCPConnection.h"

namespace HM
{
   class TestConnectionResult;

   class TestConnection : public TCPConnection
   {
   public:
      TestConnection(ConnectionSecurity connection_security,
         boost::asio::io_context& io_service, 
         boost::asio::ssl::context& context,
         std::shared_ptr<Event> disconnected,
         AnsiString remote_hostname,
         std::shared_ptr<TestConnectionResult> connection_result);
      virtual ~TestConnection();
      void OnConnected();

      virtual void OnCouldNotConnect(const AnsiString &error_description);
      virtual void OnHandshakeCompleted();
      virtual void OnHandshakeFailed() {};
      virtual void OnConnectionTimeout() {};
      virtual void OnExcessiveDataReceived() {};
      virtual AnsiString GetCommandSeparator() const { return "\r\n"; }

      virtual void ParseData(const AnsiString &Request) {};
      virtual void ParseData(std::shared_ptr<ByteBuffer> ) {}

   private:

      std::shared_ptr<TestConnectionResult> connection_result_;
   };

}
