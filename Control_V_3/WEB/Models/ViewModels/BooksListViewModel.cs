using Control_V_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PadingInfo PadingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
