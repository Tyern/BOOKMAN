using System;

namespace Bookman.ConsoleApp.Views
{
    using static Framework.ViewHelp;
    using Models;
    using Framework;

    class BookSingleView
    {
        protected Book Model;

        /// <summary>
        /// Initialize the object with the book wanting to show
        /// </summary>
        /// <param name="model"></param>
        public BookSingleView(Book model)
        {
            Model = model;
        }

        /// <summary>
        /// print out the book info if the model is not null 
        /// </summary>
        public void Render()
        {
            if (Model == null)
            {
                WriteLine("BOOK NOT FOUND", ConsoleColor.Red);
                return;
            }

            WriteLine("Detail of the book", ConsoleColor.Green);
            Console.WriteLine();

            foreach (var prop in Model.GetType().GetProperties())
            {
                if (prop.Name == "Id") continue;
                Console.WriteLine($"{prop.Name,ViewProperties.PADDING}: {prop.GetValue(Model).BoolObjToStr()}");
            }

            
        }
    }
}
