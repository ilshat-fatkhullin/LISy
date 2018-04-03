using LISy.Entities;
using LISy.Entities.Users;
using LISy.Managers;
using System.Collections.Generic;
using System.Windows;

namespace LISy
{
	/// <summary>
	/// Логика взаимодействия для BookingHistory.xaml
	/// </summary>
	public partial class BookingHistory : Window
	{
		private Patron patron;

		/// <summary>
		/// Initializes window for looking at booking history of a patron.
		/// </summary>
		/// <param name="patron">Inspecting patron.</param>
		public BookingHistory(Patron patron)
		{
			InitializeComponent();
			GetAllAboutUser(patron);
			this.patron = patron;
		}

		/// <summary>
		/// Gets all data of user.
		/// </summary>
		/// <param name="patron">Inspecting patron.</param>
		public void GetAllAboutUser(Patron patron)
		{
			name_patron.Content = patron.FirstName;
			id_patron.Content = patron.CardNumber;

		}
        public void UpdateDataGrid()
        {
            List<Copy> result = new List<Copy>();
            result.Clear();
            foreach (Copy doc in LibrarianDataManager.GetCheckedByUserCopiesList(patron.CardNumber))
            {
                result.Add(doc);
            }
            check_out_doc.ItemsSource = result;   
        }
		private void DataGridChekOutDoc(object sender, RoutedEventArgs e)
		{
            UpdateDataGrid();
		}
	
        private void check_out_doc_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Copy copy = check_out_doc.SelectedItem as Copy;
            if (copy == null)
                return;

            MakeRenew window = new MakeRenew(patron.CardNumber,copy.DocumentId, copy, this);
            window.Owner = this;
            window.Show();
        }
    }
}
