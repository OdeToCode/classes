using System;

namespace Calculator
{
    class Calculator
    {
        public void Add(int value)
        {
            _logger.Log("Adding " + value);
            Result += value;
            CheckResult();
        }

        public void Subtract(int value)
        {
            _logger.Log("Subtracting " + value);
            Result -= value;
            CheckResult();
        }

        void CheckResult()
        {
            if (Result < 0 || Result > 100)
            {
                EventHandler<RangeWarningEventArgs> handler = RangeWarning;
                if (handler != null)
                {
                    RangeWarningEventArgs args = new RangeWarningEventArgs();
                    args.Value = Result;
                    handler(this, args);
                }
            }                
        }

        public event EventHandler<RangeWarningEventArgs> RangeWarning;
        public int Result { get; set; }

        ILogger _logger = Container.Resolve<ILogger>();
    }
}
