using Library.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    class AuthorViewModel
    {
        LibraryContext db = new LibraryContext();

        public AuthorViewModel()
        {
            Author = db.Authors.ToList();
        }

        public IList Author { get; set; }
    }
}
