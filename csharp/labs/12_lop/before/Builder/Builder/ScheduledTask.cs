using System;

namespace Builder
{
    public interface ITask
    {
        // ...
    }
    public class RunReport : ITask
    {
        
    }

    public class ScheduledTask
    {
        public ScheduledTask(ITask task,
                             TimeSpan interval,
                             TimeSpan expiration)
        {
            Task = task;
            Interval = interval;
            Expiration = expiration;
        }

        public ITask Task { get; protected set; }
        public TimeSpan Interval { get; protected set; }
        public TimeSpan Expiration { get; protected set; }

    }


    //  1.Hour()
    //  300.Days()
    //  


   public static class TimeSpanExtensions
   {
       public static TimeSpan Hour(this int value)
       {
           return new TimeSpan(value, 0, 0);
       }

       public static TimeSpan Days(this int value)
       {
           return new TimeSpan(value, 0, 0, 0);
       }
   }


    public class Program
    {
        static void Main()
        {
            var task = new ScheduledTask(
                            new RunReport(),
                            1.Hour(),
                            300.Days());
        }
    }
}