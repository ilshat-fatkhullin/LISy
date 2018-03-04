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
        private IPatron patron;

        /// <summary>
        /// Give info to profile paatron will can see info about him and in future will can to make reference to labrarian to change info
        /// </summary>
        public string[] Profile = new string[6];

        public WorkWindow(IPatron patron)
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
        ///<summary>
        ///every checked checkBox will be like a filter for seaching 
        ///</summary>
        private void checkBox_AV_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_JA_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_books_Checked(object sender, RoutedEventArgs e)
        {

        }

        ///<summary>
        ///when we find document we click button to read about this document and Book it
        ///</summary>

        private void button_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profilelWindow = new Profile();
            profilelWindow.Show();
        }

        private void button_Booking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Info_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void grid_LoaderBook(object sender, RoutedEventArgs e)
        {
            UpdateDataGridBook();
        }

        private void grid_LoaderAV_material(object sender, RoutedEventArgs e)
        {
            UptadeDataGridAV_material();
        }

        private void grid_LoaderReference_book(object sender, RoutedEventArgs e)
        {
            UpdateDataGridInnerMaterials();
        }

        private void grid_LoaderJournal_article(object sender, RoutedEventArgs e)
        {
            UpdateDataGridJournal();
        }
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
        private void UpdateDataGridJournal()
        {
            List<Journal> result = new List<Journal>();
            result.Clear();
            foreach (Journal journal in LibrarianDataManager.GetAllJournalsList())
            {
                result.Add(journal);
            }
            DataGridJournal_article.ItemsSource = result;
        }

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
    }
}