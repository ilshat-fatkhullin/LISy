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
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Managers;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для LibrarianWorkWindow.xaml
    /// </summary>
    public partial class LibrarianWorkWindow : Window
    {
        public LibrarianWorkWindow()
        {
            InitializeComponent();
        }

        private void choose_user_card_Click(object sender, RoutedEventArgs e)
        {
            //grid_Loaded();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateUsersDataGrid();
            UpdateDataGridBook();
            UpdateDataGridCopies();
            //UptadeDataGridAV_material();
        }

        private void add_user_Click(object sender, RoutedEventArgs e)
        {
            AddUserCard addUserCard = new AddUserCard();
            addUserCard.Owner = this;
            addUserCard.Show();
        }

        private void add_doc_Click(object sender, RoutedEventArgs e)
        {
            AddDocument addDocument = new AddDocument();
            addDocument.Owner = this;
            addDocument.Show();
        }

        private void grid_LoadedUser(object sender, RoutedEventArgs e)
        {
            UpdateUsersDataGrid();
        }                    

        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {            
            IUser user = DataGridInfoUser.SelectedItem as IUser;
            if (user == null)
                return;

            if (user.Type != "Librarian")
            {
                UserModifyWindow window = new UserModifyWindow(user, this);
                window.Show();
            }
        }


        public void UpdateUsersDataGrid()
        {
            List<IUser> result = new List<IUser>();
            result.Clear();
            foreach (IUser user in LibrarianDataManager.GetAllUsersList())
            {
                result.Add(user);
            }
            DataGridInfoUser.ItemsSource = result;
        }
        private void UpdateDataGridBook()
        {
            List<Book> result = new List<Book>();
            result.Clear();
            foreach (Book book in LibrarianDataManager.GetAllBooksList())
            {
                result.Add(book);
            }
            DataGridBook.ItemsSource = result;
        }

        private void grid_LoaderBook(object sender, RoutedEventArgs e)
        {
            UpdateDataGridBook();
        }
        /*private void UptadeDataGridAV_material()
        {
            List<AVMaterial> result = new List<AVMaterial>();
            result.Clear();
            foreach (AVMaterial av_material in LibrarianDataManager.GetAllAVMaterialList())
            {
                result.Add(av_material);
            }
            DataGridAV_material.ItemsSource = result;
        }*/
        private void grid_LoaderAV_material(object sender, RoutedEventArgs e)
        {
            //UptadeDataGridAV_material();
        }

        private void grid_LoaderReference_book(object sender, RoutedEventArgs e)
        {
            // сюда нужны апдейты такие как для копий и книжек
        }

        private void grid_LoaderJournal_article(object sender, RoutedEventArgs e)
        {
            // сюда нужны апдейты такие как для копий и книжек
        }

        private void grid_LoaderCopies(object sender, RoutedEventArgs e)
        {
            UpdateDataGridCopies();
        }
        private void UpdateDataGridCopies()
        {
            List<Copy> result = new List<Copy>();
            result.Clear();
            foreach (Copy copy in LibrarianDataManager.GetAllCopiesList())
            {
                result.Add(copy);
            }
            DataGridCopies.ItemsSource = result;
        }

        private void add_librarian_Click(object sender, RoutedEventArgs e)
        {
            //сюда нужно добавить добавление библиотекаря пока есть окошко с именем и статусом 
            AddLibrarian addLibrarian = new AddLibrarian();
            addLibrarian.Owner = this;
            addLibrarian.Show();
        }
    }
}
