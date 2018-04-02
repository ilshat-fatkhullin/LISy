using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Managers;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для BookingInfoWindow.xaml
    /// </summary>
    public partial class BookingInfoWindow : Window
    {
        private Patron patron;
        private Book book;
        private WorkWindow workWindow;
        /// <summary>
        /// View info about book
        /// </summary>
        /// <param name="book"></param>
        /// <param name="patron"></param>
        /// <param name="workWindow"></param>
        public BookingInfoWindow(Book book, Patron patron, WorkWindow workWindow)
        {
            InitializeComponent();
            this.book = book;
            this.workWindow = workWindow;
            this.patron = patron;

            TitleLabel.Content = book.Title;
            Authors.Content = book.Authors;

            if (LibrarianDataManager.IsAvailable(book.Id, patron.CardNumber))
            {
                BookButton.IsEnabled = true;
                InStockLabel.Content = "Available.";                
            }
            else
            {
                BookButton.IsEnabled = false;
                InStockLabel.Content = "Not available.";
            }
            BestSellerLabel.Content = book.IsBestseller ? "Bestseller." : "";
            
            if (CountFine()>0)
            {
                FineLabel.Visibility = Visibility.Visible;
                finePriceLabel.Content = CountFine(); 
                finePriceLabel.Visibility = Visibility.Visible;
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
        public int CountFine()
        {
            //нужно подсчитать дату точнее разницу между датой сдачи и сегоднешним днем 
            //если просрочено то умножить на кооэфицент 1000
            return 1000;
        }

        private void button_book_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.CheckOutDocument(book.Id, patron.CardNumber);
            BookButton.IsEnabled = false;
            InStockLabel.Content = "Not available.";
            ReturnDataLabel.Content = book.EvaluateReturnDate(patron.Type);            
        }

        private void GoToQueue_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.AddToQueue(book.Id, patron.CardNumber);
            GoToQueue.IsEnabled = false;
        }
    }
}
