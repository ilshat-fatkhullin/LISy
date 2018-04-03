using LISy.Entities;
using LISy.Managers;
using System.Windows;

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

		/// <summary>
		/// Initializes MakeRenew window.
		/// </summary>
		/// <param name="patronID">Id of watching patron.</param>
		/// <param name="documentID">Id of looking document.</param>
		/// <param name="copyID">Id of looking copy.</param>
		/// <param name="bookingHistoryWindow">Previous window.</param>
        public MakeRenew(long patronID,long documentID, Copy copy, BookingHistory bookingHistoryWindow)
        {
            InitializeComponent();
            this.copy = copy;
            this.documentID = documentID;
            this.patronID = patronID;
            this.bookingHistoryWindow = bookingHistoryWindow;
        }

		/// <summary>
		/// Checks renew status.
		/// </summary>
        public void CheckRenewStatus() {
            if (checkRenewStatusBox.IsChecked == true && LibrarianDataManager.GetTakableById(copy.Id).IsOutstanding == false && LibrarianDataManager.GetPatronById(patronID).Type == "Student")
            {
                PatronDataManager.RenewDocument(documentID, patronID);
                if (copy.IsRenewed == true)
                {
                    checkRenewStatusBox.IsEnabled = false;
                }
                else
                {
                    checkRenewStatusBox.IsEnabled = true;
                }
            }
            else if (checkRenewStatusBox.IsChecked == true && LibrarianDataManager.GetTakableById(copy.Id).IsOutstanding == false && LibrarianDataManager.GetPatronById(patronID).Type == "Professor")
            {
                    PatronDataManager.RenewDocument(documentID, patronID);
                if (copy.IsRenewed == true)
                {
                    checkRenewStatusBox.IsEnabled = false;
                }
                else
                {
                    checkRenewStatusBox.IsEnabled = true;
                }

            }
            else if (checkRenewStatusBox.IsChecked == true && LibrarianDataManager.GetTakableById(copy.Id).IsOutstanding == false && LibrarianDataManager.GetPatronById(patronID).Type == "TA")
            {
                PatronDataManager.RenewDocument(documentID, patronID);
                if (copy.IsRenewed == true)
                {
                    checkRenewStatusBox.IsEnabled = false;
                }
                else
                {
                    checkRenewStatusBox.IsEnabled = true;
                }

            }
            else if (checkRenewStatusBox.IsChecked == true && LibrarianDataManager.GetTakableById(copy.Id).IsOutstanding == false && LibrarianDataManager.GetPatronById(patronID).Type == "Instructor")
            {
                PatronDataManager.RenewDocument(documentID, patronID);
                if (copy.IsRenewed == true)
                {
                    checkRenewStatusBox.IsEnabled = false;
                }
                else
                {
                    checkRenewStatusBox.IsEnabled = true;
                }

            }
            else if (checkRenewStatusBox.IsChecked == true && LibrarianDataManager.GetTakableById(copy.Id).IsOutstanding == false && LibrarianDataManager.GetPatronById(patronID).Type == "Guest")
            {
                PatronDataManager.RenewDocument(documentID, patronID);
            }
            else
            {
                MessageBox.Show("This document in outstanding request");
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
