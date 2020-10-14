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

        public void Single(int id, string path = "")
        {
            BookSingleView view = new BookSingleView(repository.GetBookByID(id));

            if (!string.IsNullOrEmpty(path)) BookSingleView
                    .FileRender(repository.GetBookByID(id), path);

            view.Render();
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

        public void List(string path = "")
        {
            Book[] models = repository.GetBook();

            var view = new BookListView(models);

            //foreach (Book model in models)
            if (!string.IsNullOrEmpty(path)) BookListView
                    .FileRender(models, path);

            view.Render();
        }
    }
}
