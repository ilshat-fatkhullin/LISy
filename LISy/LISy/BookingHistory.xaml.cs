using LISy.Entities;
using LISy.Entities.Users;
using LISy.Managers.DataManagers;
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
    /// Логика взаимодействия для BookingHistory.xaml
    /// </summary>
    public partial class BookingHistory : Window
    {
        private IPatron patron;
        public BookingHistory(IPatron patron)
        {
            InitializeComponent();
            GetAllAboutUser(patron);
            this.patron = patron;
        }
        public void GetAllAboutUser(IPatron patron)
        {
            name_patron.Content = patron.FirstName;
            id_patron.Content = patron.CardNumber;
            
        }

        private void DataGridChekOutDoc(object sender, RoutedEventArgs e)
        {
            List<Copy> result = new List<Copy>();
            result.Clear();
            foreach (Copy doc in DocumentsDataManager.GetCheckedByUserCopiesList(patron.CardNumber))
            {
                result.Add(doc);
            }
            check_out_doc.ItemsSource = result;
        }
    }
}
