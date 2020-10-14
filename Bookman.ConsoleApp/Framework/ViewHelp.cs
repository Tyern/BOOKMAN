using System;
using System.Linq;

namespace Bookman.ConsoleApp.Framework
{
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
        /// PrintLine the string with color 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        /// <param name="param"></param>
        public static void WriteLine(string str, ConsoleColor color = ConsoleColor.Black, params string[] param)
        {
            Write(str, color);
            Console.WriteLine();
            return;
        }
    }
}
