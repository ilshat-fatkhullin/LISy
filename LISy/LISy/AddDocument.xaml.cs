using LISy.Entities.Documents;
using LISy.Managers;
using LISy.Managers.DataManagers;
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
    /// Логика взаимодействия для AddDocument.xaml
    /// </summary>
    public partial class AddDocument : Window
    {
        public AddDocument()
        {
            InitializeComponent();
        }


        private void author_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(author_of_book);
        }

        private void publisher_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(publisher_of_book);
        }


        private void year_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(year_of_book);
        }

        private void keywords_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(keywords_of_book);
        }

        private void price_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(price_of_book);
        }

        private void copy_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(copy_of_book);
        }

        private void room_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(room_of_book);
        }

        private void level_of_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(level_of_book);
        }

        private void add_book_Click(object sender, RoutedEventArgs e)
        {
            //появление лабелов на экране при добавление книжки
            title_label.Visibility = Visibility.Visible;
            author_of_book_label.Visibility = Visibility.Visible;
            edition_of_book_label.Visibility = Visibility.Visible;
            publisher_label.Visibility = Visibility.Visible;
            year_label.Visibility = Visibility.Visible;
            best_seller_of_book.Visibility = Visibility.Visible;
            keywords_label.Visibility = Visibility.Visible;
            price_label.Visibility = Visibility.Visible;
            copy_label.Visibility = Visibility.Visible;
            room_label.Visibility = Visibility.Visible;
            book_label_level.Visibility = Visibility.Visible;
            //появление текст боксов для заполнения
            title_of_book.Visibility = Visibility.Visible;
            author_of_book.Visibility = Visibility.Visible;
            edition_of_book.Visibility = Visibility.Visible;
            year_of_book.Visibility = Visibility.Visible;
            keywords_of_book.Visibility = Visibility.Visible;
            price_of_book.Visibility = Visibility.Visible;
            copy_of_book.Visibility = Visibility.Visible;
            room_of_book.Visibility = Visibility.Visible;
            level_of_book.Visibility = Visibility.Visible;
            add_book_to_db.Visibility = Visibility.Visible;
            publisher_of_book.Visibility = Visibility.Visible;
        }

        private void add_book_to_db_Click(object sender, RoutedEventArgs e)
        {
            bool is_best_seller = false;
            if (best_seller_of_book.IsChecked == true)
            {
                is_best_seller = true;
            }
            if (title_of_book.Text !=null &&
                author_of_book.Text !=null &&
                publisher_of_book.Text != null &&
                edition_of_book.Text != null &&
                year_of_book.Text != null &&
                keywords_of_book.Text != null &&
                price_of_book.Text != null &&
                copy_of_book.Text != null &&
                room_of_book.Text != null &&
                level_of_book.Text != null)
            {
                Book book = new Book(InputFieldsManager.ReturnStringFromTextBox(author_of_book), InputFieldsManager.ReturnStringFromTextBox(title_of_book), InputFieldsManager.ReturnStringFromTextBox(publisher_of_book), InputFieldsManager.ReturnStringFromTextBox(edition_of_book), Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(year_of_book)),is_best_seller, InputFieldsManager.ReturnStringFromTextBox(keywords_of_book),"", Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(price_of_book)));
                DocumentsDataManager.AddDocument(book);
                this.Close();
            }


        }

        private void TextBox_titleChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(title_of_book);
        }

        private void TextBox_Edition_Changed(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(edition_of_book);
        }
    }
}
