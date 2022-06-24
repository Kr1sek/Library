using Library.MainClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.BookWindows
{
    /// <summary>
    /// Interaction logic for EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        public Book book = new Book();
        public EditBookWindow(Book book)
        {
            InitializeComponent();
            this.book = book;
            Id.Text = this.book.ID.ToString();
            Title.Text = this.book.Title.ToString();
            AuthorID.Text = this.book.AuthorID.ToString();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {


            Author author = new Author();
            SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            connection.Open();
            string query = $"Update Book set Title = '{Title.Text.ToString()}', AuthorID = '{AuthorID.Text.ToString()}' where ID = {Id.Text.ToString()}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

            Close();

        }
    }
}
