using LISy.Entities.Documents;
using LISy.Managers;
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
using System.Windows.Shapes;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для BookModifyWindow.xaml
    /// </summary>
    public partial class BookModifyWindow : Window
    {
        private Book book;
        private LibrarianWorkWindow workWindow;
        public BookModifyWindow(Book book, LibrarianWorkWindow workWindow)
        {
            InitializeComponent();
            this.book = book;
            this.workWindow = workWindow;
            title_of_book.Text = book.Title;
            author_of_book.Text = book.Authors;
            publisher_of_book.Text = book.Publisher;
            edition_of_book.Text = book.Edition;
            year_of_book.Text = Convert.ToString(book.Year);
            keywords_of_book.Text = book.KeyWords;
            price_of_book.Text = Convert.ToString(book.Price);
            best_seller_of_book.IsEnabled = book.IsBestseller;
            
        }

        private void delete_book_from_db_Click(object sender, RoutedEventArgs e)
        {
            LibrarianDataManager.DeleteDocument(book);
            workWindow.UpdateDataGridBook();
            this.Close();
        }

        private void cancel_for_book_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_changes_in_db_Click(object sender, RoutedEventArgs e)
        {
            book.Title = title_of_book.Text;
            book.Authors = author_of_book.Text;
            book.Publisher = publisher_of_book.Text;
            book.Edition = edition_of_book.Text;
            book.Year = Convert.ToInt32(year_of_book.Text);
            book.KeyWords = keywords_of_book.Text;
            book.Price = Convert.ToInt32(price_of_book.Text);
            LibrarianDataManager.EditDocument(book);
            workWindow.UpdateDataGridBook();
            this.Close();
        }

        private void TextBox_titleChanged(object sender, TextChangedEventArgs e)
        {
            title_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(title_of_book);
        }

        private void author_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            author_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(author_of_book);
        }

        private void publisher_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            publisher_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(publisher_of_book);
        }

        private void TextBox_Edition_Changed(object sender, TextChangedEventArgs e)
        {
            edition_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(edition_of_book);
        }

        private void year_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            year_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(year_of_book);
        }

        private void keywords_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            keywords_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(keywords_of_book);
        }

        private void price_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            price_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(price_of_book);
        }

        private void copy_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            copy_of_book.Text = InputFieldsManager.ReturnStringFromTextBox(copy_of_book);
        }

        private void room_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void level_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
