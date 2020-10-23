using System;
using Bookman.ConsoleApp.Models;
using System.Linq;

namespace Bookman.ConsoleApp.Views
{
    using System.Collections.Generic;
    using Framework;
    public class BookStatView : RenderToFile<IEnumerable<IGrouping<string, Book>>>
    {

        public BookStatView(IEnumerable<IGrouping<string, Book>> model) : base(model)
        {

        }

        public override void Render()
        {
            foreach (var group in Model)
            {
                ViewHelp.WriteLine($"#{group.Key}", ConsoleColor.Magenta);
                foreach (var book in group)
                {
                    ViewHelp.WriteLine("  " + book.Title);
                }
            }
        }
    }
}
