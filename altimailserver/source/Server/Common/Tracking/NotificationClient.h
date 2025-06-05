// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class ChangeNotification;

   class NotificationClient
   {
   public:
      NotificationClient();

      virtual void OnNotification(std::shared_ptr<ChangeNotification> notification) = 0;
   };
}
