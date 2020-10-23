using System;
namespace Bookman.ConsoleApp.Controllers
{
    using DataServices;
    using Models;
    using Views;

    public class BookController : ControllerBase
    {
        private Repository repository;
        
        public BookController(IDataAccess context) =>
            repository = new Repository(context);

        /// <summary>
        /// call single if the both parameter is not provided.
        /// call single-file if the both parameter is specified.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        public void Single(int id = 0, string path = "")
        {
            BookSingleView view = new BookSingleView(repository.GetBookByID(id));
            Render(view, path, both : true);
        }

        public void Create(Book book = null)
        {
            if (book == null)
            {
                BookCreateView bookCreateView = new BookCreateView();
                Render(bookCreateView);
            }
            else
            {
                repository.Add(book);
                Success("Book Created");
            }
        }

        public void Update(int id = 0, Book book = null)
        {
            if (book == null)
            {
                BookUpdateView bookUpdateView = new BookUpdateView(repository.GetBookByID(id));
                Render(bookUpdateView);
            }
            else
            {
                if (repository.Update(id, book))
                    Success($"Updated book with Id: {id}");

                else Inform($"No book with given Id: {id}");
            }
        }

        public void Delete(int id)
        {
            if (repository.Delete(id))
                Success($"Deleted book with Id: {id}");

            else Inform($"No book with given Id: {id}");
        }

        /// <summary>
        /// call list if the both parameter is not provided.
        /// call list-file if the both parameter is specified
        /// </summary>
        /// <param name="path"></param>
        public void List(string path = "")
        {
            Book[] models = repository.GetBook();
            BookListView view = new BookListView(models);
            Render(view, path, both : true);

            Success("Book Listed");
        }
        /// <summary>
        /// filter and print out the book list view which contain the given string
        /// </summary>
        public void Filter(string str)
        {
            Book[] books = repository.GetBook(str);
            Render(new BookListView(books));
        }

        public void Clear(bool force = false)
        {
            if (force == false)
            {
                Confirm("Do you want to clear all the book in repository", "clear ? force = y");
            }
            else
                repository.Clear();
        }

        public void ViewStats()
        {
            var view = new BookStatView(repository.Stats());
            Render(view);
        }
    }
}
