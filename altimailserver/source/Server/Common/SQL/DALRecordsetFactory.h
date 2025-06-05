// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class DALRecordsetFactory  
   {
   public:
	   DALRecordsetFactory();
	   virtual ~DALRecordsetFactory();

      //static std::shared_ptr<DALRecordset> CreateRecordset();
   };
}
