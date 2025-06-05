// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

namespace RegressionTests.Shared
{
   public class SingletonProvider<T> where T : new()
   {
      private SingletonProvider()
      {
      }

      public static T Instance
      {
         get { return SingletonCreator.instance; }
      }

      #region Nested type: SingletonCreator

      private class SingletonCreator
      {
         internal static readonly T instance = new T();
      }

      #endregion
   }
}