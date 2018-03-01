using LISy.Managers;
using LISy.Managers.DataManagers;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DocumentsDataManager.GetAllCopiesList();
            InitializeComponent();
        }
        ///<summary>
        ///when users input all data to textBoxes clicked on this button user go to workWindow but before system will checked all data in textBoxes and checked if this user exist
        ///</summary>
        private void button_sign_in_Click(object sender, RoutedEventArgs e)
        {
            // here you will need to check that a username and password exist in dB it should be done in a separate function which will check it
            //a function that checks if there is a user with such data entered in the fields
            // здесь нужно будет проверить что такой логи и пароль существуют в бд это нужно сделать в отдельной фукции которая будет проверять это  
            //функция которая проверяет если есть такой пользователь с такими данными введенными в поля
            if (InputFieldsManager.CheckPasswordValidity(passwordBox_enter))
            {
                //these functions return a string with the maintained data in their textbooks
                //данные функции возвращают строку с веденными данными в их текстБоксы
                string login = InputFieldsManager.ReturnStringFromTextBox(textBox_login),
                       password = InputFieldsManager.ReturnPasswordFromTextBox(passwordBox_enter);

                //if all is OK, so we go to the Work window
                long userID = CredentialsManager.Authorize(login, password);
                if (userID != -1)
                {
                    using (StreamWriter writer = new StreamWriter("id.txt"))
                    {
                        writer.Write(userID);
                    }
                    WorkWindow work = new WorkWindow();
                    GoToWork(work);
                }
                else
                {
                    MessageBox.Show("Error. Can not find user with current login and password");
                }
            }
            else
            {
                MessageBox.Show("Such user doesn't exist");
            }

        }

        //переходим к рабочему окну
        ///<summary>
        ///method that goes to another window
        ///</summary>
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
            InputFieldsManager.CheckLiteralValidity(textBox_login);
        }               
    }
}
