using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Speech.Synthesis;
using System.IO;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string message = String.Format("Hello, {0}", args[0]);
                Console.WriteLine(message);                

                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.Speak(message);
            }
            Console.ReadLine();
        }
    }
}
