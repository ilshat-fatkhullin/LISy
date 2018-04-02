using LISy.Entities.Notifications;
using LISy.Entities.Users;
using LISy.Managers;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для ProveNotificationWindow.xaml
    /// </summary>
    public partial class ProveNotificationWindow : Window
    {
        private InfoAndNotificationsWindow InfoAndNotificationsWindow;
        private Patron patron;
        private Notification notification;
        public ProveNotificationWindow(Patron patron,InfoAndNotificationsWindow infoAndNotificationsWindow, Notification notification)
        {
            InitializeComponent();
            this.patron = patron;
            this.notification = notification;
            this.InfoAndNotificationsWindow = infoAndNotificationsWindow;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (acceptedCheckBox.IsChecked == true)
            {
                PatronDataManager.ReadNotification(notification.Id);
            }
            InfoAndNotificationsWindow.UpdateNotificationDataGrid();
            this.Close();
        }
    }
}
