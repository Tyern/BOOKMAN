using System;
using System.Collections.Generic;
using System.IO;
using Bookman.ConsoleApp.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bookman.ConsoleApp.DataServices
{
    public class BinaryDataAccess : IDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();

        private readonly string _file = ConfigReader.Instance.DataAccess + ".dat";

        public void Load()
        {
            if (!File.Exists(_file))
            {
                SaveChange();
                return;
            }

            using (FileStream stream = File.OpenRead(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Books = formatter.Deserialize(stream) as List<Book>;
            }
        }

        public void SaveChange()
        {
            using FileStream stream = File.OpenWrite(_file);
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Books);
            }
        }
    }
}
