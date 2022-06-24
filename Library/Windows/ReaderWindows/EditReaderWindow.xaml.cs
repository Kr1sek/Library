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

namespace Library.Windows.ReaderWindows
{
    /// <summary>
    /// Interaction logic for EditReaderWindow.xaml
    /// </summary>
    public partial class EditReaderWindow : Window
    {
        public Reader reader = new Reader();
        public EditReaderWindow(Reader reader)
        {
            InitializeComponent();
            this.reader = reader;
            Id.Text = this.reader.ID.ToString();
            FirstName.Text = this.reader.FirstName.ToString();
            LastName.Text = this.reader.LastName.ToString();

            BirthDay.Text = this.reader.BirthDay.ToString();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {


            Reader reader = new Reader();
            SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            connection.Open();
            string query = $"Update Reader set FirstName = '{FirstName.Text.ToString()}', LastName = '{LastName.Text.ToString()}', BirthDay = '{BirthDay.Text}' where ID = {Id.Text}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

            Close();

        }
    }
}
