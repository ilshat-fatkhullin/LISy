using LISy.Entities;
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
    /// Логика взаимодействия для MakeRenew.xaml
    /// </summary>
    public partial class MakeRenew : Window
    {
        private long copyID;
        private long documentID;
        private BookingHistory bookingHistoryWindow;
        public MakeRenew(long documentID, long copyID,BookingHistory bookingHistoryWindow)
        {
            InitializeComponent();
            this.copyID = copyID;
            this.documentID = documentID;
            this.bookingHistoryWindow = bookingHistoryWindow;
        }
        public void CheckRenewStatus() {
            if (checkRenewStatusBox.IsChecked == true && /*не оутсандинг реквест*/ true)
            {
                //make a renew document
            }
            else
            {
                //if with doc patron don't do anything
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CheckRenewStatus();
        }
    }
}
