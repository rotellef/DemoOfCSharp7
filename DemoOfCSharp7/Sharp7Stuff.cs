using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOfCSharp7
{
    public class Sharp7Stuff
    {

        internal static void DigitSeparators(Action<string> log)
        {
            log("DigitSeparators");

            var oneMillion = 1_000_000;
            log("1_000_000 = " + oneMillion);
        }

        internal static void OutVariables(Action<string> log)
        {
            log("OutVariables");

            // Local Function, også nytt i C#7, tror jeg...
            void TestParse(string text)
            {
                log("Text to parse: " + text);
                if (int.TryParse(text, out int number))// var funker også
                    log("vi klarte å parse tallet!");
                else
                    log("klarte ikke parse tallet");

                // Tilgjengelig i hele scope:
                log($"{number} + {number} = {number * 2}");
            }

            TestParse("9");
            TestParse("tull");
        }

        internal static void PatternMatching(Action<string> log)
        {
            log("PatternMatching");

            var list = new List<Shape>() {
                new Circle() { Radius = 20 },
                new Circle() { Radius = 100 },
                new Circle() { Radius = -2 },
                new Rectangle() { Height = 5, Width = 20 },
                new Rectangle() { Height = 10, Width = 100 },
                null
            };

            foreach (var shape in list)
            {
                // Isteden for å ha if-settninger som sjekker type, 
                // for å å caste over til typen for å nå feltene, kan vi gjøre dette:
                switch (shape)
                {
                    case Rectangle r:
                        log($"It was a Rectangle with height={r.Height} and width={r.Width}");
                        break;
                    case Circle c when (c.Radius < 0):
                        log($"Damn, we have a circle with negative radius! Radius = {c.Radius}");
                        break;
                    case Circle c when (c.Radius > 80):
                        log("Ohhhh, big circle!!");
                        break;
                    // Hvis vi ikke bryr oss om verdier i objected, kan vi indikere den slik:
                    case Circle _:
                        log("normal circle... zzz zzz zzz");
                        break;
                    case null:
                        log("I don't like null! Ignoring that!");
                        break;
                }
            }
        }

        internal static void Tuples(Action<string> log)
        {
            log("Tuples");

            // Metode som returnerer en tupple på 3 elementer, uten navn
            (string, bool, int) DoSomething(int number)
            {
                if (number < 0)
                    return ("Number was negative", false, number);
                else
                    return ("Number was posetive! :)", true, number);
            }

            // Funksjon for å logge ut resultat dersom den er "valid". Navngitte tupple-elementer
            Action<(string msg, bool valid, int value)> logTupple = tu =>
            {
                if (tu.valid)
                    log(tu.value + " is valid: " + tu.msg);
            };

            var result1 = DoSomething(-2);
            logTupple(result1);

            var result2 = DoSomething(20);
            logTupple(result2);


        }

        internal static void Exceptions(Action<string> log)
        {
            log("Exceptions");

            void OldDoUsefullStuff(string text)
            {
                if (text == null)
                {
                    throw new ArgumentNullException(nameof(text));
                }
                log(text);
            }

            void NewDoUsefullStuff(string text)
            {
                log(text ?? throw new ArgumentNullException(nameof(text)));
            }


            try
            {
                OldDoUsefullStuff(null);
            }
            catch { }

            try
            {
                NewDoUsefullStuff(null);
            }
            catch { }
        }

        internal static void ExpressionBodies(Action<string> log)
        {
            log("ExpressionBodies");

            // Se User klassen!
            var user = new User("Alfred");
            log("Username: " + user.UserName);


        }

        public class User
        {
            private string userName;

            public string UserName
            {
                // Kortere måte å skrive metoder med en linje på:
                get => userName;
                private set => userName = value;
            }

            // Kortere måte å skrive constructor med en linje på:
            public User(string userName) => UserName = userName;
        }


        public abstract class Shape { }

        public class Circle : Shape
        {
            public int Radius { get; set; }
        }

        public class Rectangle : Shape
        {
            public int Height { get; set; }
            public int Width { get; set; }
        }
    }
}
