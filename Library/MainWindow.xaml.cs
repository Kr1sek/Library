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
using Library.AuthorWindows;
using Library.BookWindows;
using Library.Windows.BookWindows;
using Library.Windows.ReaderWindows;

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
            Books.ItemsSource = db.Books.ToList();
            Readers.ItemsSource = db.Readers.ToList();
        }
        //sekcja klasy Author
        void DeleteAuthor(object sender, RoutedEventArgs e)
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

        private void RefreshAuthors(object sender, RoutedEventArgs e)
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

        //sekcja klasy Book
        void DeleteBook(object sender, RoutedEventArgs e)
        {
            LibraryContext dba = new LibraryContext();
            int id;
            if (Books.SelectedItems.Count > 0)
            {
                Book book = new Book();
                book = Books.SelectedItem as Book;
                id = Convert.ToInt32(book.ID);
                SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
                connection.Open();
                string query = $"delete from Book where id ={id}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Books.ItemsSource = dba.Books.ToList();
                Books.Items.Refresh();
                MessageBox.Show("Deleted");
            }
        }

        private void OpenEditBookWindow(object sender, RoutedEventArgs e)
        {

            Book booked = new Book();
            booked = Books.SelectedItem as Book;
            EditBookWindow win = new EditBookWindow(booked);
            win.Show();
        }

        private void RefreshBook(object sender, RoutedEventArgs e)
        {
            LibraryContext dba = new LibraryContext();
            Books.ItemsSource = dba.Books.ToList();
            Books.Items.Refresh();
        }

        private void OpenAddBookWindow(object sender, RoutedEventArgs e)
        {
            AddBookWindow win = new AddBookWindow();
            win.Show();
        }

        //Sekcja Reader
        void DeleteReader(object sender, RoutedEventArgs e)
        {
            LibraryContext dba = new LibraryContext();
            int id;
            if (Readers.SelectedItems.Count > 0)
            {
                Reader reader = new Reader();
                reader = Readers.SelectedItem as Reader;
                id = Convert.ToInt32(reader.ID);
                SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
                connection.Open();
                string query = $"delete from Reader where id ={id}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Readers.ItemsSource = dba.Readers.ToList();
                Readers.Items.Refresh();
                MessageBox.Show("Deleted");
            }
        }

        private void OpenEditReaderWindow(object sender, RoutedEventArgs e)
        {

            Reader reader = new Reader();
            reader = Readers.SelectedItem as Reader;
            EditReaderWindow win = new EditReaderWindow(reader);
            win.Show();
        }

        private void RefreshReaders(object sender, RoutedEventArgs e)
        {
            LibraryContext dba = new LibraryContext();
            Readers.ItemsSource = dba.Readers.ToList();
            Readers.Items.Refresh();
        }

        private void OpenAddReadersWindow(object sender, RoutedEventArgs e)
        {
            AddReaderWindow win = new AddReaderWindow();
            win.Show();
        }
    }
}

