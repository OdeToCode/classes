using System;
using System.Linq.Expressions;
using Extensions;


namespace Extensions
{
    public class LambdaStuff
    {
        public void Method()
        {
            


        }
    }



    public static class IntExtensions
    {
        public static TimeSpan Minutes(this int value)
        {            
            return new TimeSpan(0, 0, value, 0);
        }
        
    }
}

namespace BeyondQueries
{
    


    public class ExtensionStuff
    {
        public void CreateTimeSpan()
        {
            var span = 2.Minutes();
        }
    }
}