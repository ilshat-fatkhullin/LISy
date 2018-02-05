using System.Windows;
using System.Windows.Controls;

namespace LISy.Managers
{
    /// <summary>
    /// Contains functions for input data validity checking
    /// </summary>
    public static class InputFieldsManager
    {
        /// <summary>
        /// Checks is password valid or not
        /// </summary>
        /// <param name="passwordBox">Password box, which contains a password</param>
        /// <returns>True if valid, false otherwise</returns>
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

        /// <summary>
        /// Returns string text from text box
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static string ReturnStringFromTextBox(TextBox textBox)
        {
            string input = "";
            if (textBox.Text != null)
            {
                input = textBox.Text;
            }
            return input;
        }

        /// <summary>
        /// Returns password string from password box
        /// </summary>
        /// <param name="passwordBox"></param>
        /// <returns></returns>
        public static string ReturnPasswordFromTextBox(PasswordBox passwordBox)
        {
            string password = "";
            if (passwordBox.Password != null)
            {
                password = passwordBox.Password;
            }
            return password;
        }

        /// <summary>
        /// Checks is text box contains only numbers
        /// </summary>
        /// <param name="textBox"></param>
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

        /// <summary>
        /// Checks is text contains only literals
        /// </summary>
        /// <param name="textBox"></param>
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
