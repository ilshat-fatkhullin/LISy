using LISy.Entities.Users;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ///<summary>
        ///when users input all data to textBoxes clicked on this button user go to workWindow but before system will checked all data in textBoxes and checked if this user exist
        ///<summary>
        private void button_sign_in_Click(object sender, RoutedEventArgs e)
        {
            // here you will need to check that a username and password exist in dB it should be done in a separate function which will check it
            //a function that checks if there is a user with such data entered in the fields
            // здесь нужно будет проверить что такой логи и пароль существуют в бд это нужно сделать в отдельной фукции которая будет проверять это  
            //функция которая проверяет если есть такой пользователь с такими данными введенными в поля
            if (AlertPassword(passwordBox_enter) == true)
            {
                //these functions return a string with the maintained data in their textbooks
                //данные функции возвращают строку с веденными данными в их текстБоксы
                ReturnIDFromTextBox(textBox_login);
                ReturnPasswordFromTextBox(passwordBox_enter);

                //if all is OK, so we go to the Work window
                WorkWindow work = new WorkWindow();
                GoToWork(work);
            }
            else {
                MessageBox.Show("Such user doesn't exist");
            }

        }
        //переходим к рабочему окну
        ///<summary>
        ///method that goes to another window
        ///<summary>
        private void GoToWork(WorkWindow work)
        {
            work.Show();
            this.Close();
        }

        private void button_sign_up_Click(object sender, RoutedEventArgs e)
        {
            //нужноо проверить что бы окно входа было закрытым
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            fileExitMainWindow_Click(registerWindow);
        }
        //закрываем предыдущие окно запуска 
        void fileExitMainWindow_Click(RegisterWindow window)
        {
            // Close this(MainWindow) window
            this.Close();
        }
        //предупреждает о неправильных изменениях в TextBox 
        private void textBox_login_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlertText(textBox_login);
        }
        //cauntion user about that his input not valid string
        private void AlertText(TextBox textBox)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only English characters");
                textBox.Clear();
            }
        }
        //return right string from textbox_id 
        private static String ReturnIDFromTextBox(TextBox textBox)
        {
            String id = "";
            if (textBox.Text != null)
            {
                id = textBox.Text;
            }

            return id;
        }
        //cauntion user about not valid password as its corectness not its attendence in DataBase(другая функция будет это проверять)
        private bool AlertPassword(PasswordBox passwordBox)
        {
            bool flag = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(passwordBox.Password, "[a-zA-Z]+$"))
            {

                flag = true;
            }
            else
            {
                MessageBox.Show("Such char not available");
                passwordBox.Clear();
            }
            return flag;
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
    }
}
