// Copyright (c) 2014 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

#pragma once

#include "../Common/TCPIP/CipherInfo.h"

namespace HM
{
   class CipherInfo;
   class MimeHeader;

   class SMTPMessageHeaderCreator
   {
   public:
      
      SMTPMessageHeaderCreator(const String &username, const String &envelopeFrom, const String &envelopeTo, const AnsiString &remote_ip_address, bool is_authenticated, String helo_host, std::shared_ptr<MimeHeader> original_headers);

      AnsiString Create();

      void SetCipherInfo(const CipherInfo &cipher_info);

   private:

      String GenerateReceivedSPFHeader_(const String &sHostname);
      String GenerateReceivedHeader_(const String &local_computer_name, const String &overriden_received_ip);

      String username_;
      String envelopeFrom_;
      String envelopeTo_;
      AnsiString remote_ip_address_;
      AnsiString helo_host_;
      std::shared_ptr<MimeHeader> original_headers_;
      CipherInfo cipher_info_;
      bool is_tls_;
      bool is_authenticated_;
      
   };
}