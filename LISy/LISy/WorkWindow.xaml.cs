using System.IO;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private string login;

        public WorkWindow()
        {
            InitializeComponent();

            using (StreamReader reader = new StreamReader("login.txt"))
            {
                login = reader.ReadLine();
            }
        }

        ///<summary>
        ///this button will be an action to begin search document in DB
        ///<summary>
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {


        }
        ///<summary>
        ///every checked checkBox will be like a filter for seaching 
        ///<summary>
        private void checkBox_AV_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_JA_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_books_Checked(object sender, RoutedEventArgs e)
        {

        }

        ///<summary>
        ///when we find document we click button to read about this document and book it
        ///<summary>
        private void button_open_Click(object sender, RoutedEventArgs e)
        {
            BookingInfoWindow bookingInfo = new BookingInfoWindow();
            bookingInfo.Owner = this;
            bookingInfo.Show();
            
        }

        private void button_Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Booking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Info_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}