using LISy.Entities;
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
         private void make_hidden_books()
        {
            //скрытие лабелов на экране при добавление книжки
            title_label.Visibility = Visibility.Hidden;
            author_of_book_label.Visibility = Visibility.Hidden;
            edition_of_book_label.Visibility = Visibility.Hidden;
            publisher_label.Visibility = Visibility.Hidden;
            year_label.Visibility = Visibility.Hidden;
            best_seller_of_book.Visibility = Visibility.Hidden;
            keywords_label.Visibility = Visibility.Hidden;
            price_label.Visibility = Visibility.Hidden;
            copy_label.Visibility = Visibility.Hidden;
            room_label.Visibility = Visibility.Hidden;
            book_label_level.Visibility = Visibility.Hidden;
            book_coverURL_label.Visibility = Visibility.Hidden;
            //скрытие текст боксов для заполнения
            title_of_book.Visibility = Visibility.Hidden;
            author_of_book.Visibility = Visibility.Hidden;
            edition_of_book.Visibility = Visibility.Hidden;
            year_of_book.Visibility = Visibility.Hidden;
            keywords_of_book.Visibility = Visibility.Hidden;
            price_of_book.Visibility = Visibility.Hidden;
            copy_of_book.Visibility = Visibility.Hidden;
            room_of_book.Visibility = Visibility.Hidden;
            level_of_book.Visibility = Visibility.Hidden;
            add_book_to_db.Visibility = Visibility.Hidden;
            publisher_of_book.Visibility = Visibility.Hidden;
            book_cover_URL_text_box.Visibility = Visibility.Hidden;
        }
        private void make_hidden_reference_book()
        {
            //пока не знаю даже какие поля там есть
            //hide label to screen
            inner_title_label.Visibility = Visibility.Hidden;
            inner_type_label.Visibility = Visibility.Hidden;
            inner_room_label.Visibility = Visibility.Hidden;
            inner_author_label.Visibility = Visibility.Hidden;
            inner_level_label.Visibility = Visibility.Hidden;
            inner_coverUrl_label.Visibility = Visibility.Hidden;
            inner_keywords_label.Visibility = Visibility.Hidden;

            //hide text_box to screen
            inner_title_box.Visibility = Visibility.Hidden;
            inner_type_text_box.Visibility = Visibility.Hidden;
            inner_room_text_box.Visibility = Visibility.Hidden;
            inner_author_box.Visibility = Visibility.Hidden;
            inner_level_text_box.Visibility = Visibility.Hidden;
            inner_cover_url_box.Visibility = Visibility.Hidden;
            inner_keywords_text_box.Visibility = Visibility.Hidden;
            add_inner_to_db.Visibility = Visibility.Hidden;
        }
        private void make_hidden_journal()
        {
            ja_title_label.Visibility = Visibility.Hidden;
            ja_publisher_label.Visibility = Visibility.Hidden;
            ja_editors_label.Visibility = Visibility.Hidden;
            ja_issue_label.Visibility = Visibility.Hidden;
            ja_level_label.Visibility = Visibility.Hidden;
            ja_PD_label.Visibility = Visibility.Hidden;
            ja_price_label.Visibility = Visibility.Hidden;
            ja_room_label.Visibility = Visibility.Hidden;
            ja_keywords_label.Visibility = Visibility.Hidden;
            ja_coverURL_label.Visibility = Visibility.Hidden;
            ja_countOf_label.Visibility = Visibility.Hidden;

            //add text boxes for journal
            ja_title_text_box.Visibility = Visibility.Hidden;
            ja_publisher_text_box.Visibility = Visibility.Hidden;
            ja_editors_text_box.Visibility = Visibility.Hidden;
            ja_issue_text_box.Visibility = Visibility.Hidden;
            ja_level_text_box.Visibility = Visibility.Hidden;
            ja_PD_text_box.Visibility = Visibility.Hidden;
            ja_price_text_box.Visibility = Visibility.Hidden;
            ja_room_text_box.Visibility = Visibility.Hidden;
            ja_keywords_text_box.Visibility = Visibility.Hidden;
            ja_coverURL_text_box.Visibility = Visibility.Hidden;
            ja_countOf_text_box.Visibility = Visibility.Hidden;

            add_ja_to_db.Visibility = Visibility.Hidden;
        }
        private void make_hidden_av_materials()
        {
            //add to grid our labels for av
            av_title_label.Visibility = Visibility.Hidden;
            authors_av_label.Visibility = Visibility.Hidden;
            av_room_label.Visibility = Visibility.Hidden;
            av_level_label.Visibility = Visibility.Hidden;
            av_copy_label.Visibility = Visibility.Hidden;
            av_price_label.Visibility = Visibility.Hidden;
            av_keywords_label.Visibility = Visibility.Hidden;
            av_coverURL_label.Visibility = Visibility.Hidden;

            //add to grid textBoxes for av
            av_title_text_box.Visibility = Visibility.Hidden;
            authors_av_text_box.Visibility = Visibility.Hidden;
            av_room_text_box.Visibility = Visibility.Hidden;
            av_level_text_box.Visibility = Visibility.Hidden;
            av_copy_text_box.Visibility = Visibility.Hidden;
            av_add_to_db.Visibility = Visibility.Hidden;
            av_key_words_text_box.Visibility = Visibility.Hidden;
            av_price_text_box.Visibility = Visibility.Hidden;
            av_coverURL_text_box.Visibility = Visibility.Hidden;
        }

        private void cover_URL_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(book_cover_URL_text_box);
        }

        private void av_coverURL_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(av_coverURL_text_box);
        }

        private void ja_coverURL_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(ja_coverURL_text_box);
        }

        private void ja_countOf_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(ja_countOf_text_box);
        }
        private void ja_keywords_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(ja_keywords_text_box);
        }

        private void innner_title_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(inner_title_box);
        }

        private void inner_author_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(inner_author_box);
        }

        private void inner_keywords_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(inner_keywords_text_box);
        }

        private void inner_room_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(inner_room_text_box);
        }

        private void inner_level_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(inner_level_text_box);
        }

        private void inner_type_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(inner_type_text_box);
        }

        private void inner_cover_url_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(inner_cover_url_box);
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
        private void av_key_words_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(av_key_words_text_box);
        }


        private void Av_price_text_box(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_price_text_box);
        }

        private void ja_title_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(ja_title_text_box);
        }

        private void ja_publisher_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(ja_publisher_text_box);
        }

        private void ja_issue_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(ja_issue_text_box);
        }

        private void ja_editors_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(ja_editors_text_box);
        }

        private void ja_PD_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(ja_PD_text_box);
        }

        private void ja_price_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(ja_price_text_box);
        }

        private void ja_level_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(ja_level_text_box);
        }

        private void ja_room_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(ja_room_text_box);
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
            make_hidden_journal();
            make_hidden_reference_book();
            make_hidden_av_materials();
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
            book_coverURL_label.Visibility = Visibility.Visible;
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
            book_cover_URL_text_box.Visibility = Visibility.Visible;
        }
        private void add_reference_book_Click(object sender, RoutedEventArgs e)
        {
            make_hidden_av_materials();
            make_hidden_books();
            make_hidden_journal();
            //add label to screen
            inner_title_label.Visibility = Visibility.Visible;
            inner_type_label.Visibility = Visibility.Visible;
            inner_room_label.Visibility = Visibility.Visible;
            inner_author_label.Visibility = Visibility.Visible;
            inner_level_label.Visibility = Visibility.Visible;
            inner_coverUrl_label.Visibility = Visibility.Visible;
            inner_keywords_label.Visibility = Visibility.Visible;

            //add text_box to screen
            inner_title_box.Visibility = Visibility.Visible;
            inner_type_text_box.Visibility = Visibility.Visible;
            inner_room_text_box.Visibility = Visibility.Visible;
            inner_author_box.Visibility = Visibility.Visible;
            inner_level_text_box.Visibility = Visibility.Visible;
            inner_cover_url_box.Visibility = Visibility.Visible;
            inner_keywords_text_box.Visibility = Visibility.Visible;
            add_inner_to_db.Visibility = Visibility.Visible;

        }
        private void add_journal_Click(object sender, RoutedEventArgs e)
        {
            make_hidden_av_materials();
            make_hidden_reference_book();
            make_hidden_books();
            //add label for journal
            ja_title_label.Visibility = Visibility.Visible;
            ja_publisher_label.Visibility = Visibility.Visible;
            ja_editors_label.Visibility = Visibility.Visible;
            ja_issue_label.Visibility = Visibility.Visible;
            ja_level_label.Visibility = Visibility.Visible;
            ja_PD_label.Visibility = Visibility.Visible;
            ja_price_label.Visibility = Visibility.Visible;
            ja_room_label.Visibility = Visibility.Visible;
            ja_keywords_label.Visibility = Visibility.Visible;
            ja_coverURL_label.Visibility = Visibility.Visible;
            ja_countOf_label.Visibility = Visibility.Visible;
            //add text boxes for journal
            ja_title_text_box.Visibility = Visibility.Visible;
            ja_publisher_text_box.Visibility = Visibility.Visible;
            ja_editors_text_box.Visibility = Visibility.Visible;
            ja_issue_text_box.Visibility = Visibility.Visible;
            ja_level_text_box.Visibility = Visibility.Visible;
            ja_PD_text_box.Visibility = Visibility.Visible;
            ja_price_text_box.Visibility = Visibility.Visible;
            ja_room_text_box.Visibility = Visibility.Visible;
            ja_keywords_text_box.Visibility = Visibility.Visible;
            ja_coverURL_text_box.Visibility = Visibility.Visible;
            ja_countOf_text_box.Visibility = Visibility.Visible;

            add_ja_to_db.Visibility = Visibility.Visible;

        }
        private void add_av_Click(object sender, RoutedEventArgs e)
        {
            make_hidden_books();
            make_hidden_journal();
            make_hidden_reference_book();
            //add to grid our labels for av
            av_title_label.Visibility = Visibility.Visible;
            authors_av_label.Visibility = Visibility.Visible;
            av_room_label.Visibility = Visibility.Visible;
            av_level_label.Visibility = Visibility.Visible;
            av_copy_label.Visibility = Visibility.Visible;
            av_price_label.Visibility = Visibility.Visible;
            av_keywords_label.Visibility = Visibility.Visible;
            av_coverURL_label.Visibility = Visibility.Visible;
            //add to grid textBoxes for av
            av_title_text_box.Visibility = Visibility.Visible;
            authors_av_text_box.Visibility = Visibility.Visible;
            av_room_text_box.Visibility = Visibility.Visible;
            av_level_text_box.Visibility = Visibility.Visible;
            av_copy_text_box.Visibility = Visibility.Visible;
            av_add_to_db.Visibility = Visibility.Visible;
            av_key_words_text_box.Visibility = Visibility.Visible;
            av_price_text_box.Visibility = Visibility.Visible;
            av_coverURL_text_box.Visibility = Visibility.Visible;

        }




        private void add_book_to_db_Click(object sender, RoutedEventArgs e)
        {
            bool is_best_seller = false;
            if (best_seller_of_book.IsChecked == true)
            {
                is_best_seller = true;
            }
            if (title_of_book.Text != null &&
                author_of_book.Text != null &&
                publisher_of_book.Text != null &&
                edition_of_book.Text != null &&
                year_of_book.Text != null &&
                keywords_of_book.Text != null &&
                price_of_book.Text != null &&
                copy_of_book.Text != null &&
                room_of_book.Text != null &&
                level_of_book.Text != null &&
                book_cover_URL_text_box.Text != null)
            {
                Book book = new Book(InputFieldsManager.ReturnStringFromTextBox(author_of_book), InputFieldsManager.ReturnStringFromTextBox(title_of_book), InputFieldsManager.ReturnStringFromTextBox(publisher_of_book), InputFieldsManager.ReturnStringFromTextBox(edition_of_book), Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(year_of_book)), is_best_seller, InputFieldsManager.ReturnStringFromTextBox(keywords_of_book), InputFieldsManager.ReturnStringFromTextBox(book_cover_URL_text_box), Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(price_of_book)));
                DocumentsDataManager.AddDocument(book);

                Copy copy = new Copy();
                int n = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(copy_of_book));
                copy.DocumentID = DocumentsDataManager.GetDocumentId(book);
                copy.Room = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(room_of_book));
                copy.Level = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(level_of_book));
                LibrarianDataManager.AddCopy(n, copy);

                this.Close();
            }


        }

        private void av_add_to_db_Click(object sender, RoutedEventArgs e)
        {
            if (av_title_text_box.Text != null &&
                authors_av_text_box.Text != null &&
                av_room_text_box.Text != null &&
                av_level_text_box.Text != null &&
                av_copy_text_box.Text != null &&
                av_key_words_text_box.Text != null &&
                av_price_text_box.Text != null &&
                av_coverURL_text_box.Text != null)
            {
                AVMaterial av_material = new AVMaterial(InputFieldsManager.ReturnStringFromTextBox(authors_av_text_box), InputFieldsManager.ReturnStringFromTextBox(av_title_text_box), InputFieldsManager.ReturnStringFromTextBox(av_key_words_text_box),InputFieldsManager.ReturnStringFromTextBox(av_coverURL_text_box), Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_price_text_box)));
                DocumentsDataManager.AddDocument(av_material);

                Copy copy = new Copy();
                int n = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_copy_text_box));
                copy.DocumentID = DocumentsDataManager.GetDocumentId(av_material);
                copy.Room = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_room_text_box));
                copy.Level = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_level_text_box));
                LibrarianDataManager.AddCopy(n, copy);

                this.Close();
            }

        }

        private void add_ja_to_db_Click(object sender, RoutedEventArgs e)
        {
            if (ja_title_text_box.Text != null &&
                ja_publisher_text_box.Text != null &&
                ja_editors_text_box.Text != null &&
                ja_issue_text_box.Text != null &&
                ja_price_text_box.Text != null &&
                ja_room_text_box.Text != null &&
                ja_level_text_box.Text != null &&
                ja_PD_text_box.Text != null &&
                ja_coverURL_text_box.Text != null &&
                ja_countOf_text_box.Text != null)
            {
                Journal journal = new Journal(InputFieldsManager.ReturnStringFromTextBox(ja_editors_text_box), InputFieldsManager.ReturnStringFromTextBox(ja_title_text_box), InputFieldsManager.ReturnStringFromTextBox(ja_publisher_text_box), Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(ja_issue_text_box)) , InputFieldsManager.ReturnStringFromTextBox(ja_PD_text_box), InputFieldsManager.ReturnStringFromTextBox(ja_keywords_text_box),InputFieldsManager.ReturnStringFromTextBox(ja_coverURL_text_box),Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(ja_price_text_box)));
                DocumentsDataManager.AddDocument(journal);

                Copy copy = new Copy();
                int n = Convert.ToInt32(ja_countOf_text_box.Text);
                copy.DocumentID = DocumentsDataManager.GetDocumentId(journal);
                copy.Room = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(ja_room_text_box));
                copy.Level = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(ja_level_text_box));
                LibrarianDataManager.AddCopy(n, copy);

                this.Close();
            }
        }
       
        private void add_inner_to_db_Click(object sender, RoutedEventArgs e)
        {
            if (inner_title_box.Text != null &&
                inner_author_box.Text != null &&
                inner_level_text_box.Text != null &&
                inner_room_text_box.Text != null &&
                inner_type_text_box.Text != null &&
                inner_cover_url_box.Text != null &&
                inner_keywords_text_box.Text != null)
            {
                InnerMaterial innerMaterials = new InnerMaterial(InputFieldsManager.ReturnStringFromTextBox(inner_author_box),InputFieldsManager.ReturnStringFromTextBox(inner_title_box),InputFieldsManager.ReturnStringFromTextBox(inner_type_text_box),InputFieldsManager.ReturnStringFromTextBox(inner_keywords_text_box),Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(inner_room_text_box)), Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(inner_level_text_box)),InputFieldsManager.ReturnStringFromTextBox(inner_cover_url_box));
                DocumentsDataManager.AddDocument(innerMaterials);               
                this.Close();
            }
        }
    }
}
