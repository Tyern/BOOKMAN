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

            //int id;

            while (true)
            {
                Write("Request> ", ConsoleColor.DarkGreen);
                var request = Console.ReadLine();

                Router.Instance.Forward(request);
                Console.WriteLine();


                //switch (request.ToLower())
                //{
                //    case "single":

                //        Console.Write("Input the Id: ");
                //        while (!int.TryParse(Console.ReadLine(), out id))
                //        {
                //            Console.Write("Id is invalid", ConsoleColor.Red);
                //        }

                //        controller.Single(id);
                //        break;

                //    case "create":
                //        controller.Create();
                //        break;

                //    case "update":

                //        Console.Write("Input the Id: ");
                //        while (!int.TryParse(Console.ReadLine(), out id))
                //        {
                //            Console.Write("Id is invalid", ConsoleColor.Red);
                //        }

                //        controller.Update(id);
                //        break;

                //    case "list":
                //        controller.List();
                //        break;

                //    default:
                //        Write("Command not found.\n");
                //        break;
                //}
            }
        }
    }
}
