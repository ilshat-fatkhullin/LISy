using LISy.Entities.Documents;
using LISy.Entities.Users;
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
    /// Логика взаимодействия для JournalModifyWindow.xaml
    /// </summary>
    public partial class JournalModifyWindow : Window
    {

        private Patron patron;
        private Journal journal;
        private WorkWindow workWindow;
        /// <summary>
        /// journal modify window
        /// </summary>
        /// <param name="journal"></param>
        /// <param name="patron"></param>
        /// <param name="workWindow"></param>
        public JournalModifyWindow(Journal journal, Patron patron, WorkWindow workWindow)
        {
            InitializeComponent();
            this.journal = journal;
            this.patron = patron;
            this.workWindow = workWindow;
            LoadImage(journal);
            TitleLabel.Content = journal.Title;
            Authors.Content = journal.Authors;

            if (LibrarianDataManager.IsAvailable(journal.Id, patron.CardNumber))
            {
                BookButton.IsEnabled = true;
                InStockLabel.Content = "Available.";
            }
            else
            {
                BookButton.IsEnabled = false;
                InStockLabel.Content = "Not available.";
            }

            if (BookButton.IsEnabled == false)
            {
                GoToQueue.IsEnabled = true;
            }
            else
            {
                GoToQueue.IsEnabled = false;
            }
        }
        /// <summary>
        /// load cover image for doc
        /// </summary>
        /// <param name="myBook"></param>
        public void LoadImage(Journal journal)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Design/CA.jpg", UriKind.Relative);
            bi3.EndInit();
            imagesourse.Stretch = Stretch.Fill;
            imagesourse.Source = bi3;
        }
        private void button_book_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.CheckOutDocument(journal.Id, patron.CardNumber);
            BookButton.IsEnabled = false;
            InStockLabel.Content = "Not available.";
            ReturnDataLabel.Content = DateManager.GetDate(journal.EvaluateReturnDate(patron.Type)).ToShortDateString();
        }
        private void GoToQueue_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.AddToQueue(journal.Id, patron.CardNumber);
            GoToQueue.IsEnabled = false;
        }
    }
}
