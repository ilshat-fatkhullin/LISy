using LISy.Entities;
using LISy.Managers;
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
        private Copy copy;
        private long documentID;
        private long patronID;
        private BookingHistory bookingHistoryWindow;
        public MakeRenew(long patronID,long documentID, Copy copy,BookingHistory bookingHistoryWindow)
        {
            InitializeComponent();
            this.copy = copy;
            this.documentID = documentID;
            this.patronID = patronID;
            this.bookingHistoryWindow = bookingHistoryWindow;
            fineShowLabel.Content = copy.CountFine();
        }

		/// <summary>
		/// Checks renew status.
		/// </summary>
        public void CheckRenewStatus() {
            if (checkRenewStatusBox.IsChecked == true)
            {
                PatronDataManager.RenewDocument(documentID, patronID);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CheckRenewStatus();
            bookingHistoryWindow.UpdateDataGrid();
            this.Close();
        }
    }
}
