using LISy.Entities.Documents;
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
    /// Логика взаимодействия для AVMaterialInfoWindow.xaml
    /// </summary>
    public partial class AVMaterialInfoWindow : Window
    {
        private Patron patron;
        private AVMaterial avMaterial;
        private WorkWindow workWindow;
        public AVMaterialInfoWindow(AVMaterial avMaterial, Patron patron, WorkWindow workWindow)
        {
            InitializeComponent();
            this.avMaterial = avMaterial;
            this.patron = patron;
            this.workWindow = workWindow;
            LoadImage(avMaterial);
            TitleLabel.Content = avMaterial.Title;
            Authors.Content = avMaterial.Authors;

            if (LibrarianDataManager.IsAvailable(avMaterial.Id, patron.CardNumber))
            {
                BookButton.IsEnabled = true;
                InStockLabel.Content = "Available.";
            }
            else
            {
                BookButton.IsEnabled = false;
                InStockLabel.Content = "Not available.";
            }
            if (BookButton.IsEnabled == false)
            {
                GoToQueue.IsEnabled = true;
            }
            else
            {
                GoToQueue.IsEnabled = false;
            }
        }
        public void LoadImage(AVMaterial avMaterial)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Design/CA.jpg", UriKind.Relative);
            bi3.EndInit();
            imagesourse.Stretch = Stretch.Fill;
            imagesourse.Source = bi3;
        }
        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.CheckOutDocument(avMaterial.Id, patron.CardNumber);
            BookButton.IsEnabled = false;
            InStockLabel.Content = "Not available.";
            ReturnDataLabel.Content = avMaterial.EvaluateReturnDate(patron.Type);
        }

        private void GoToQueue_Click(object sender, RoutedEventArgs e)
        {
            PatronDataManager.AddToQueue(avMaterial.Id, patron.CardNumber);
            GoToQueue.IsEnabled = false;
        }
    }
}
