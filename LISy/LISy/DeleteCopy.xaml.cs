using LISy.Entities;
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
            foreach (Copy copy1 in DocumentsDataManager.GetCheckedCopiesList())
            {
                if (copy1.Id == deleteCopID)
                {
                    f = false;
                }
            }
            if (f)
            {
                DocumentsDataManager.DeleteCopy(copy);
            }
            this.Close();
        }
    }
}
