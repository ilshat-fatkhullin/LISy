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

        public static string ReturnStringFromTextBox(TextBox textBox)
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

        public static void CheckNumericValidity(TextBox textBox)
        {                        
            foreach (char c in textBox.Text.ToCharArray())
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("This textbox accepts only numbers.");
                    textBox.Clear();
                    break;
                }
            }
        }

        public static void CheckLiteralValidity(TextBox textBox)
        {
            if (textBox.Text.Length != 0)
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only English characters.");
                textBox.Clear();
            }
        }
    }
}
