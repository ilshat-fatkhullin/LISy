using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Managers;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            LoadImage(book);
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
        public void LoadImage(Book myBook)
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