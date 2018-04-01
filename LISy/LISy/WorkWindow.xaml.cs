using LISy.Entities.Documents;
using LISy.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LISy.Entities.Users;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private Patron patron;

        /// <summary>
        /// Give info to profile paatron will can see info about him and in future will can to make reference to labrarian to change info
        /// </summary>
        public WorkWindow(Patron patron)
        {
            InitializeComponent();
            this.patron = patron;
        }

        ///<summary>
        ///this button will be an action to begin search document in DB
        ///</summary>
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {


        }
        private void button_Profile_Click(object sender, RoutedEventArgs e)
        {
            UserProfile profilelWindow = new UserProfile(patron);
            profilelWindow.Show();
        }

        private void button_Booking_Click(object sender, RoutedEventArgs e)
        {
            BookingHistory bookingHistory = new BookingHistory(patron);
            bookingHistory.Owner = this;
            bookingHistory.Show();
        }


        private void button_Info_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// loader to table grid book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_LoaderBook(object sender, RoutedEventArgs e)
        {
            UpdateDataGridBook();
        }
        
        /// <summary>
        /// loader to table grid av material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_LoaderAV_material(object sender, RoutedEventArgs e)
        {
            UptadeDataGridAV_material();
        }
        /// <summary>
        /// loader to table grid innner material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_LoaderReference_book(object sender, RoutedEventArgs e)
        {
            UpdateDataGridInnerMaterials();
        }
        
        /// <summary>
        /// update table (data grid) Book
        /// </summary>
        private void UpdateDataGridBook()
        {
            List<Book> result = new List<Book>();
            result.Clear();
            foreach (Book book in LibrarianDataManager.GetAllBooksList())
            {
                result.Add(book);
            }
            DataGridBook.ItemsSource = result;
        }
        /// <summary>
        /// update table (data grid) inner material
        /// </summary>
        private void UpdateDataGridInnerMaterials()
        {
            List<InnerMaterial> result = new List<InnerMaterial>();
            result.Clear();
            foreach (InnerMaterial inner in LibrarianDataManager.GetAllInnerMaterialsList())
            {
                result.Add(inner);
            }
            DataGridRefernce_book.ItemsSource = result;
        }
        /// <summary>
        /// update table (data grid) Journal
        /// </summary>
        private void UpdateDataGridJournal()
        {
            List<Journal> result = new List<Journal>();
            result.Clear();
            foreach (Journal journal in LibrarianDataManager.GetAllJournalsList())
            {
                result.Add(journal);
            }
            DataGridJournal.ItemsSource = result;
        }
        /// <summary>
        /// update table (data grid) AV material
        /// </summary>
        public void UptadeDataGridAV_material()
        {
            List<AVMaterial> result = new List<AVMaterial>();
            result.Clear();
            foreach (AVMaterial av_material in LibrarianDataManager.GetAllAVMaterialsList())
            {
                result.Add(av_material);
            }
            DataGridAV_material.ItemsSource = result;
        }
        /// <summary>
        /// choosing row with book -> click on it -> look info about this book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridBook_MouseUp_book(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Book book = DataGridBook.SelectedItem as Book;
            if (book == null)
                return;

            BookingInfoWindow window = new BookingInfoWindow(book, patron, this)
            {
                Owner = this
            };
            window.Show();
        }
        /// <summary>
        /// update data grid journal articles
        /// </summary>
        public void UpdateDataGridJournaArticles()
        {
            List<Article> result = new List<Article>();
            result.Clear();
            foreach (Article journalArticle in LibrarianDataManager.GetAllArticlesList())
            {
                result.Add(journalArticle);
            }
            DataGridJournalArticles.ItemsSource = result;
        }
        private void log_out_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        
        private void DataGridJournalArticles_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Article article = DataGridJournalArticles.SelectedItem as Article;
            if (article == null)
                return;
        }

        private void grid_LoaderJournalArticle(object sender, RoutedEventArgs e)
        {
            UpdateDataGridJournaArticles();
        }

        private void grid_LoaderJournal(object sender, RoutedEventArgs e)
        {
            UpdateDataGridJournal();
        }
    }
}