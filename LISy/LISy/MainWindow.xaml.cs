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
            ILibrarianDataManager manager = new DataManager();
            IPatron patron1 = new Patron("Ilshat", "Fatkhullin", 4, "+79046640818", "Innopolis, University St., Dorm 1, Room 401");
            IPatron patron2 = new Patron("Rim", "Fatkuhllin", 1, "+79518975651", "Innopolis, University St., Dorm 1, Room 401");
            //manager.AddPatron(patron);
            //manager.EditPatron(patron1, patron2);
            manager.DeletePatron(patron1);
        }
        private void button_sign_in_Click(object sender, RoutedEventArgs e)
        {
            //данные функции возвращают строку с веденными данными в их текстБоксы
            SentIDFromTextBox(textBox_login);
            SentPasswordFromTextBox(passwordBox_enter);
            // здесь нужно будет проверить что такой логи и пароль существуют в бд это нужно сделать в отдельной фукции которая будет проверять это  
        }

        private void button_sign_up_Click(object sender, RoutedEventArgs e)
        {
            //нужноо проверить что бы окно входа было закрытым
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            fileExitMainWindow_Click(registerWindow);
        }
        void fileExitMainWindow_Click(RegisterWindow window)
        {
            // Close this(MainWindow) window
            this.Close();
        }

        private void textBox_login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox_login.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("This textbox accepts only English characters");
                textBox_login.Clear();
            }

        }

        private static String SentIDFromTextBox(TextBox textBox)
        {
            String id = "";
            if (textBox.Text != null)
            {
                id = textBox.Text;
            }

            return id;
        }
        private static String SentPasswordFromTextBox(PasswordBox passwordBox)
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
