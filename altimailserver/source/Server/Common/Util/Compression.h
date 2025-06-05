// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

#pragma once

namespace HM
{
   class Compression
   {
   public:
      Compression();
      ~Compression(void);

      bool AddDirectory(const String &zipFile, const String &directoryToAdd);
      bool AddFile(const String &zipFile, const String &fileToAdd);

      bool Uncompress(const String &zipFile, const String &targetDirectory);
      bool Uncompress(const String &zipFile, const String &targetDirectory, const String &wildCard);

   private:
 
      bool LaunchCommand_(const String &commandLine);
      String GetExecutableFullPath_();

   };
}