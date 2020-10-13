using System;
namespace Bookman.ConsoleApp.Views
{
    using static Framework.ViewHelp;
    using Models;
    using Framework;

    public class BookUpdateView
    {
        protected Book _model;

        public BookUpdateView(Book model)
        {
            _model = model;
        }

        public void Render()
        {
            Write("UPDATE BOOK INFORMATION\n", ConsoleColor.Green);

            foreach (var prop in typeof(Book).GetProperties())
            {
                if (!prop.CanWrite) continue;
                // print the property and its old value
                Write($"{prop.Name,ViewProperties.PADDING}:", ConsoleColor.Magenta);
                Write($"{prop.GetValue(_model)}\n");

                // input the value to the property, skip it if input is ""
                Write($"New Value[{prop.GetValue(_model).GetType()}] :", ConsoleColor.DarkGreen);
                string str = Console.ReadLine();

                if (str == "") continue;

                try
                {
                    // filter out the int and bool and using the method Parse
                    // prop.GetType => [property type]

                    prop.SetValue(_model, (prop.GetValue(_model)) switch
                    {
                        //should handle the exception here
                        int i => int.Parse(str),
                        bool b => str.StrToBool(),
                        _ => str,
                    });
                }
                catch (FormatException exception)
                {
                    Write($"ERROR: {exception.Message}\n", ConsoleColor.Red);
                }

            }
            Console.WriteLine();
        }
    }
}
