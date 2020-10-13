using System;

using System.Collections.Generic;

namespace Bookman.ConsoleApp.DataServices
{
    using Models;

    public class Repository
    {
        protected readonly SimpleDataAccess _context;

        public Repository(SimpleDataAccess context)
        {
            _context = context;
            _context.Load();
        }

        public void SaveChanges() => _context.SaveChanges();

        public List<Book> Books => _context.Books;

        public Book GetBookByID(int id)
        {
            foreach(var b in _context.Books)
            {
                if (id == b.Id)
                {
                    return b;
                }
            }
            return null;
        }

        public Book[] GetBook() => _context.Books.ToArray();

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

            var id = (lastIndex != 0) ? _context.Books[lastIndex].Id + 1 : 1;

            book.Id = id;

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

            if (b == null) return false;
            {
                foreach (var prop in typeof(Book).GetProperties())
                {
                    prop.SetValue(b, prop.GetValue(book));
                }
            }
            return true;
        }
    }
}
