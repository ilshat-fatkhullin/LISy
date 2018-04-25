using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using LISy.Managers;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для AddUserCard.xaml
    /// </summary>
    public partial class AddUserCard : Window
    {
        private String owner;
        /// <summary>
        /// Initializes window for adding user.
        /// </summary>
        public AddUserCard(String owner)
        {
            InitializeComponent();
            this.owner = owner;

            if (owner == "Admin")
            {
                studentCheckBoxType.IsEnabled = false;
                taCheckBoxType.IsEnabled = false;
                InstructorCheckBoxType.IsEnabled = false;
                professorCheckBoxType.IsEnabled = false;
                visitingProfessorCheckBoxType.IsEnabled = false;
            }
        }

        private void name_of_new_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(name_of_new_user);
        }

        private void lastname_of_new_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(lastname_of_new_user);
        }

        private void town_of_new_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(town_of_new_user);
        }

        private void street_of_new_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(street_of_new_user);
        }

        private void house_of_new_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(house_of_new_user);
        }

        private void flat_of_new_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(flat_of_new_user);
        }

        private void phone_of_new_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(phone_of_new_user);
        }

        private void save_user_Click(object sender, RoutedEventArgs e)
        {
            if (name_of_new_user.Text != null &&
               lastname_of_new_user.Text != null &&
               phone_of_new_user.Text != null &&
               town_of_new_user.Text != null &&
               street_of_new_user.Text != null &&
               house_of_new_user.Text != null &&
               flat_of_new_user.Text != null &&
               InputFieldsManager.CheckPasswordValidity(user_new_password))
            {

                string firstName = InputFieldsManager.ReturnStringFromTextBox(name_of_new_user),
                       secondName = InputFieldsManager.ReturnStringFromTextBox(lastname_of_new_user),
                       phone = InputFieldsManager.ReturnStringFromTextBox(phone_of_new_user),
                       address = InputFieldsManager.ReturnStringFromTextBox(town_of_new_user) + ' ' +
                                 InputFieldsManager.ReturnStringFromTextBox(street_of_new_user) + ' ' +
                                 InputFieldsManager.ReturnStringFromTextBox(house_of_new_user) + ' ' +
                                 InputFieldsManager.ReturnStringFromTextBox(flat_of_new_user) + ' ';
                string password = InputFieldsManager.ReturnPasswordFromTextBox(user_new_password);
                string login = firstName.Substring(0, 1) + '.' + secondName;

                bool IsNewUserAdded = false;
                if (InstructorCheckBoxType.IsChecked == true)
                {
                    IsNewUserAdded = LibrarianDataManager.AddFaculty(
                        new Faculty(firstName, secondName, phone, address, "Instructor"), login, password);
                }
                else if (librarianCheckBoxType.IsChecked == true)
                {
                    if (level_1_librarian.IsChecked == true && level_2_librarian.IsChecked == false && level_3_librarian.IsChecked == false)
                    {
                        IsNewUserAdded = LibrarianDataManager.AddLibrarian(
                           new Librarian(firstName, secondName, phone, address, 1), login, password);

                    }
                    else if (level_1_librarian.IsChecked == false && level_2_librarian.IsChecked == true && level_3_librarian.IsChecked == false)
                    {
                        IsNewUserAdded = LibrarianDataManager.AddLibrarian(
                           new Librarian(firstName, secondName, phone, address, 2), login, password);

                    }
                    else if (level_1_librarian.IsChecked == false && level_2_librarian.IsChecked == false && level_3_librarian.IsChecked == true)
                    {
                        IsNewUserAdded = LibrarianDataManager.AddLibrarian(
                            new Librarian(firstName, secondName, phone, address, 3), login, password);
                    }

                }
                else if (studentCheckBoxType.IsChecked == true)
                {
                    IsNewUserAdded = LibrarianDataManager.AddStudent(
                        new Student(firstName, secondName, phone, address), login, password);
                }
                else if (taCheckBoxType.IsChecked == true)
                {
                    IsNewUserAdded = LibrarianDataManager.AddFaculty(
                        new Faculty(firstName, secondName, phone, address, "TA"), login, password);
                }
                else if (professorCheckBoxType.IsChecked == true)
                {
                    IsNewUserAdded = LibrarianDataManager.AddFaculty(
                        new Faculty(firstName, secondName, phone, address, "Professor"), login, password);
                }
                else if (visitingProfessorCheckBoxType.IsChecked == true)
                {
                    IsNewUserAdded = LibrarianDataManager.AddGuest(
                        new Guest(firstName, secondName, phone, address), login, password);
                }

                //if all checks good so open window                
                if (IsNewUserAdded)
                {
                    using (StreamWriter writer = new StreamWriter("id.txt"))
                    {
                        writer.Write(CredentialsManager.Authorize(login, password));
                    }
                }
                else
                {
                    MessageBox.Show("Error! Can not create an account.");
                }
            }
            else
            {
                MessageBox.Show("Error! Invalid fields.");
            }
            this.Close();
        }

    }
}