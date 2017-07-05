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

        internal static void Exceptions(Action<string> log)
        {
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
                log(text?? throw new ArgumentNullException(nameof(text)));
            }


            try
            {
                OldDoUsefullStuff(null);
            } catch { }

            try
            {
                NewDoUsefullStuff(null);
            }  catch { }
        }

        internal static void ExpressionBodies(Action<string> log)
        {
            var user = new User("Alfred");
            log("Username: " + user.UserName);

            
        }

        public class User
        {
            private string userName;

            public string UserName
            {
                get => userName;
                private set => userName = value;
            }

            //Constructor
            public User(string userName) => UserName = userName;
        }
    }
}
