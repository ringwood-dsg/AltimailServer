// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once
#include "../AltimailServer/resource.h"       // main symbols

#include "../AltimailServer/AltimailServer.h"

#include "../Common/BO/Attachments.h"
// InterfaceAttachments

class ATL_NO_VTABLE InterfaceAttachments : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<InterfaceAttachments, &CLSID_Attachments>,
	public IDispatchImpl<IInterfaceAttachments, &IID_IInterfaceAttachments, &LIBID_AltimailServer, /*wMajor =*/ 1, /*wMinor =*/ 0>,
   public HM::COMAuthenticator,
   public ISupportErrorInfo
{
public:
	InterfaceAttachments()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_INTERFACEATTACHMENTS)


BEGIN_COM_MAP(InterfaceAttachments)
	COM_INTERFACE_ENTRY(IInterfaceAttachments)
	COM_INTERFACE_ENTRY(IDispatch)
   COM_INTERFACE_ENTRY(ISupportErrorInfo)
END_COM_MAP()


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

public:
   STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid);

   STDMETHOD(get_Item)(/*[in]*/ long Index, /*[out, retval]*/ IInterfaceAttachment* *pVal);
   STDMETHOD(get_Count)(/*[out, retval]*/ long *pVal);
   STDMETHOD(Clear)();
   STDMETHOD(Add)(BSTR sFilename);

   void Attach(std::shared_ptr<HM::Attachments> pAttachments);

private:

   std::shared_ptr<HM::Attachments> attachments_;

};

OBJECT_ENTRY_AUTO(__uuidof(Attachments), InterfaceAttachments)
