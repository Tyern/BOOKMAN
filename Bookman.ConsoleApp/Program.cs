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
                ViewHelp.Write(ConfigReader.Instance.PromptText, ConfigReader.Instance.Color);

                var request = Console.ReadLine();
                try
                {
                Router.Instance.Forward(request);
                }
                catch (Exception e)
                {
                    ViewHelp.WriteLine($"ERROR: {e}", ConsoleColor.Red);
                }
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
                ViewHelp.WriteLine(Router.Instance.GetRoute(), ConsoleColor.DarkBlue);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}
