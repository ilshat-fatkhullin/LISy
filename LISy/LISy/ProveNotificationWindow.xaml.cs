using LISy.Entities.Notifications;
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
