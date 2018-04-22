using LISy.Entities.Users;
using LISy.Managers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для LibAdminModify.xaml
    /// </summary>
    public partial class LibAdminModify : Window
    {
        private Librarian librarian;
        private AdminWindow adminWindow;
        /// <summary>
        /// admin's window for editing librarians
        /// </summary>
        /// <param name="librarian"></param>
        /// <param name="adminWindow"></param>
        public LibAdminModify(Librarian librarian, AdminWindow adminWindow)
        {
            InitializeComponent();
            this.librarian = librarian;
            this.adminWindow = adminWindow;
            lib_name_box.Text = librarian.FirstName;
            SecondNameTextBox.Text = librarian.SecondName;
            AddressTextBox.Text = librarian.Address;
            PhoneTextBox.Text = librarian.Phone;
        }

        private void lib_name_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(lib_name_box);
        }

        private void add_new_lib_to_system_Click(object sender, RoutedEventArgs e)
        {
            librarian.FirstName = lib_name_box.Text;
            librarian.SecondName = SecondNameTextBox.Text;
            librarian.Address = AddressTextBox.Text;
            librarian.Phone = PhoneTextBox.Text;
            int accessLevel = 0;
            if (firstLevel.IsChecked == true)
            {
                accessLevel = 1;
            }
            else if (secondLevel.IsChecked == true)
            {
                accessLevel = 2;
            }
            else if (thirdLevel.IsChecked == true)
            {
                accessLevel = 3;
            }

            /*if (librarian.FirstName != null &&
                librarian.SecondName != null &&
                librarian.Address != null &&
                librarian.Phone != null &&
                (librarian.Authority > 0 && librarian.Authority < 4))
            {*/
            LibrarianDataManager.EditLibrarian(librarian);
            LibrarianDataManager.SetLibrarianAuthority(librarian.CardNumber, accessLevel);
            adminWindow.UpdateLibrariansDataGrid();
            adminWindow.Show();
            this.Close();

        }

        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //InputFieldsManager.CheckLiteralValidity(AddressTextBox);
        }

        private void SecondNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(SecondNameTextBox);
        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(PhoneTextBox);
        }

        private void DeleteLibrarian_Click(object sender, RoutedEventArgs e)
        {
            LibrarianDataManager.DeleteUser(librarian.CardNumber);
        }
    }
}
