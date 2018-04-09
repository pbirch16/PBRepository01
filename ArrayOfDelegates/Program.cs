//https://social.msdn.microsoft.com/Forums/en-US/2c08a0d0-58e4-4df6-b6d3-75e785fff8a8/array-of-function-pointers?forum=csharplanguage
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfDelegates
{
    class Program
    {
        Func<bool>[] functions = { dothis, dothis1, dothis2 };

        static void Main(string[] args)
        {
            Func<bool>[] functions = { dothis, dothis1, dothis2 };

            foreach (var function in functions)
            {
                if (!function())
                {
                    break;
                }
            }

            Console.ReadKey();

        }

        private static bool dothis()
        {
            Console.WriteLine("dothis");
            return true;
        }

        private static bool dothis1()
        {
            Console.WriteLine("dothis1");
            return true;
        }

        private static bool dothis2()
        {
            Console.WriteLine("dothis2");
            return true;
        }

    }
}
