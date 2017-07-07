using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOfCSharp7
{
    public class Sharp7Stuff
    {
        static void Log(string t) => Console.WriteLine($"{t}");

        internal static void DigitSeparators() => Log("1_000_000 = " + 1_000_000);

        internal static void OutVariables()
        {
            // Local Function, også nytt i C#7, tror jeg...
            void TestParse(string text)
            {
                Log("Text to parse: " + text);
                if (int.TryParse(text, out int number))// "var" funker også
                    Log("vi klarte å parse tallet!");
                else
                    Log("klarte ikke parse tallet");

                // Tilgjengelig i hele scope:
                Log($"{number} + {number} = {number * 2}");
            }

            TestParse("9");
            TestParse("tull");
        }

        internal static void PatternMatching()
        {
            var list = new List<Shape>() {
                new Circle() { Radius = 20 },
                new Circle() { Radius = 100 },
                new Circle() { Radius = -2 },
                new Rectangle() { Height = 5, Width = 20 },
                new Rectangle() { Height = 10, Width = 100 },
                new Triangle("Triangle"),
                null
            };

            foreach (var shape in list)
            {
                // Måten vi sjekka type på før:
                if(shape != null && shape.GetType() == typeof(Circle))
                {
                    var circle = (Circle)shape;
                    Log("Old way of type check and casting. This is Circle: " + circle.ToString());
                }

                if (shape is null) Log("If - shape is null!");
                // Legg merke til at neste linje ikke slår til dersom shape == null
                if (shape is Circle ci) Log($"If - shape is a Circle: {ci}");
                // Men nå henger en unassigned variabel med navn "ci" i for-scopet vårt
                // Se på dette griseriet:
                ci = new Circle() { Radius = 9999 };

                // Dette er rydding og fint:
                switch (shape)
                {
                    case Rectangle r:
                        Log($"It was a Rectangle with height={r.Height} and width={r.Width}");
                        break;
                    case Circle c when (c.Radius < 0):
                        Log($"Damn, we have a circle with negative radius! Radius = {c.Radius}");
                        break;
                    case Circle c when (c.Radius > 80):
                        Log("Ohhhh, big circle!!");
                        break;
                    // Hvis vi ikke bryr oss om verdier i objected, kan vi indikere den slik:
                    case Circle _:
                        Log("normal circle... zzz zzz zzz");
                        break;
                    case Triangle t:
                        Log($"A weird triangle {t.Name}");
                        break;
                    case null:
                        Log("I don't like null! Ignoring that!");
                        break;
                }
            }
        }

        internal static void Tuples()
        {
            // Metode som returnerer en tupple på 3 elementer, uten navn
            (string, bool, int) DoSomething(int number)
            {
                if (number < 0)
                    return ("Number was negative", false, number);
                else
                    return ("Number was posetive! :)", true, number);
            }

            // Funksjon for å Logge ut resultat dersom den er "valid". Navngitte tupple-elementer
            Action<(string msg, bool valid, int value)> LogTupple = tu =>
            {
                if (tu.valid)
                    Log(tu.value + " is valid: " + tu.msg);
            };

            var result1 = DoSomething(-2);
            LogTupple(result1);

            var result2 = DoSomething(20);
            LogTupple(result2);


        }

        internal static void Exceptions()
        {
            void Try(Action<string> action, string value)
            {
                try { action(value); }
                catch (Exception ex) { Log($"Exception when performing action {action.Method.Name}. Message: {ex.Message}"); }
            }

            void OldWay(string text)
            {
                if (text == null) throw new ArgumentNullException(nameof(text));
                Log(text);
            }

            void NewWay(string text) => Log(text ?? throw new ArgumentNullException(nameof(text)));

            Try(OldWay, null);
            Try(NewWay, null);
        }

        internal static void ExpressionBodies()
        {
            // Se User klassen!
            var user = new User("Alfred");
            Log("Username: " + user.UserName);
        }

        #region Hjelpeklasser
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

            public override string ToString() => $"Radius={Radius}";

        }

        public class Rectangle : Shape
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public override string ToString() => $"Height={Height}, Width={Width}";
        }

        public class Triangle : Shape
        {
            public string Name { get; private set; }
            public Triangle(string name) => Name = name;
        }
    }
}
#endregion