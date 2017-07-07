﻿using System;
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

            Action<string> log = s => Console.WriteLine(s);

            DigitSeparators(log);
            Console.ReadLine();

            OutVariables(log);
            Console.ReadLine();

            ExpressionBodies(log);
            Console.ReadLine();

            Exceptions(log);
            Console.ReadLine();

            // Need System.ValueTuple from NuGet installed in solution
            Tuples(log);
            Console.ReadLine();

            Sharp7Stuff.PatternMatching(log);
            Console.ReadLine();

        }
    }
}
