// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class Message;
   
   class MailerDaemonAddressDeterminer  
   {
   public:
	   MailerDaemonAddressDeterminer();
	   virtual ~MailerDaemonAddressDeterminer();

      static String GetMailerDaemonAddress(const std::shared_ptr<Message> pOrigMessage);
      static String GetMailerDaemonAddress(const String &sOrigSender, const String &sOrigReceiver);

      static bool IsMailerDaemonAddress(const String &sAddress);
   };

}
