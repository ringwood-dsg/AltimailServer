// Copyright (c) 2010 Martin Knafve / altimailserver.org.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class ClassTester  
   {
   public:
	   ClassTester();
	   virtual ~ClassTester();

      void DoTests();

   private:

      void LoadSettings_();

      void TestBackup_();

      String mime_data_path_;
   };

}
