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
    /// Логика взаимодействия для ModifyInnerMaterial.xaml
    /// </summary>
    public partial class ModifyInnerMaterial : Window
    {
        private InnerMaterial inner;
        private LibrarianWorkWindow window;
        public ModifyInnerMaterial(InnerMaterial inner, LibrarianWorkWindow window)
        {
            InitializeComponent();
            this.inner = inner;
            this.window = window;
            titleTextBox.Text = inner.Title;
            authorTextBox.Text = inner.Authors;
            keyWordsTextBox.Text = inner.KeyWords;
            roomTextBox.Text = Convert.ToString(inner.Room);
            levelTextBox.Text = Convert.ToString(inner.Level);
            typeTextBox.Text = inner.Type;
            coverUrlTextBox.Text = inner.CoverURL;
        }
        private void titleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(titleTextBox);
        }
        private void authorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(authorTextBox);
        }

        private void keyWordsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(keyWordsTextBox);
        }

        private void roomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(roomTextBox);
        }

        private void levelTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(levelTextBox);
        }

        private void typeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(typeTextBox);
        }

        private void coverUrlTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(coverUrlTextBox);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            inner.Title = titleTextBox.Text;
            inner.Authors = authorTextBox.Text;
            inner.KeyWords = keyWordsTextBox.Text;
            inner.Room = Convert.ToInt32(roomTextBox.Text);
            inner.Level = Convert.ToInt32(levelTextBox.Text);
            inner.Type = typeTextBox.Text;
            inner.CoverURL = coverUrlTextBox.Text;

            LibrarianDataManager.EditInnerMaterial(inner);
            window.UpdateDataGridInnerMaterials();
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            LibrarianDataManager.DeleteDocument(inner.Id);
            window.UpdateDataGridInnerMaterials();
            this.Close();
        }
    }
}
