
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MainClasses
{
    public class Book
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public int? ReaderID { get; set; }
        public string Title { get; set; }
        public DateTime RealiseDate { get; set; }
        public virtual Author Author { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
