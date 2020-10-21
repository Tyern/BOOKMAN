using System;

namespace Bookman.ConsoleApp.Views
{
    using static Framework.ViewHelp;
    using Models;
    using Framework;

    class BookSingleView : RenderToFile<Book>
    {
        protected Book _model;

        /// <summary>
        /// Initialize the object with the book wanting to show
        /// </summary>
        /// <param name="model"></param>
        public BookSingleView(Book model) : base(model)
        {
            _model = model;
        }

        /// <summary>
        /// print out the book info if the model is not null 
        /// </summary>
        public override void Render()
        {
            if (_model == null)
            {
                WriteLine("BOOK NOT FOUND", ConsoleColor.Red);
                return;
            }

            WriteLine("Detail of the book", ConsoleColor.Green);
            Console.WriteLine();

            foreach (var prop in _model.GetType().GetProperties())
            {
                if (prop.Name == "Id") continue;
                Console.WriteLine($"{prop.Name, PADDING}: {prop.GetValue(_model).BoolObjToStr()}");
            }

            
        }
    }
}
