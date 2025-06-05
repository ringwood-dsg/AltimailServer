// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class Dictionary
   {
   public:
	   Dictionary();
      ~Dictionary();

      static String GetWindowsErrorDescription(int iErrorCode);
   
   };
}
