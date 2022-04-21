﻿using Library.DB;
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
            
            LibraryContext library = new LibraryContext();

            AuthorList.ItemsSource = library.Authors.ToList();
            BookList.ItemsSource = library.Books.ToList();
            ReadersList.ItemsSource = library.Readers.ToList();

        }

        
    }
}
