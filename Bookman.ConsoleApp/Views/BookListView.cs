using System;

namespace Bookman.ConsoleApp.Models
{
    using Framework;

    public class BookListView : RenderToFile<Book[]>
    {
        protected Book[] _model;
        /// <summary>
        /// constructor to initialize the list of book class
        /// </summary>
        /// <param name="model"></param>
        public BookListView(Book[] model) : base(model)
        {
            _model = model;
        }

        public override void Render()
        {
            if (_model.Length == 0)
            {
                ViewHelp.WriteLine("No book found", ConsoleColor.DarkGreen);
                return;
            }
            ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);

            ViewHelp.WriteLine(string.Format("{0,-10} {1}", "Id", "Title"), ConsoleColor.DarkMagenta);
            foreach (var book in _model)
            {
                ViewHelp.Write($"{book.Id,-10}", ConsoleColor.Magenta);
                ViewHelp.WriteLine($"{book.Title}", (book.Reading) ? ConsoleColor.DarkBlue : ConsoleColor.Black);
            }
        }
    }
}
