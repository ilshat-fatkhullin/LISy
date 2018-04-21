using LISy.Entities;
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
using System.Windows.Shapes;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для LibrarianModify.xaml
    /// </summary>
    public partial class ModifyLibrarian : Window
    {
        public ModifyLibrarian()
        {
            InitializeComponent();
        }

        private void librarianDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLibrarianDataGrid();
        }

        private void librarianDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            User user = librarianDataGrid.SelectedItem as User;
            if (user == null)
                return;

        }
        /// <summary>
        /// update data gri for librarians
        /// </summary>
        public void UpdateLibrarianDataGrid()
        {
            List<User> result = new List<User>();
            result.Clear();
            foreach (User user in LibrarianDataManager.GetAllUsersList())
            {
                if (user.Type == Librarian.TYPE)
                {
                    result.Add(user);
                }

            }
            librarianDataGrid.ItemsSource = result;
        }
    }
}
