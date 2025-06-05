// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
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
