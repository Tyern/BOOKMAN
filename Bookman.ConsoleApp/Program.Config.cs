using System;

namespace Bookman.ConsoleApp
{
    using Controllers;
    using static Framework.ViewHelp;
    using DataServices;
    using Framework;

    partial class Program
    {
        private static Models.Book ToBook(Parameter parameter)
        {
            var b = new Models.Book();

            foreach (var prop in b.GetType().GetProperties())
            {
                if (parameter.ContainsKey(prop.Name.ToLower()))
                    ViewHelp.SetValueForProp(prop, parameter[prop.Name.ToLower()], b);
            }

            ViewHelp.WriteLine($"To Book: {b}", ConsoleColor.DarkBlue);
            return b;
        }

        public static void ProgramConfig()
        {
            var context = ConfigReader.Instance.DataAccess;

            BookController controller = new BookController(context);

            ShellController shell = new ShellController(context);

            Router.Instance.Register("about", About, "print the version information");

            Router.Instance.Register("help", Help, "help ? cmd = <command>");

            Router.Instance.Register("single", p => controller
            .Single(p["id"].ToInt()), "print a single book that has provided id\n" +
                                        "single ? id = <id>");

            Router.Instance.Register("update", p => controller
            .Update(p["id"].ToInt()), "update a provided id book information\n" +
            "update ? id = <id>");

            Router.Instance.Register("create", p => controller.Create(),
                "create a new book\n create");

            Router.Instance.Register("list", p => controller.List(), "view all the book in the list\n" +
                "list");

            Router.Instance.Register("single-file",
                p => controller.Single(p["id"].ToInt(), p["path"]),
                "save the provided id book to the path\n single-file ? id = <id> & path = <path>");

            Router.Instance.Register("list-file",
                p => controller.List(p["path"]),
                "save all the book the provided path\n list-file ? path = <path>");

            Router.Instance.Register("do-create",
                p => controller.Create(ToBook(p)),
                "add user - defined book to repository \n do-create ? authors & title & reading & rating & ..");

            Router.Instance.Register("do-update",
                p => controller.Update(p["id"].ToInt(), ToBook(p)),
                "update user - defined book to repository \n do-update ? id &");

            Router.Instance.Register("delete",
                p => controller.Delete(p["id"].ToInt()),
                "delete a book with given Id in repository \n delete ? id &");

            Router.Instance.Register("filter",
                p => controller.Filter(p["key"]),
                "filter the book with given key from repository \n filter ? key &");

            Router.Instance.Register("add-shell",
                p => shell.Shell(p["path"], p["ext"]),
                "add the book in directory path to repository \n add-shell ? path & ext");

            Router.Instance.Register("clear",
                p => controller.Clear(p["force"].StrToBool()),
                "clear all the book in repository \n add-shell ? path & ext");

            Router.Instance.Register("save-shell",
                p => shell.Save(),
                "save all the books in current repository to file\n save-shell");

            Router.Instance.Register("stats",
                p => controller.ViewStats(),
                "show list of book grouped by directory\n stats");

        }
    }
}