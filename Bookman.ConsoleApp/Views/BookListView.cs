using System;

namespace Bookman.ConsoleApp.Models
{
    using Framework;

    public class BookListView : RenderToFile
    {
        protected Book[] Model;
        /// <summary>
        /// constructor to initialize the list of book class
        /// </summary>
        /// <param name="model"></param>
        public BookListView(Book[] model)
        {
            Model = model;
        }

        public void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("No book found", ConsoleColor.DarkGreen);
                return;
            }
            ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);

            ViewHelp.WriteLine(string.Format("{0,-10} {1}", "Id", "Title"), ConsoleColor.DarkMagenta);
            foreach (var book in Model)
            {
                ViewHelp.Write($"{book.Id,-10}", ConsoleColor.Magenta);
                ViewHelp.WriteLine($"{book.Title}", (book.Reading) ? ConsoleColor.DarkBlue : ConsoleColor.Black);
            }
        }
    }
}
