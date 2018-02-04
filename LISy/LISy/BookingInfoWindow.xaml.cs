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
        public long BookID;
        public long UserID;

        public BookingInfoWindow()
        {
            InitializeComponent();     
           
            
        }

        private void button_book_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.CheckOutDocument(BookID, UserID);
            button_book.IsEnabled = false;
        }
    }
}
