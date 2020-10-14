using System;
using Newtonsoft;

namespace Bookman.ConsoleApp.Framework
{
    using Models;
    public class RenderToFile
    {
        /// <summary>
        /// code being duplicated (not expect)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="path"></param>
        public static void FileRender(object model, string path)
        {
            ViewHelp.WriteLine($"Saveing data to file {path}");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            System.IO.File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!", ConsoleColor.Cyan);
        }
    }
}
