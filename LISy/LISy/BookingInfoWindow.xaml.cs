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
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Managers;
using LISy.Managers.DataManagers;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для BookingInfoWindow.xaml
    /// </summary>
    public partial class BookingInfoWindow : Window
    {
        private IPatron patron;
        private Book book;
        private WorkWindow workWindow;

        public BookingInfoWindow(Book book, IPatron patron, WorkWindow workWindow)
        {
            InitializeComponent();
            this.book = book;
            this.workWindow = workWindow;
            this.patron = patron;

            TitleLabel.Content = book.Title;
            Authors.Content = book.Authors;

            if (DocumentsDataManager.IsAvailable(book.Id, patron.CardNumber))
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
        }

        private void button_book_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.CheckOutDocument(book.Id, patron.CardNumber);
            BookButton.IsEnabled = false;
            InStockLabel.Content = "Not available.";
            ReturnDataLabel.Content = book.EvaluateReturnDate(patron.Type);            
        }
    }
}
