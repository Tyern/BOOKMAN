using System;
namespace Bookman.ConsoleApp.Controllers
{
    using DataServices;
    using Models;
    using Views;

    public class BookController
    {
        private Repository repository;

        public BookController(SimpleDataAccess context)
        {
            repository = new Repository(context);
        }

        public void Single(int id)
        {
            BookSingleView bookSingleView = new BookSingleView(repository.GetBookByID(id));
            bookSingleView.Render();
        }

        public void Create()
        {
            BookCreateView bookCreateView = new BookCreateView();
            bookCreateView.Render();
        }

        public void Update(int id)
        {
            BookUpdateView bookUpdateView = new BookUpdateView(repository.GetBookByID(id));
            bookUpdateView.Render();
        }

        public void List()
        {
            Book[] model = repository.GetBook();

            var view = new BookListView(model);

            view.Render();
        }
    }
}
