// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com


namespace HM
{
   class Base64
   {
   public:
      static AnsiString Encode(const char *input, int inputLength);
      static AnsiString Decode(const char *input, int inputLength);

   private:
   };

   class Base64Tester
   {
   public:
      void Test();
   };

}