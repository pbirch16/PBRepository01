//https://stackoverflow.com/questions/8584155/replay-a-list-of-functions-and-parameters
using System;
using System.Collections.Generic;

namespace ReplayListOfFunctionsAndParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            var recorder = new Recorder();
            recorder.CallAndRecord(() => Foo(1, 2, 4));
            recorder.CallAndRecord(() => Bar(6));
            recorder.CallAndRecord(() => Foo2("Hello"));
            recorder.CallAndRecord(() => Bar2(0, 11, true));

            recorder.Playback();

            Console.ReadKey();
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

    public class Recorder
    {
        private IList<Action> _recording;

        public Recorder()
        {
            _recording = new List<Action>();
        }

        public void CallAndRecord(Action action)
        {
            _recording.Add(action);
            action();
        }

        public void Playback()
        {
            foreach (var action in _recording)
            {
                action();
            }
        }
    }
}
