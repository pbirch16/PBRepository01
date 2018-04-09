using System;

namespace TestJaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] aaTitles =
            {
                new string[] {"Total","Files"},
                new string[] {"Total", "Folders"},
                new string[] {"Missing", "Dates", "Created"},
                new string[] {"Missing", "Document", "Dates", "Created" },
                new string[] {"Duplicate", "Document", "Dates", "Created" },
                new string[] {"Equal", "Document", "Dates", "Created" },
                new string[] {"Unequal", "Document", "Dates", "Created" }
            };

            for (int i = 0; i < aaTitles.Length; i++)
            {
                for (int j = 0; j < aaTitles[i].Length; j++)
                {

                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
