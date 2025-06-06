// Modified, Juan Davel/ringwood-dsg, 2025/06/03
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

using boost::asio::ip::tcp;

namespace HM
{
   class SynchronousConnection
   {
   public:
	   SynchronousConnection(int timeoutSeconds);
	   virtual ~SynchronousConnection();

      bool Connect(const AnsiString &hostName, int port);
      bool Write(const AnsiString &data);
      bool Write(const ByteBuffer &buffer);
      bool ReadUntil(const AnsiString &delimiter, AnsiString &readData);
      void Close();

   private:
      
      bool Write_(const unsigned char *buf, size_t bufSize);

      boost::asio::io_context ioservice_;
      tcp::socket socket_;
      int seconds_;
   };


}
