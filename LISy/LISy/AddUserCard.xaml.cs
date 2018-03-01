using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using LISy.Managers;
using LISy.Managers.DataManagers;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddUserCard.xaml
    /// </summary>
    public partial class AddUserCard : Window
    {
        public AddUserCard()
        {
            InitializeComponent();
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

                IPatron patron = null;
                if (faculty_check.IsChecked == true)
                {
                    patron = new Faculty(firstName, secondName, phone, address);
                }
                else
                {
                    patron = new Student(firstName, secondName, phone, address);
                }

                //if all checks good so open window                
                if (LibrarianDataManager.AddPatron(patron, login, password))
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
