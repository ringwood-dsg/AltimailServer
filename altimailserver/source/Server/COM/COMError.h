// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
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
