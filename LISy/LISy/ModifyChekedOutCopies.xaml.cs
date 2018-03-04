using LISy.Entities;
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
    /// Логика взаимодействия для ModifyChekedOutCopies.xaml
    /// </summary>
    public partial class ModifyChekedOutCopies : Window
    {
        private long documentId;
        private long userId;
        //private LibrarianWorkWindow workWindow;
        
        public ModifyChekedOutCopies(long documentId,long userId)
        {
            InitializeComponent();
            this.documentId = documentId;
            this.userId= userId;
        }

        private void change_status_of_copy_Click(object sender, RoutedEventArgs e)
        {
            if (make_book_returned.IsChecked == true && delete_copy.IsChecked == false)
            {
                LibrarianDataManager.ReturnDocument(documentId,userId);
            }
            
            this.Close();
        }
    }
}
