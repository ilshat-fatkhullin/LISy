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

        private void av_title_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(av_title_text_box);
        }

        private void authors_av_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(authors_av_text_box);
        }

        private void av_copy_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_copy_text_box);
        }

        private void av_level_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_level_text_box);
        }

        private void av_room_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_room_text_box);
        }

        private void add_av_Click(object sender, RoutedEventArgs e)
        {   
            //add to grid our labels for av
            av_title_label.Visibility = Visibility.Visible;
            authors_av_label.Visibility = Visibility.Visible;
            av_room_label.Visibility = Visibility.Visible;
            av_level_label.Visibility = Visibility.Visible;
            av_copy_label.Visibility = Visibility.Visible;
            av_price_label.Visibility = Visibility.Visible;
            av_keywords_label.Visibility = Visibility.Visible;

            //add to grid textBoxes for av
            av_title_text_box.Visibility = Visibility.Visible;
            authors_av_text_box.Visibility = Visibility.Visible;
            av_room_text_box.Visibility = Visibility.Visible;
            av_level_text_box.Visibility = Visibility.Visible;
            av_copy_text_box.Visibility = Visibility.Visible;
            av_add_to_db.Visibility = Visibility.Visible;
            av_key_words_text_box.Visibility = Visibility.Visible;
            av_price_text_box.Visibility = Visibility.Visible;

        }

        private void av_add_to_db_Click(object sender, RoutedEventArgs e)
        {
            if (av_title_text_box.Text != null &&
                authors_av_text_box.Text != null &&
                av_room_text_box.Text != null &&
                av_level_text_box.Text != null &&
                av_copy_text_box.Text != null &&
                av_key_words_text_box.Text != null &&
                av_price_text_box.Text != null)
            {
                AVMaterial av_material = new AVMaterial(InputFieldsManager.ReturnStringFromTextBox(authors_av_text_box), InputFieldsManager.ReturnStringFromTextBox(av_title_text_box), InputFieldsManager.ReturnStringFromTextBox(av_key_words_text_box),"", Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_price_text_box)));
                DocumentsDataManager.AddDocument(av_material);
                this.Close();
            }
            
        }

        private void av_key_words_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(av_key_words_text_box);
        }


        private void Av_price_text_box(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_price_text_box);
        }
    }
}
