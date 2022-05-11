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

namespace Library
{
    /// <summary>
    /// Logika interakcji dla klasy EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public Author author = new Author();
        public EditWindow(Author author)
        {
            InitializeComponent();
            this.author = author;
            Id.Text = this.author.ID.ToString();
            FirstName.Text = this.author.FirstName.ToString();
            LastName.Text = this.author.LastName.ToString();
            
            BirthDay.Text = this.author.BirthDay.ToString();
        }
        public string BDayEdit(string e)
        {

            string date = e.ToString();
            string result = "";
            for (int i = 9; i >= 0; i--)
            {
                if(date[i] == '.')
                {
                    result += '-';
                }
                else
                {
                    result += date[i];
                }
            }
            return result;
        }
        private void Edit(object sender, RoutedEventArgs e)
        {

            LibraryContext dba = new LibraryContext();
            Author author = new Author();
            SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            connection.Open();
            string query = $"Update Author set FirstName = '{FirstName.Text.ToString()}', LastName = '{LastName.Text.ToString()}', BirthDay = '{BirthDay.Text}' where ID = {Id.Text}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

            Close();

        }
      
    }
}
