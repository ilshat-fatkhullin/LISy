using LISy.Entities.Notifications;
using LISy.Entities.Users;
using LISy.Managers;
using System.Collections.Generic;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// update log data grid
        /// </summary>
        public void UpdateLogDataGrid()
        {
            List<LogContent> result = new List<LogContent>();
            result.Clear();
            foreach (LogContent log in LibrarianDataManager.GetAllLogs())
            {
                result.Add(log);
            }
            LogDataGrid.ItemsSource = result;
        }
        /// <summary>
        /// update librarians list
        /// </summary>
        public void UpdateLibrariansDataGrid()
        {
            List<Librarian> result = new List<Librarian>();
            result.Clear();
            foreach (Librarian librarian in LibrarianDataManager.GetAllLibrarians())
            {
                result.Add(librarian);
            }
            LibrariansDataGrid.ItemsSource = result;
        }
        private void LogDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLogDataGrid();
        }

        private void LibrariansDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLibrariansDataGrid();
        }

        private void LibrariansDataGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Librarian librarian = LibrariansDataGrid.SelectedItem as Librarian;
            if (librarian == null)
                return;

            LibAdminModify window = new LibAdminModify(librarian, this);
            window.Owner = this;
            window.Show();
        }
    }
}
