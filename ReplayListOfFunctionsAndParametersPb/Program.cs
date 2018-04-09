using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayListOfFunctionsAndParametersPb
{
    class Program
    {
        private static Action _action;
        static void Main(string[] args)
        {
            _action = Foo(1, 2, 4);
            CallFunc(() => Foo(1, 2, 4));
            CallFunc(() => Bar(6));
            CallFunc(() => Foo2("Hello"));
            CallFunc(() => Bar2(0, 11, true));

            Console.ReadKey();
        }


        class Recorder
        static void CallFunc(Action action)
        {
            action();
        }

        private static void Foo(int n1, int n2, int n3)
        {
            Console.WriteLine("Total = {0}", n1 + n2 + n3);
        }

        private static void Bar(int n)
        {
            Console.WriteLine("n = {0}", n);
        }

        private static void Foo2(string s)
        {
            Console.WriteLine("s = {0}", s);
        }

        private static void Bar2(int n1, int n2, bool b)
        {
            Console.WriteLine("n1 = {0}  n2 = {1}  b = {2}", n1, n2, b);
        }
    }
}
