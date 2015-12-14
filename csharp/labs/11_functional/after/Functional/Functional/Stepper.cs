using System;
using System.Linq;
using System.Threading;

namespace Functional
{
    public class Stepper
    {        
        public bool DoSteps()
        {
            Func<bool>[] steps = 
            {
                Step1, 
                Step2, 
                Step3, 
                Step4
            };

            return steps.All(step => step());
        }

        bool Step1()
        {
            Thread.Sleep(1000);
            return true;
        }

        bool Step2()
        {
            Thread.Sleep(1000);
            return true;
        }

        bool Step3()
        {
            Thread.Sleep(1000);
            return true;
        }

        bool Step4()
        {
            Thread.Sleep(1000);
            return true;
        }
    }
}