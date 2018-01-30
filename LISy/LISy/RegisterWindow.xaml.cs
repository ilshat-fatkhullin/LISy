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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

        }
        private static String ReturnFromTextBox(TextBox textBox)
        {
            String input = "";
            if (textBox.Text != null)
            {
                input = textBox.Text;
            }

            return input;
        }
        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            WorkWindow work = new WorkWindow();
             
            String id = "";
            if (textBox_name.Text != null && textBox_phone_number.Text != null && textBox_Address_town.Text != null && textBox_Address_street.Text != null && textBox_Address_building.Text != null && textBox_Address_flat.Text != null && passwordBox_registration.Password != null) {
                ReturnFromTextBox(textBox_name);
                ReturnFromTextBox(textBox_phone_number);
                ReturnFromTextBox(textBox_Address_town);
                ReturnFromTextBox(textBox_Address_street);
                ReturnFromTextBox(textBox_Address_building);
                ReturnFromTextBox(textBox_Address_flat);
                ReturnPasswordFromTextBox(passwordBox_registration);
                id=id+ReturnFromTextBox(textBox_name).Substring(0,1) + ReturnFromTextBox(textBox_Address_town).Substring(0,1) + ReturnFromTextBox(textBox_Address_street).Substring(0,1) + ReturnFromTextBox(textBox_Address_building) + ReturnFromTextBox(textBox_Address_flat);
                //метод проверить что такого пользователя с такими данными есть ли в базе если есть то выводим что есть если нет то регаем его 
                if (checkBox_faculty.IsChecked == true)
                {
                    //таким образом все пользователи Факульти будут отличаться наличием последнего симовала которой будет буква, у обычных там цифра а у Факульти буква
                    id = id + "F";                
                }
                //if all checks good so open window
                if (true && AlertPassword(passwordBox_registration) == true) {
                    //переходим к окну работы мы зарегались
                    // нужно будет перенести id b name пользователя отсюда в окно работы в label_name and label_id

                    GoToWork(work);
                }
            }        
        }
        
        //close regestration window open workWindow
        private void GoToWork(WorkWindow work)
        {
            work.Show();
            this.Close();
        }
        //return password from passwordBox
        private static String ReturnPasswordFromTextBox(PasswordBox passwordBox)
        {
            String password = "";
            if (passwordBox.Password != null)
            {
                password = passwordBox.Password;
            }

            return password;
        }
        //return name from textBox_name
        private void textBox_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlertText(textBox_name);
        }
        //give for user message about not correct input to  with strings
        private void AlertText(TextBox textBox) {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only English characters");
                textBox.Clear();
            }
        }
        //give for user message about not correct input to  with numbers
        private void AlertNumbers(TextBox textBox)
        {
            //тут нужен эксепшен на буквы а то программа вылетает
            byte result;
            char[] element = textBox.Text.ToCharArray();
            foreach (char n in element) {
                result = Convert.ToByte(n);
                if (result <= 47 && result >= 58)
                {
                    MessageBox.Show("This textbox accepts only numbers");
                    textBox.Clear();
                    break;
                }
              
            }
            
               
            
        }
        //give for user message about not correct input to  with password
        private bool AlertPassword(PasswordBox passwordBox)
        {
            bool flag = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(passwordBox.Password, "[a-zA-Z]+$"))
            {

                flag = true;
            }
            else {
                MessageBox.Show("Such char not available");
                passwordBox.Clear();
            }
            return flag;
        }
        private void textBox_Address_town_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlertText(textBox_Address_town);
        }

        private void textBox_Address_street_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlertText(textBox_Address_street);
        }

        private void textBox_Address_building_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlertNumbers(textBox_Address_building);
        }

        private void textBox_Address_flat_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlertNumbers(textBox_Address_flat);
        }

        private void textBox_phone_number_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlertNumbers(textBox_phone_number);
        }
    }
}
