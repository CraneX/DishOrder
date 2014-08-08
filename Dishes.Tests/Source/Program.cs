using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> runnerArgs = new List<string>();
            runnerArgs.Add(Assembly.GetExecutingAssembly().Location);
            runnerArgs.Add("/framework=net-4.0");

            NUnit.ConsoleRunner.Runner.Main(runnerArgs.ToArray());

#if DEBUG
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
#endif
        }
    }
}
