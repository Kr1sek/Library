using Library.DB;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.Model;
using System.Data.SqlClient;
using System.Data;
using Library.MainClasses;
using Library.View;
using Library.AuthorWindows;

namespace Library
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            LibraryContext db = new LibraryContext();
            Some.ItemsSource = db.Authors.ToList();
        }

        //void ShowDetails(object sender, RoutedEventArgs e)
        //{
        //    for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
        //        if (vis is DataGridRow)
        //        {
        //            var row = (DataGridRow)vis;
        //            row.DetailsVisibility =
        //            row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        //            break;
        //        }
        //}

        void Delete(object sender, RoutedEventArgs e)
        {
            LibraryContext dba = new LibraryContext();
            int id;
            if (Some.SelectedItems.Count > 0)
            {
                Author author = new Author();
                author = Some.SelectedItem as Author;
                id = Convert.ToInt32(author.ID);
                SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
                connection.Open();
                string query = $"delete from Author where id ={id}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Some.ItemsSource = dba.Authors.ToList();
                Some.Items.Refresh();
                MessageBox.Show("Deleted");
            }
        }

        private void OpenEditAuthorWindow(object sender, RoutedEventArgs e)
        {
            
            Author author = new Author();
            author = Some.SelectedItem as Author;
            EditAuthorWindow win = new EditAuthorWindow(author);
            win.Show();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            LibraryContext dba = new LibraryContext();
            Some.ItemsSource = dba.Authors.ToList();
            Some.Items.Refresh();
        }

        private void OpenAddAuthorWindow(object sender, RoutedEventArgs e)
        {
            AddAuthorWindow win = new AddAuthorWindow();
            win.Show();
        }
    }
}

