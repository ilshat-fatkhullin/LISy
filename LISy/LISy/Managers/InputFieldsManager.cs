using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LISy.Managers
{
    public static class InputFieldsManager
    {
        public static bool CheckPasswordValidity(PasswordBox passwordBox)
        {
            bool flag = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(passwordBox.Password, "[a-zA-Z]+$"))
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("Such character is not available.");
                passwordBox.Clear();
            }
            return flag;
        }

        public static string ReturnFromTextBox(TextBox textBox)
        {
            string input = "";
            if (textBox.Text != null)
            {
                input = textBox.Text;
            }
            return input;
        }

        public static string ReturnPasswordFromTextBox(PasswordBox passwordBox)
        {
            string password = "";
            if (passwordBox.Password != null)
            {
                password = passwordBox.Password;
            }
            return password;
        }
    }
}
