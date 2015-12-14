using System.Threading;

namespace Functional
{
    public class Stepper
    {        
        public bool DoSteps()
        {
            if(!Step1())
            {
                return false;
            }
            if(!Step2())
            {
                return false;
            }
            if(!Step3())
            {
                return false;
            }
            if(!Step4())
            {
                return false;
            }
            return true;
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