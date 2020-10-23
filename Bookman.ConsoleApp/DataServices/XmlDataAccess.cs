using System;


namespace Bookman.ConsoleApp.DataServices
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using Models;

    public class XmlDataAccess: IDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();

        private readonly string _file = ConfigReader.Instance.DataAccess + ".xml";

        public void Load()
        {
            if (!File.Exists(_file))
            {
                Console.WriteLine("File not exist then save");
                SaveChange();
            }

            var serializer = new XmlSerializer(typeof(List<Book>));
            using( var stream = XmlReader.Create(_file))
            {
                Books = serializer.Deserialize(stream) as List<Book>;
            }
        }

        public void SaveChange()
        {
            var serializer = new XmlSerializer(typeof(List<Book>));

            using (var stream = XmlWriter.Create(_file))
            {
                serializer.Serialize(stream, Books);
            }
        }
    }
}
