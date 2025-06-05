// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

class COMError
{
public:
   COMError(void);
   ~COMError(void);

   static HRESULT GenerateGenericMessage();
   static HRESULT GenerateError(HM::String sDescription);
};
