// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#include "stdafx.h"

#include "MiniDumpInput.h"

#pragma warning (disable: 4566)

#ifdef _DEBUG
#define DEBUG_NEW new(_NORMAL_BLOCK, __FILE__, __LINE__)
#define new DEBUG_NEW
#endif

namespace HM
{
   const std::string MiniDumpInput::SharedMemoryName = "AltimailServerMiniDumpMemory";
}