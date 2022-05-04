using Caliburn.Micro;
using Library.DB;
using Library.MainClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AuthorViewModel
    {
        public BindableCollection<Author> Some { get; set; }

        public AuthorViewModel()
        {
            LibraryContext db = new LibraryContext();
            Some = new BindableCollection<Author>(db.Authors.ToList());
            
        }

      
    }
}
