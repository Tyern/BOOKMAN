using System;
using System.Collections.Generic;
using System.IO;
using Bookman.ConsoleApp.Models;
using Newtonsoft.Json;

namespace Bookman.ConsoleApp.DataServices
{
    public class JsonDataAccess : IDataAccess
    {
        private string _file = ConfigReader.Instance.DataAccess + ".json";
        public List<Book> Books { set; get; } = new List<Book>();

        public void Load()
        {
            if (!File.Exists(_file))
            {
                Console.WriteLine("File is not exist, then save");
                SaveChange();
            }

            var serialize = new JsonSerializer();
            using (var stream = new StreamReader(_file))
            using (var jreader = new JsonTextReader(stream))
            {
                Books = serialize.Deserialize<List<Book>>(jreader);
            }
        }

        public void SaveChange()
        {
            var serialize = new JsonSerializer();
            using (var stream = new StreamWriter(_file))
            using (var jwriter = new JsonTextWriter(stream))
            {
                serialize.Serialize(jwriter, Books);
            }
        }
    }
}
