using System;
using System.Collections.Generic;


namespace Bookman.ConsoleApp.Framework
{
    public class Parameter
    {
        /// <summary>
        /// save the user input key-value pairs
        /// </summary>
        private readonly Dictionary<string, string> _pairs = new Dictionary<string, string>();

        /// <summary>
        /// overload indexing, allow user to call object[key]
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            //return null if the string is not exist
            get => (_pairs.ContainsKey(key)) ? _pairs[key] : null;
            set => _pairs[key] = value;
        }

        public bool ContainsKey(string key)
        {
            return (_pairs.ContainsKey(key)) ;
        }

        /// <summary>
        /// add the "key = val & key = val" format to _pairs
        /// </summary>
        /// <param name="parameter"></param>
        public Parameter(string parameter)
        {
            if (parameter.Trim() == "") return;
            
            var p = parameter.Split('&');       
            string key, val;
            foreach (string keyVal in p)    
            {
                key = keyVal.Split('=')[0].Trim();
                val = keyVal.Split('=')[1].Trim();

                _pairs.Add(key, val);
            }
        }
    }
}
