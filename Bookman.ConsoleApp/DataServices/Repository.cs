using System;

using System.Collections.Generic;

namespace Bookman.ConsoleApp.DataServices
{
    using System.Linq;
    using Models;

    public class Repository
    {

        protected readonly IDataAccess _context;

        public Repository(IDataAccess context)
        {
            _context = context;
            _context.Load();
        }

        public void SaveChanges() => _context.SaveChange();

        public List<Book> Books => _context.Books;

        public Book GetBookByID(int id) => _context.Books.FirstOrDefault(b => b.Id == id);

        public Book[] GetBook() => _context.Books.ToArray();

        public IEnumerable<IGrouping<string, Book>> Stats(string key = "folder")
        {
            return _context.Books.GroupBy(b => System.IO.Path.GetDirectoryName(b.File));
        }

        public Book[] GetBook(string key)
        {
            var temp = new List<Book>();

            key = key.ToLower();

            foreach (var b in _context.Books)
            {
                if (b.Title.ToLower().Contains(key) ||
                    b.Authors.ToLower().Contains(key) ||
                    b.Publisher.ToLower().Contains(key) ||
                    b.Tags.ToLower().Contains(key) ||
                    b.Description.ToLower().Contains(key))

                    temp.Add(b);
            }

            return temp.ToArray();
        } 

        public void Add(Book book)
        {
            int lastIndex = _context.Books.Count - 1;

            book.Id = (lastIndex >= 0) ? _context.Books[lastIndex].Id + 1 : 1; ;

            _context.Books.Add(book);
        }

        public bool Delete(int id)
        {
            Book b = GetBookByID(id);

            if (b == null) return false;

            _context.Books.Remove(b);

            return true;
        }

        public bool Update(int id, Book book)
        {
            Book b = GetBookByID(id);

            if (b == null)
                return false;

            foreach (var prop in typeof(Book).GetProperties())
            {
                if (!prop.CanWrite || prop.Name.ToLower() == "id") continue;

                prop.SetValue(b, Convert.ChangeType(prop.GetValue(book), prop.PropertyType));
            }
            return true;
        }

        public void Clear()
        {
            _context.Books.Clear();
        }
    }
}
