using LISy.Entities.Users;
using LISy.Managers;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        private Patron patron;
        /// <summary>
        /// Window to see info about patron
        /// </summary>
        public UserProfile(Patron patron)
        {
            InitializeComponent();
            this.patron = patron;
        }
        /// <summary>
        /// Initilization info about Patron
        /// </summary>
        public void InitilizePatron(Patron patron) {
            int amountChekedOutCopies = LibrarianDataManager.GetCheckedByUserCopiesList(patron.CardNumber).Length;
            nameLabeloutput.Content = patron.FirstName;
            lastNameLabeloutput.Content = patron.SecondName;
            addressLabeloutput.Content = patron.Address;
            phoneLabeloutput.Content = patron.Phone;
            typeLabeloutput.Content = patron.Type;
            amountOfCopiesLabeloutput.Content = amountChekedOutCopies;
        }
    }
}
