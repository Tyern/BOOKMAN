using System;
using System.Configuration;
using Bookman.ConsoleApp.DataServices;

namespace Bookman.ConsoleApp
{
    public class ConfigReader
    {
        private static ConfigReader _instance { get; set; }
        private ConfigReader() { }
        public static ConfigReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigReader();
                }
                return _instance;
            }
        }

        public IDataAccess DataAccess
        {
            get
            {
                IDataAccess dataAccess = ConfigurationManager
                    .AppSettings.Get("DataAccess").ToLower() switch
                {
                    "binary" => new BinaryDataAccess(),
                    "xml" => new XmlDataAccess(),
                    "json" => new JsonDataAccess(),
                    _ => new BinaryDataAccess()
                };

                return dataAccess;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                ConsoleColor color;
                if (Enum.TryParse<ConsoleColor>
                    (ConfigurationManager.AppSettings.Get("color"), true, out color))
                {
                    return color;
                }
                return ConsoleColor.Black;
            }
        }

        public string PromptText => ConfigurationManager.AppSettings.Get("promptText");

        public string DataFile => ConfigurationManager.AppSettings.Get("dataFile");

    }
}
