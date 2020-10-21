using System;
using Newtonsoft;

namespace Bookman.ConsoleApp.Framework
{
    using Models;

    public abstract class RenderToFile
    {

        public RenderToFile() { }

        public abstract void Render();
    }

    public abstract class RenderToFile<T> : RenderToFile
    {
        // Use this to call function that needed
        protected T Model;

        public RenderToFile(T model)
        {
            Model = model;
        }

        /// <summary>
        /// dump the object to the path json format file
        /// </summary>
        /// <param name="model"></param>
        /// <param name="path"></param>
        public virtual void FileRender(string path)
        {
            ViewHelp.WriteLine($"Saving data to file {path}");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            System.IO.File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!", ConsoleColor.Cyan);
        }

    }
}
