using LISy.Entities;
using LISy.Managers;
using System.Windows;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для DeleteCopy.xaml
    /// </summary>
    public partial class DeleteCopy : Window
    {
        private Copy copy;
        private long deleteCopID;
        private LibrarianWorkWindow workWindow;
        public DeleteCopy(Copy copy, LibrarianWorkWindow workWindow)
        {
            InitializeComponent();
            this.copy = copy;
            this.workWindow = workWindow;
        }

        private void delete_copy_Click(object sender, RoutedEventArgs e)
        {
            deleteCopID = copy.Id;
            bool f = true;
            foreach (Copy copy1 in LibrarianDataManager.GetCheckedCopiesList())
            {
                if (copy1.Id == deleteCopID)
                {
                    f = false;
                }
            }
            if (f)
            {
                LibrarianDataManager.DeleteCopy(copy);
            }
            this.Close();
        }
    }
}
