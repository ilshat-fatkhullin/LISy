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
    /// Логика взаимодействия для AddJournalArticlesToJournal.xaml
    /// </summary>
    public partial class AddJournalArticlesToJournal : Window
    {
        private long journalID;
        private AddDocument addDocument;
        public AddJournalArticlesToJournal(long journalID, AddDocument addDocument)
        {
            InitializeComponent();
            this.journalID = journalID;
            this.addDocument = addDocument;
        }

        private void save_all_Click(object sender, RoutedEventArgs e)
        {
            Article journalArticle = new Article();
            if (article_keywords_text_box.Text != null &&
                article_coverURL_text_box.Text != null &&
                article_authors_text_box.Text != null &&
                article_title_text_box.Text != null)
            {
                journalArticle.JournalId = journalID;
                journalArticle.Authors = InputFieldsManager.ReturnStringFromTextBox(article_authors_text_box);
                journalArticle.Title = InputFieldsManager.ReturnStringFromTextBox(article_title_text_box);
                journalArticle.CoverURL = InputFieldsManager.ReturnStringFromTextBox(article_coverURL_text_box);
                journalArticle.KeyWords = InputFieldsManager.ReturnStringFromTextBox(article_keywords_text_box);
                LibrarianDataManager.AddArticle(journalArticle);
            }
            article_title_text_box.Clear();
            article_keywords_text_box.Clear();
            article_coverURL_text_box.Clear();
            article_authors_text_box.Clear();
        }

        private void article_authors_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(article_authors_text_box);
        }

        private void article_title_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(article_title_text_box);
        }

        private void article_keywords_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(article_keywords_text_box);
        }

        private void article_coverURL_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(article_title_text_box);
        }

        private void save_and_exit_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
            addDocument.Close();
        }
    }
}
