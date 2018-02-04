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

        public BookingInfoWindow()
        {
            InitializeComponent();

        }

        public void Initialize(long userID, long documentID)
        {
            UserID = userID;
            DocumentID = documentID;

            if (DocumentsDataManager.IsAvailable(DocumentID, UserID))
            {
                button_book.IsEnabled = true;
                label_inStock.Content = "Available";
            }
            else
            {
                button_book.IsEnabled = false;
                label_inStock.Content = "Not available";
            }
        }

        private void button_book_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.CheckOutDocument(DocumentID, UserID);
            button_book.IsEnabled = false;
            label_inStock.Content = "Not available";
        }
    }
}
