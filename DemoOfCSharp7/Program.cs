using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoOfCSharp7.Sharp7Stuff;

namespace DemoOfCSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://github.com/rotellef/DemoOfCSharp7
            //
            // Comment a line:   Ctrl-K, Ctrl-C
            // UnComment a line: Ctrl-K, Ctrl-U

            Do(DigitSeparators);
            Do(OutVariables);
            Do(ExpressionBodies);
            Do(Exceptions);
            // Need System.ValueTuple from NuGet installed in solution
            Do(Tuples);
            Do(PatternMatching);

        }
        private static void Do(Action action)
        {
            Console.WriteLine(action.Method.Name);
            action();
            Console.ReadLine();
        }
    }
}
