// Modified, Juan Davel/ringwood-dsg, 2025/06/07
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#include "stdafx.h"
#include "DALRecordsetFactory.h"
#include "ADORecordset.h"
#include "MySQLRecordset.h"
#include "MariaDBRecordset.h"

#ifdef _DEBUG
#define DEBUG_NEW new(_NORMAL_BLOCK, __FILE__, __LINE__)
#define new DEBUG_NEW
#endif

namespace HM
{
   DALRecordsetFactory::DALRecordsetFactory()
   {

   }

   DALRecordsetFactory::~DALRecordsetFactory()
   {

   }


   /*std::shared_ptr<DALRecordset>
   DALRecordsetFactory::CreateRecordset()
   {

   
      return pRS;
   }*/
}