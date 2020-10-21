using System;
namespace Bookman.ConsoleApp.Models
{
    public class Book
    {
        int _id = 1;
        /// <summary>
        /// Id of the book (default: 1)
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (value > 1) { _id = value; }
            }
        }

        string _authors = "Unknown authors";
        /// <summary>
        /// Authors of the book (default: "Unknown authors")
        /// </summary>
        public string Authors
        {
            get => _authors;
            set
            {
                if (value.Trim() != "") { _authors = value; }
            }
        }

        string _title = "Unknown title";
        /// <summary>
        /// Title of the book (default : "Unknown title")
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (value.Trim() != "") { _title = value; }
            }
        }

        string _publisher = "Unknown publisher";
        /// <summary>
        /// Publisher of the book ( default: "Unknown publisher")
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            set
            {
                if (value.Trim() != "") { _publisher = value; }
            }
        }

        int _year = 0;
        /// <summary>
        /// Year of the book ( value must be greater than 1950)
        /// </summary>
        public int Year
        {
            get => _year;
            set
            {
                if (value >= 1950) { _year = value; }
            }
        }

        int _edition = 1;
        /// <summary>
        /// Edition must be greater than or equal to 1 (default : 1)
        /// </summary>
        int Edition
        {
            get => _edition;
            set
            {
                if (value > 1) { _edition = value; }
            }
        }

        string _isbn = "";
        /// <summary>
        /// International Standard Book Number (optional) (default : "")
        /// </summary>
        public string ISBN
        {
            get => _isbn;
            set
            {
                if (value.Trim() != "") { _isbn = value; }
            }
        }

        string _tags = "";
        /// <summary>
        /// Tags (optional) (default : "")
        /// </summary>
        public string Tags
        {
            get => _tags;
            set
            {
                if (value.Trim() != "") { _tags = value; }
            }
        }

        string _description = "";
        /// <summary>
        /// Description of the book (optional) (default : "")
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (value.Trim() != "") { _description = value; }
            }
        }

        int _rating = 0;
        /// <summary>
        /// Rate of the book (default 0)
        /// </summary>
        public int Rating
        {
            get => _rating;
            set
            {
                if (1 <= value && value <= 5) { _rating = value; }
            }
        }

        bool _reading = false;
        /// <summary>
        /// The book is reading or not (default : false)
        /// </summary>
        public bool Reading
        {
            get => _reading;
            set => _reading = value;
        }

        string _file = "";
        /// <summary>
        /// Path to the book (default : "")
        /// </summary>
        public string File
        {
            get => _file;
            set
            {
                if (System.IO.File.Exists(value)) {_file = value; }
            }
        }

        /// <summary>
        /// Name of the pdf file (default : "")
        /// </summary>
        public string FileName { get => System.IO.Path.GetFileName(File); }


        public override string ToString()
        {
            string str = "";
            foreach (var prop in typeof(Book).GetProperties())
            {
                str += $"{prop.Name} = {prop.GetValue(this)}|";
            }
            return str;
        }
    }
}
