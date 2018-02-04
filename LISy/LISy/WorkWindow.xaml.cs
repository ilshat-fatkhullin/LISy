using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private long UserID;
        /// <summary>
        /// Give info to profile paatron will can see info about him and in future will can to make reference to labrarian to change info
        /// </summary>
        public string[] Profile = new string[6];

        public WorkWindow()
        {
            InitializeComponent();

            using (StreamReader reader = new StreamReader("id.txt"))
            {
                UserID = Convert.ToInt64(reader.ReadLine());
            }             
        }

        ///<summary>
        ///this button will be an action to begin search document in DB
        ///</summary>
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {


        }
        ///<summary>
        ///every checked checkBox will be like a filter for seaching 
        ///</summary>
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
        ///when we find document we click button to read about this document and Book it
        ///</summary>
       
       
        private void button_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profilelWindow = new Profile();
            profilelWindow.Show();
        }

        private void button_Booking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_open_book_1_Click(object sender, RoutedEventArgs e)
        {
            
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("Design/Strang.jpg", UriKind.Relative);
            bi1.EndInit();

            BookingInfoWindow bookingInfo = new BookingInfoWindow
            {
                Owner = this,                
                image_preview =
                {
                    Stretch = Stretch.Fill,
                    Source = bi1
                },
                label_name = {Content = label_book_1.Content},                
                label_info = {Content = ">Some useful information about this Book, which make you to Book it."}
            };
            bookingInfo.Initialize(UserID, 1);

            bookingInfo.Show();
        }

        private void button_open_book_2_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri("Design/introduction-to-algorithms.jpg", UriKind.Relative);
            bi2.EndInit();

            BookingInfoWindow bookingInfo = new BookingInfoWindow
            {
                UserID = UserID,
                DocumentID = 2,
                Owner = this,
                image_preview =
                {
                    Stretch = Stretch.Fill,
                    Source = bi2
                },
                label_name = {Content = label_book_2.Content},                
                label_info = {Content = ">Some useful information about this Book, which make you to Book it."}
            };
            bookingInfo.Initialize(UserID, 2);
            bookingInfo.Show();
        }

        private void button_open_book_3_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Design/Rye_catcher.jpg", UriKind.Relative);
            bi3.EndInit();

            BookingInfoWindow bookingInfo = new BookingInfoWindow
            {
                Owner = this,
                image_preview =
                {
                    Stretch = Stretch.Fill,
                    Source = bi3
                },
                label_name = { Content = label_book_3.Content },                
                label_info = { Content = ">Some useful information about this Book, which make you to Book it." }
            };
            bookingInfo.Initialize(UserID, 3);

            bookingInfo.Show();
        }

        private void button_open_book_4_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri("Design/wheels.jpg", UriKind.Relative);
            bi4.EndInit();

            BookingInfoWindow bookingInfo = new BookingInfoWindow
            {                
                Owner = this,
                image_preview =
                {
                    Stretch = Stretch.Fill,
                    Source = bi4
                },
                label_name = { Content = label_book_4.Content },                
                label_info = { Content = ">Some useful information about this Book, which make you to Book it." }
            };
            bookingInfo.Initialize(UserID, 4);
            bookingInfo.Show();
        }

        private void button_open_book_5_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi5 = new BitmapImage();
            bi5.BeginInit();
            bi5.UriSource = new Uri("Design/CA.jpg", UriKind.Relative);
            bi5.EndInit();

            BookingInfoWindow bookingInfo = new BookingInfoWindow
            {
                Owner = this,
                image_preview =
                {
                    Stretch = Stretch.Fill,
                    Source = bi5
                },
                label_name = { Content = label_book_5.Content },                
                label_info = { Content = ">Some useful information about this Book, which make you to Book it." }
            };
            bookingInfo.Initialize(UserID, 5);
            bookingInfo.Show();
        }

        private void checkBox_JA_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_Article_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}