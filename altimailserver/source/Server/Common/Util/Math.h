// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class Math  
   {
   public:
	   Math();
	   virtual ~Math();

      static float Round(const float &number, const int num_digits);

   };
}
