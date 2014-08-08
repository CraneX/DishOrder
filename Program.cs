using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pull in log4net configuration
            log4net.Config.XmlConfigurator.Configure();

            if (args.Length == 0)
            {
                Console.Out.WriteLine("Usage:\r\n\tInput [morning|night], {[DishTpye],...}");
            }
            else
            {
                // we allow command line  as  "morning, 1, 2, 3"
                // or command line as morning, 1, 2, 3
                // input type
                string input = string.Join("", args);
                Console.Out.WriteLine(new DishOrder().PrintFoods(input));
            }
        }
    }
}
