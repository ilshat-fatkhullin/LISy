using LISy.Entities;
using LISy.Entities.Users;
using LISy.Managers;
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
		/// <summary>
		/// Main window.
		/// </summary>
		public MainWindow()
		{			
			InitializeComponent();
		}
		///<summary>
		///when users input all data to textBoxes clicked on this button user go to workWindow but before system will checked all data in textBoxes and checked if this user exist
		///</summary>
		private void button_sign_in_Click(object sender, RoutedEventArgs e)
		{
			// here you will need to check that a username and password exist in dB it should be done in a separate function which will check it
			if (InputFieldsManager.CheckPasswordValidity(passwordBox_enter))
			{
				//these functions return a string with the maintained data in their textbooks
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
					GoToWork(LibrarianDataManager.GetUserById(userID));
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
		///<summary>
		///method that goes to WorkWindow
		///</summary>
		private void GoToWork(User user)
		{
			Window window;
			switch (user.Type)
			{
                case "Admin":
                    window = new AdminWindow();
                    break;
				case Librarian.TYPE:
					window = new LibrarianWorkWindow(user.CardNumber);
					break;
				default:
					window = new WorkWindow(user.CardNumber);
					break;
			}
			window.Show();
			this.Close();
		}
        /// <summary>
        /// Go to special window (Register_Window) to begin process of sign up (put Name, Last name, phone, addres...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button_sign_up_Click(object sender, RoutedEventArgs e)
		{
			//нужно проверить что бы окно входа было закрытым
			RegisterWindow registerWindow = new RegisterWindow();
			registerWindow.Show();
			fileExitMainWindow_Click(registerWindow);
		}
		/// <summary>
        /// Close window
        /// </summary>
        /// <param name="window">object of class window</param>
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
