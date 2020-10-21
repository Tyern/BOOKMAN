using System;

namespace Bookman.ConsoleApp
{
    using Framework;

    internal partial class Program
    {
        static void Main(string[] args)
        {
            ProgramConfig();

            while (true)
            {
                ViewHelp.Write("Request> ", ConsoleColor.DarkGreen);
                var request = Console.ReadLine();

                Router.Instance.Forward(request);
                Console.WriteLine();
            }
        }

        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MAGAGER version 1.0", ConsoleColor.Green);
            ViewHelp.WriteLine("by TXH", ConsoleColor.DarkMagenta);
        }

        private static void Help(Parameter parameter)
        {
            if (parameter["cmd"] == null)
            {
                ViewHelp.WriteLine(Router.Instance.GetRoute(), ConsoleColor.Yellow);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}
