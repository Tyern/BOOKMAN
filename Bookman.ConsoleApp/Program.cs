using System;

namespace Bookman.ConsoleApp
{
    using Controllers;
    using static Framework.ViewHelp;
    using DataServices;
    using Framework;

    class Program
    {
        private static void About(Parameter parameter)
        {
            WriteLine("BOOK MAGAGER version 1.0", ConsoleColor.Green);
            WriteLine("by TXH", ConsoleColor.DarkMagenta);
        }

        private static void Help(Parameter parameter)
        {
            if (parameter["cmd"] == null)
            {
                WriteLine(Router.Instance.GetRoute(), ConsoleColor.Yellow);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string command = parameter["cmd"].ToLower();
            WriteLine(Router.Instance.GetHelp(command));
        }

        static void Main(string[] args)
        {
            SimpleDataAccess context = new SimpleDataAccess();

            BookController controller = new BookController(context);

            Router.Instance.Register("about", About, "print the version information");

            Router.Instance.Register("help", Help);

            Router.Instance.Register("single", p => controller.Single(p["id"].ToInt()));

            Router.Instance.Register("update", p => controller.Update(p["id"].ToInt()));

            Router.Instance.Register("create", p => controller.Create());

            Router.Instance.Register("list", p => controller.List());

            Router.Instance.Register("single-file", p => controller.Single(p["id"].ToInt(), p["path"]));

            Router.Instance.Register("list-file", p => controller.List(p["path"]));

            //int id;

            while (true)
            {
                Write("Request> ", ConsoleColor.DarkGreen);
                var request = Console.ReadLine();

                Router.Instance.Forward(request);
                Console.WriteLine();
            }
        }
    }
}
