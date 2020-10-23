using System;
using System.Collections.Generic;
using Bookman.ConsoleApp.Models;

namespace Bookman.ConsoleApp.DataServices
{
    public interface IDataAccess
    {
        List<Book> Books { set; get; }

        void Load();
        void SaveChange();
    }
}
