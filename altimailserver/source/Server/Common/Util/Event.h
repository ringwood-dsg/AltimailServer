// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class Event
   {
   public:
      Event(void);
      Event(const Event& p);
      ~Event(void);
   
      void Wait();

      void WaitFor(boost::chrono::milliseconds milliseconds);

      void Set();

   private:

      boost::mutex mutex_;
      boost::condition_variable set_condition_;
      bool is_set_;
   };
}