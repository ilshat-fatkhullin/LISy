using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private static RegisterWindow registerWindow = new RegisterWindow();
        public WorkWindow()
        {
            InitializeComponent();
            ///<summary>
            ///here we get id and users name for make Profile page
            ///<summary>
            //string id = registerWindow.Return_id().ToString();
            string name = registerWindow.textBox_name.Text.ToString();       
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