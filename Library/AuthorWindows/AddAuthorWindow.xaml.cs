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

namespace Library.AuthorWindows
{
    /// <summary>
    /// Logika interakcji dla klasy AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow : Window
    {
        public AddAuthorWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            LibraryContext db = new LibraryContext();
            IEnumerable<Author> all = from el in db.Authors select el;
            int id = all.Count();
            using (SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                //try
                //{
                    Author author = new Author();    
                    connection.Open();
                    string query = $"SET IDENTITY_INSERT dbo.Author ON; insert into Author (ID, FirstName, LastName, BirthDay) values ('{id+1}', '{FirstName.Text.ToString()}', '{LastName.Text.ToString()}', '{BirthDay.Text}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Close();
                //}
                //catch (Exception ex)
                //{
                //    excep.Text = "Błąd formatu daty. Należy wprowadzić w formacie MM.DD.YYYY";
                //}
                //finally
                //{
                //    connection.Close();
                //}
            };
        }
    }
}
