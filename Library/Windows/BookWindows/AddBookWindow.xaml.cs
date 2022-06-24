using Library.DB;
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

namespace Library.Windows.BookWindows
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            LibraryContext db = new LibraryContext();
            IEnumerable<Book> all = from el in db.Books select el;
            int id = all.Count();
            using (SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                try
                {
                    Book book = new Book();
                    connection.Open();
                    string query = $"SET IDENTITY_INSERT dbo.Book ON; insert into Book (ID,ReaderID,AuthorID,Title,RealiseDate) values ('{id + 1}', '{ReaderID.Text.ToString()}', '{AuthorID.Text.ToString()}', '{Title.Text}', '{RealiseDate.Text}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch (Exception ex)
                {
                    excep.Text = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            };
        }
    }
}
