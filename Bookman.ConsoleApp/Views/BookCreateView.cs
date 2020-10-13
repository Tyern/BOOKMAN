using System;
namespace Bookman.ConsoleApp.Views
{
    using Models;
    using static Framework.ViewHelp;
    using Framework;

    public class BookCreateView
    {
        public void Render()
        {
            Write("CREATE A NEW BOOK/n", ConsoleColor.Green);
            Console.WriteLine();

            Book model = new Book();

            foreach (var prop in typeof(Book).GetProperties())
            {
                if (!prop.CanWrite) continue;
                // print the property if it can be write and input the value to it
                Write($"{prop.Name,ViewProperties.PADDING}[{prop.GetValue(model).GetType()}]:", ConsoleColor.Magenta);
                string str = Console.ReadLine();

                try
                {
                    // filter out the int and bool and using the method Parse
                    // prop.GetType => [property type]

                    prop.SetValue(model, (prop.GetValue(model)) switch
                    {
                        //should handle the exception here
                        int i => int.Parse(str),
                        bool b => str.StrToBool(),
                        _ => str,
                    }) ;
                } catch (FormatException exception)
                {
                    Write($"ERROR: {exception.Message}\n", ConsoleColor.Red);
                }

            }
            Console.WriteLine();
        }
    }
}
