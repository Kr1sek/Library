using Library.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DB
{
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var author = new List<Author>
            {
                new Author{FirstName="Adi1", LastName="xd1", BirthDay=DateTime.Parse("2000-06-01"),},
                new Author{FirstName="Adi2", LastName="xd2", BirthDay=DateTime.Parse("2010-07-01")},
                new Author{FirstName="Adi3", LastName="xd3", BirthDay=DateTime.Parse("2020-01-01")},
                new Author{FirstName="Adi4", LastName="xd4", BirthDay=DateTime.Parse("2015-10-01")},
                new Author{FirstName="Adi5", LastName="xd5", BirthDay=DateTime.Parse("2004-02-01")},
            };
            author.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var reader = new List<Reader>
            {
                new Reader{FirstName="oli1", LastName="olp1", BirthDay=DateTime.Parse("2020-02-01")},
                new Reader{FirstName="oli2", LastName="olp2", BirthDay=DateTime.Parse("2010-04-01")},
                new Reader{FirstName="oli3", LastName="olp3", BirthDay=DateTime.Parse("2022-06-01")},
                new Reader{FirstName="oli4", LastName="olp4", BirthDay=DateTime.Parse("2012-08-01")},
                new Reader{FirstName="oli5", LastName="olp5", BirthDay=DateTime.Parse("2014-10-01")},
            };
            reader.ForEach(r => context.Readers.Add(r));
            context.SaveChanges();

            var book = new List<Book>
            {
                new Book{Title="Title1", AuthorID=1,ReaderID=1, RealiseDate=DateTime.Parse("1950-02-01")},
                new Book{Title="Title2", AuthorID=1,ReaderID=1, RealiseDate=DateTime.Parse("1951-04-01")},
                new Book{Title="Title3", AuthorID=2,RealiseDate=DateTime.Parse("1952-02-01")},
                new Book{Title="Title4", AuthorID=2,ReaderID=2, RealiseDate=DateTime.Parse("1953-08-01")},
                new Book{Title="Title5", AuthorID=3,RealiseDate=DateTime.Parse("1954-06-01")},
                new Book{Title="Title6", AuthorID=3,ReaderID=5, RealiseDate=DateTime.Parse("1955-01-01")},
                new Book{Title="Title7", AuthorID=4,RealiseDate=DateTime.Parse("1956-12-01")},
                new Book{Title="Title8", AuthorID=4,RealiseDate=DateTime.Parse("1957-10-01")},
                new Book{Title="Title9", AuthorID=5,ReaderID=4, RealiseDate=DateTime.Parse("1958-08-01")},
                new Book{Title="Title10", AuthorID=5,RealiseDate=DateTime.Parse("1990-01-01")},
            };  
            book.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

        }
    }
}
