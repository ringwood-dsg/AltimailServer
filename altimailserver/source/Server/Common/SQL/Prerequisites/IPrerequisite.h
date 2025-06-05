// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once


namespace HM
{
   class IPrerequisite
   {
   public:
      
      virtual int GetDatabaseVersion() = 0;
      virtual bool Ensure(std::shared_ptr<DALConnection> connection, String &sErrorMessage) = 0;

   private:


   };
}