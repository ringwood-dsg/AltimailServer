// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class MessageRecipient;

   class PersistentMessageRecipient 
   {
   public:
      PersistentMessageRecipient(void);
      ~PersistentMessageRecipient(void);

      static bool DeleteObject(std::shared_ptr<MessageRecipient> pRecipient);
   };
}
