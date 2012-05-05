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

            return steps.All(step => step.WithRetry());
        }

        bool Step1()
        {            
            return true;
        }

        bool Step2()
        {
            step2Count += 1;
            if(step2Count < 3)
            {                
                return false;
            }
            return true;
        }

        int step2Count = 0;

        bool Step3()
        {
            return true;
        }

        bool Step4()
        {
            return true;
        }        
    }
}