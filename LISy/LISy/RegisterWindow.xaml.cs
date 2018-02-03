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
using LISy.Managers;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using System.IO;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_name.Text != null &&
                textBox_phone_number.Text != null &&
                textBox_Address_town.Text != null &&
                textBox_Address_street.Text != null &&
                textBox_Address_building.Text != null &&
                textBox_Address_flat.Text != null &&
                InputFieldsManager.CheckPasswordValidity(passwordBox_registration))
            {

                string firstName = InputFieldsManager.ReturnStringFromTextBox(textBox_name),
                //TODO: Айдар, сделай поле для secondName и замени тут на него
                       secondName = InputFieldsManager.ReturnStringFromTextBox(textBox_name),
                       phone = InputFieldsManager.ReturnStringFromTextBox(textBox_phone_number),
                       address = InputFieldsManager.ReturnStringFromTextBox(textBox_Address_town) + ' ' +
                                 InputFieldsManager.ReturnStringFromTextBox(textBox_Address_street) + ' ' +
                                 InputFieldsManager.ReturnStringFromTextBox(textBox_Address_building) + ' ' +
                                 InputFieldsManager.ReturnStringFromTextBox(textBox_Address_flat) + ' ';
                string password = InputFieldsManager.ReturnPasswordFromTextBox(passwordBox_registration);
                string login = firstName.Substring(0, 1) + '.' + secondName;

                IPatron patron = null;
                if (checkBox_faculty.IsChecked == true)
                {
                    patron = new Faculty(firstName, secondName, 1, phone, address);
                }
                else
                {
                    patron = new Student(firstName, secondName, 1, phone, address);
                }

                ILibrarianDataManager librarianDataManager = new DataManager();

                //if all checks good so open window                
                if (librarianDataManager.AddPatron(patron, login, password))
                {
                    using (StreamWriter writer = new StreamWriter("login.txt"))
                    {
                        writer.Write(login);
                    }

                    WorkWindow workWindow = new WorkWindow();
                    GoToWork(workWindow);
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
        }
                              
        private void GoToWork(WorkWindow work)
        {            
            work.Show();
            this.Close();
        }        

        //return name from textBox_name
        private void textBox_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(textBox_name);
        }                                 

        private void textBox_Address_town_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(textBox_Address_town);
        }

        private void textBox_Address_street_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckLiteralValidity(textBox_Address_street);
        }

        private void textBox_Address_building_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(textBox_Address_building);
        }

        private void textBox_Address_flat_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(textBox_Address_flat);
        }

        private void textBox_phone_number_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldsManager.CheckNumericValidity(textBox_phone_number);
        }
    }
}
