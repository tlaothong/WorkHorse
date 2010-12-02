using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your name: ");
            PerfEx.Demo.SystemUnderTest.TargetOfTest tot =
                new PerfEx.Demo.SystemUnderTest.TargetOfTest();
            tot.WorkTogether = new MyCoWorker();
            string result = tot.Hello();
            Console.WriteLine(result);
        }

        public class MyCoWorker : PerfEx.Demo.SystemUnderTest.IWorkTogether
        {
            public string ReadText()
            {
                return Console.ReadLine();
            }
        }

    }
}
