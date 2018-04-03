using LISy.Entities;
using LISy.Entities.Notifications;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using LISy.Managers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LISy
{
    /// <summary>
    /// Interaction logic for UserModifyWindow.xaml
    /// </summary>
    public partial class UserModifyWindow : Window
	{
		private User user;
		private LibrarianWorkWindow workWindow;
        /// <summary>
        /// user modify window
        /// </summary>
        /// <param name="user"></param>
        /// <param name="workWindow"></param>
		public UserModifyWindow(User user, LibrarianWorkWindow workWindow)
		{
			InitializeComponent();
			this.user = user;
			this.workWindow = workWindow;
			FirstName.Text = user.FirstName;
			SecondName.Text = user.SecondName;
			Phone.Text = user.Phone;
			Address.Text = user.Address;
			
		}

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            user.FirstName = FirstName.Text;
            user.SecondName = SecondName.Text;
            user.Phone = Phone.Text;
            user.Address = Address.Text;

            if (librarianCheckBoxType.IsChecked == true)
            {
                LibrarianDataManager.EditLibrarian(user as Librarian);
            }
            else if (InstructorCheckBoxType.IsChecked == true)
            {
                LibrarianDataManager.EditFaculty(user as Faculty);
            }
            else if (taCheckBoxType.IsChecked == true)
            {
                LibrarianDataManager.EditFaculty(user as Faculty);
            }
            else if (professorCheckBoxType.IsChecked == true)
            {
                LibrarianDataManager.EditFaculty(user as Faculty);
            }
            else if (visitingProfessorCheckBoxType.IsChecked == true)
            {
                LibrarianDataManager.EditGuest(user as Guest);
            }
			workWindow.UpdateUsersDataGrid();
			this.Close();
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
		{
			FirstName.Text = InputFieldsManager.ReturnStringFromTextBox(FirstName);
		}

		private void SecondName_TextChanged(object sender, TextChangedEventArgs e)
		{
			SecondName.Text = InputFieldsManager.ReturnStringFromTextBox(SecondName);
		}

		private void Phone_TextChanged(object sender, TextChangedEventArgs e)
		{
			Phone.Text = InputFieldsManager.ReturnStringFromTextBox(Phone);
		}

		private void Address_TextChanged(object sender, TextChangedEventArgs e)
		{
			Address.Text = InputFieldsManager.ReturnStringFromTextBox(Address);
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			LibrarianDataManager.DeleteUser(user.CardNumber);
			workWindow.UpdateUsersDataGrid();
			this.Close();
		}
        public void UpdateNotificationDataGrid()
        {
            Patron newPatron;
            newPatron = LibrarianDataManager.GetPatronById(user.CardNumber);
            List<Notification> result = new List<Notification>();
            result.Clear();
            foreach(Notification notification in PatronDataManager.GetNotifications(newPatron.CardNumber))
            {
                result.Add(notification);
            }
            UsersNotificationDataGrid.ItemsSource = result;
        }
        private void UsersNotificationDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateNotificationDataGrid();
        }
    }
}