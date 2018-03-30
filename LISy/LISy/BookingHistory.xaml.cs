using LISy.Entities;
using LISy.Entities.Users;
using LISy.Managers;
using System.Collections.Generic;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для BookingHistory.xaml
    /// </summary>
    public partial class BookingHistory : Window
    {
        private Patron patron;
        public BookingHistory(Patron patron)
        {
            InitializeComponent();
            GetAllAboutUser(patron);
            this.patron = patron;
        }
        public void GetAllAboutUser(Patron patron)
        {
            name_patron.Content = patron.FirstName;
            id_patron.Content = patron.CardNumber;
            
        }

        private void DataGridChekOutDoc(object sender, RoutedEventArgs e)
        {
            List<Copy> result = new List<Copy>();
            result.Clear();
            foreach (Copy doc in LibrarianDataManager.GetCheckedByUserCopiesList(patron.CardNumber))
            {
                result.Add(doc);
            }
            check_out_doc.ItemsSource = result;
        }
    }
}
