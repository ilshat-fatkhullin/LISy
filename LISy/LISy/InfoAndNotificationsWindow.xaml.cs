using LISy.Entities.Users;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для InfoAndNotificationsWindow.xaml
    /// </summary>
    public partial class InfoAndNotificationsWindow : Window
    {
        private WorkWindow window;
        private Patron patron;
        /// <summary>
        /// window for patron to see all info and notification for it
        /// </summary>
        /// <param name="patron"></param>
        /// <param name="window"></param>
        public InfoAndNotificationsWindow(Patron patron, WorkWindow window)
        {
            InitializeComponent();
            this.window = window;
            this.patron = patron;
        }

        private void NotificationDataGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void NotificationDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateNotificationDataGrid();
        }
        public void UpdateNotificationDataGrid()
        {

        }
    }
}
