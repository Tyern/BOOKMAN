using System;
namespace Bookman.ConsoleApp.Views
{
    using static Framework.ViewHelp;
    using Models;
    using Framework;

    public class BookUpdateView : RenderToFile<Book>
    {
        protected Book _model;

        public BookUpdateView(Book model) : base(model)
        {
            _model = model;
        }

        public override void Render()
        {
            Write("UPDATE BOOK INFORMATION\n", ConsoleColor.Green);

            string _request = $"do-update? id = {_model.Id}&";

            foreach (var prop in typeof(Book).GetProperties())
            {
                if (!prop.CanWrite || prop.Name.ToLower() == "id") continue;
                // print the property and its old value
                Write($"{prop.Name,PADDING}:", ConsoleColor.Magenta);
                Write($"{prop.GetValue(_model)}\n");

                // input the value to the property, skip it if input is ""
                Write($"New Value[{prop.GetValue(_model).GetType()}] :", ConsoleColor.DarkGreen);
                string str = Console.ReadLine();

                if (str == "") continue;

                _request += $"{prop.Name.ToLower()} = {str}&" ;

                try
                {
                    // filter out the int and bool and using the method Parse
                    // prop.GetType => [property type]
                    SetValueForProp(prop, str, _model);
                }
                catch (FormatException exception)
                {
                    Write($"ERROR: {exception.Message}\n", ConsoleColor.Red);
                }
            }

            Router.Instance.Forward(_request.Substring(0, _request.Length - 1));
            Console.WriteLine();
        }
    }
}
