using System;
namespace Bookman.ConsoleApp.Framework
{
    public static class Extension
    {
        public static string BoolObjToStr(this object value)
        {
            if (value is bool) return (bool)value ? "YES" : "NO";
            else
            {
                return value.ToString();
            }
        }

        public static bool TryStrToBool(this string input_str, out bool output_bool)
        {
            if (input_str.ToLower() == "y" || input_str.ToLower() == "yes")
            {
                output_bool = true;
                return true;
            }
            if (input_str.ToLower() == "n" || input_str.ToLower() == "no")
            {
                output_bool = false;
                return true;
            }
            else output_bool = false;
            return false;
        }

        public static bool StrToBool(this string input_str)
        {
            if (input_str.ToLower() == "y" || input_str.ToLower() == "yes")
            {

                return true;
            }

            if (input_str.ToLower() == "n" || input_str.ToLower() == "no")
            {
                return false;
            }

            return bool.Parse(input_str);
        }

        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }


    }
}
