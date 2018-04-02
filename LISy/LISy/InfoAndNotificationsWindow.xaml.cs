using LISy.Entities.Notifications;
using LISy.Entities.Users;
using LISy.Managers;
using System.Collections.Generic;
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
            Notification notification = notificationDataGrid.SelectedItem as Notification;
            if (notification == null)
                return;

            ProveNotificationWindow window = new ProveNotificationWindow(patron, this,notification);
            window.Owner = this;
            window.Show();
        }

        private void NotificationDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateNotificationDataGrid();
        }
        public void UpdateNotificationDataGrid()
        {
            List<Notification> result = new List<Notification>();
            result.Clear();
            foreach (Notification note in PatronDataManager.GetNotifications(patron.CardNumber))
            {
                result.Add(note);
            }
            notificationDataGrid.ItemsSource = result;
        }
    }
}
