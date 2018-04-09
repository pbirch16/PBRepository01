//https://stackoverflow.com/questions/9754669/c-sharp-function-pointer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionPointerExample
{
    class Program
    {
        // This is the "type" of the function pointer, known as a "delegate" in .NET.
        // An instance of this delegate can point to any function that has the same signature (in this case, any function/method that returns void and accepts a single String argument).
        public delegate void FooBarDelegate(String x);

        //My attempts
        private delegate void FP(string s);


        static void Main(string[] args)
        {
            Function1();
            Console.ReadKey();
        }

        public static void Function1()
        {
            //Create a delegate to Function2
            FooBarDelegate functionPointer = new FooBarDelegate(Function2);

            //Call it
            functionPointer("bla");
        }



        public static void Function2(string s)
        {
            Console.WriteLine(s);
        }

        //My attempts

        private static void Init()
        {

        }

        private static void Func1(string s)
        {
            Console.WriteLine("This is Func1 " + s);
        }

        private static void Func2(string s)
        {
            Console.WriteLine("This is Func2 " + s);
        }
    }
}
