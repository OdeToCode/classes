using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Container.Register<ILogger, ConsoleLogger>();

            Calculator calc = new Calculator();
            calc.RangeWarning += new EventHandler<RangeWarningEventArgs>(calc_RangeWarning);
            calc.Add(97);
            calc.Add(4);
            calc.Subtract(2);

            Console.WriteLine("The result is {0}", calc.Result);
            Console.ReadLine();
        }

        static void calc_RangeWarning(object sender, RangeWarningEventArgs e)
        {
            Console.WriteLine("The calculator value ({0}) is dangerous", 
                              e.Value);
        }
    }

}
