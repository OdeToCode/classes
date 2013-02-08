using System.Diagnostics;

namespace PerfSurf.PerfCounters
{
    public class PerformanceCounterQuery
    {        
        public PerformanceCounterQuery(string friendlyName, string category, string counter, string instance = null)
        {
            _friendlyName = friendlyName;
            _category = category;
            _counter = counter;
            _instance = instance;
            _lookupName = _category + ":" + _counter + ":" + _instance;
        }

        public string FriendlyName
        {
            get { return _friendlyName; }
        }

        public string CategoryName
        {
            get { return _category; }
        }

        public string CounterName
        {
            get { return _counter; }
        }

        public string Instance
        {
            get { return _instance; }
        }

        public string LookupName
        {
            get { return _lookupName; } 
        }

        public PerformanceCounter GetCounter()
        {
            var counter = new PerformanceCounter(CategoryName, CounterName, Instance);
            return counter;
        }

        private readonly string _friendlyName;
        private readonly string _category;
        private readonly string _counter;
        private readonly string _instance;
        private readonly string _lookupName;
    }
}