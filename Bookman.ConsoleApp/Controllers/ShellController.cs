using System;
using System.Diagnostics;
using System.IO;

namespace Bookman.ConsoleApp.Controllers
{
    using DataServices;
    using Models;
    using Framework;
    using Views;

    internal class ShellController : ControllerBase
    {
        protected Repository repository;

        public ShellController(SimpleDataAccess context)
        {
            repository = new Repository(context);
        }

        public void Shell(string folder, string extension = "*.pdf")
        {
            if (!Directory.Exists(folder))
            {
                Error("Directory address is not valid");
                return;
            }
            var files = Directory.GetFiles(folder, extension ?? "*.pdf", SearchOption.AllDirectories);

            if (files.Length > 0)
            {
                Inform("Adding files to Repository:");
                ViewHelp.Write(new string(' ', "Added to repository:".Length));
                ViewHelp.WriteCenter("Id", 4, ConsoleColor.DarkBlue);
                ViewHelp.WriteCenter("Book name", 20, ConsoleColor.DarkBlue);
                Console.WriteLine();
            }
            else
            {
                Error("No document with extension found in the directory");
            }

            foreach (var f in files)
            {

                var book = new Book() { Title = Path.GetFileNameWithoutExtension(f), File = f };
                repository.Add(book);
                ViewHelp.WriteLine($"Added to repository: {book.Id} : {book.Title}");
            }

        }
    }
}
