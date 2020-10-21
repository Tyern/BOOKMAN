using System;
using System.Linq;
using System.Reflection;

namespace Bookman.ConsoleApp.Framework
{
    using Models;


    public class ViewHelp
    {
        public const int PADDING = -15;
        /// <summary>
        /// Print the string with color 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        public static void Write(string str, ConsoleColor color = ConsoleColor.Black, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            if (resetColor) Console.ResetColor();
        }
        /// <summary>
        /// Write the string in the center padding with the spacing
        /// </summary>
        public static void WriteCenter(string str, int spacing = 0, ConsoleColor color = ConsoleColor.Black, char space = ' ')
        {
            spacing = System.Math.Max(spacing, str.Length);

            int leftAllign = (spacing - str.Length) / 2;
            int rightAllign = (spacing - leftAllign - str.Length);

            Write(new string(space, leftAllign));
            Write(str, color);
            Write(new String(space, rightAllign));
        }

        /// <summary>
        /// PrintLine the string with color 
        /// </summary>
        public static void WriteLine(string str = "", ConsoleColor color = ConsoleColor.Black, params string[] param)
        {
            Write(str, color);
            Console.WriteLine();
            return;
        }
        /// <summary>
        /// Set Value to the property regard less of the type of the property is string, int, or bool
        /// </summary>
        public static void SetValueForProp(PropertyInfo prop, string str, Book book)
        {
            prop.SetValue(book, (prop.GetValue(book)) switch
            {
                //should handle the exception here
                int i => int.Parse(str),
                bool b => str.StrToBool(),
                _ => str,
            });
        }
    }
}
