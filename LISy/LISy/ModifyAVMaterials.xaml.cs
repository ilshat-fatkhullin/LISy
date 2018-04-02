using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Managers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для ModifyAVMaterials.xaml
    /// </summary>
    public partial class ModifyAVMaterials : Window
    {
        private AVMaterial av;
        private LibrarianWorkWindow workWindow;
        public ModifyAVMaterials(AVMaterial av, LibrarianWorkWindow workWindow)
        {
            InitializeComponent();
            this.av = av;
            this.workWindow = workWindow;
            av_title_text_box.Text = av.Title;
            authors_av_text_box.Text = av.Authors;
            av_coverUrl_text_box.Text = av.CoverURL;
            av_key_words_text_box.Text = av.KeyWords;
            av_price_text_box.Text = Convert.ToString(av.Price);
           
        }

        private void av_title_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(av_title_text_box);
        }

        private void authors_av_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(authors_av_text_box);
        }

        private void av_level_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_level_text_box);
        }

        private void av_key_words_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(av_key_words_text_box);
        }

        private void av_copy_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_copy_text_box);
        }

        private void av_room_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_room_text_box);
        }

        private void Av_price_text_box(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(av_price_text_box);
        }

        private void save_to_db(object sender, RoutedEventArgs e)
        {
            av.Title = av_title_text_box.Text;
            av.Authors = authors_av_text_box.Text;
            av.KeyWords = av_key_words_text_box.Text;
            av.Price = Convert.ToInt32(av_price_text_box.Text);
            av.CoverURL = av_coverUrl_text_box.Text;

            LibrarianDataManager.EditAVMaterial(av);

            Copy copy = new Copy();
            copy.DocumentId = av.Id;

            if (av_room_text_box.Text != "" &&
                av_level_text_box.Text != "" &&
                av_copy_text_box.Text != "")
            {
                copy.Room = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_room_text_box));
                copy.Level = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_level_text_box));
                LibrarianDataManager.AddCopies(Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(av_copy_text_box)), copy);
            }
            workWindow.UptadeDataGridAV_material();
            this.Close();

        }

        private void av_coverUrl_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(av_coverUrl_text_box);
        }

        private void delete_db_Click(object sender, RoutedEventArgs e)
        {
            LibrarianDataManager.DeleteDocument(av.Id);
            workWindow.UptadeDataGridAV_material();
            this.Close();
        }
    }
}
