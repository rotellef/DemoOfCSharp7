using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOfCSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> log = s => Console.WriteLine(s);

            Sharp7Stuff.DigitSeparators(log);
            Console.ReadLine();

            Sharp7Stuff.OutVariables(log);
            Console.ReadLine();

            Sharp7Stuff.ExpressionBodies(log);
            Console.ReadLine();

            Sharp7Stuff.Exceptions(log);
            Console.ReadLine();

        }
    }
}
