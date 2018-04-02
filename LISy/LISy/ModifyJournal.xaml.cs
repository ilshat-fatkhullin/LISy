using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Managers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для ModifyJournal.xaml
    /// </summary>
    public partial class ModifyJournal : Window
    {
        private LibrarianWorkWindow window;
        private Journal journal;
        
        /// <summary>
        /// window to modifay Journal information
        /// </summary>
        /// <param name="journal"></param>
        /// <param name="window"></param>
        public ModifyJournal(Journal journal, LibrarianWorkWindow window)
        {
            InitializeComponent();
            this.window = window;
            this.journal = journal;
            titleTextBox.Text = journal.Title;
            publisherTextBox.Text = journal.Publisher;
            issueTextBox.Text = Convert.ToString(journal.Issue);
            editorsTextBox.Text = journal.Authors;
            keyWordsTextBox.Text = journal.KeyWords;
            coverUrlTextBox.Text = journal.CoverURL;
            keyWordsTextBox.Text = journal.KeyWords;
            priceTextBox.Text = Convert.ToString(journal.Price);
            publicationDateBox.Text = journal.PublicationDate;
        }

        private void titleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(titleTextBox);
        }

        private void publisherTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(publisherTextBox);
        }

        private void issueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(issueTextBox);
        }

        private void editorsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(editorsTextBox);
        }

        private void keyWordsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(keyWordsTextBox);
        }

        private void coverUrlTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(coverUrlTextBox);
        }

        private void priceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(priceTextBox);
        }

        private void publicationDateBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(publicationDateBox);
        }

        private void copiesOfJournalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(copiesOfJournalTextBox);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            journal.Title = titleTextBox.Text;
            journal.Publisher = publisherTextBox.Text;
            journal.Issue = Convert.ToInt32(issueTextBox.Text);
            journal.Authors = editorsTextBox.Text;
            journal.KeyWords = keyWordsTextBox.Text;
            journal.CoverURL = coverUrlTextBox.Text;
            journal.KeyWords = keyWordsTextBox.Text;
            journal.Price = Convert.ToInt32(priceTextBox.Text);
            journal.PublicationDate = publicationDateBox.Text;

            LibrarianDataManager.EditJournal(journal);
            Copy copy = new Copy();
            if (roomTextBox.Text != "" &&
                levelTextBox.Text != "" &&
                copiesOfJournalTextBox.Text != "")
            {
                copy.Room = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(roomTextBox));
                copy.Level = Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(levelTextBox));
                LibrarianDataManager.AddCopies(Convert.ToInt32(InputFieldsManager.ReturnStringFromTextBox(copiesOfJournalTextBox)), copy);
            }
            window.UpdateDataGridBook();
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            LibrarianDataManager.DeleteDocument(journal.Id);
            window.UpdateDataGridJournal();
            this.Close();
        }

        private void roomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(roomTextBox);
        }

        private void levelTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(levelTextBox);
        }
    }
}
