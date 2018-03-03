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
        public long DocumentID;
        public long UserID;
        private Book book;
        private WorkWindow workWindow;

        public BookingInfoWindow(Book book, WorkWindow workWindow, long Document_ID, long User_Id)
        {
            InitializeComponent();
            this.book = book;
            this.workWindow = workWindow;
            User_Id = UserID;
            Document_ID = DocumentID;
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("Design/star_20x20.png", UriKind.Relative);
            bi1.EndInit();

            if (DocumentsDataManager.IsAvailable(DocumentID, UserID) && bestSellerChecking()/*check if it best_seller*/)
            {
                button_book.IsEnabled = true;
                label_inStock.Content = "Available";
                label_best_seller.Content = "BestSeller";
                image_best_seller.Source = bi1;
                image_best_seller.Stretch = Stretch.Fill;
            }
            else
            {
                button_book.IsEnabled = false;
                label_inStock.Content = "Not available";
            }

        }

        public bool bestSellerChecking()
        {
            return true;
        }


        private void button_book_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.CheckOutDocument(DocumentID, UserID);
            button_book.IsEnabled = false;
            label_inStock.Content = "Not available";
        }
    }
}
