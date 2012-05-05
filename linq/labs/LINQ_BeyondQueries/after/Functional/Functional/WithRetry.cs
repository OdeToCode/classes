using System;

namespace Functional
{
    public static class RetryExtensions
    {
         public static bool WithRetry(this Func<bool> func)
         {
             int retryCount = 0;
             bool result = false;

             while(retryCount++ < 3 && !result)
             {
                 result = func();
             }
             return result;
         }
    }
}