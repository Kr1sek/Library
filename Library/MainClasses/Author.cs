using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MainClasses
{
    public class Author : IGetObject
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Book> Bookss { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
