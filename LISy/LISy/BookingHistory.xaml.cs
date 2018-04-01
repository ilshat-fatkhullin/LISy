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

		private void DataGridChekOutDoc(object sender, RoutedEventArgs e)
		{
			List<Copy> result = new List<Copy>();
			result.Clear();
			foreach (Copy doc in LibrarianDataManager.GetCheckedByUserCopiesList(patron.CardNumber))
			{
				result.Add(doc);
			}
			check_out_doc.ItemsSource = result;
		}
	}
}
