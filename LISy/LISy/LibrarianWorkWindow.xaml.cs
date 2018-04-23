using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Managers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для LibrarianWorkWindow.xaml
    /// </summary>
    public partial class LibrarianWorkWindow : Window
    {
        private User user;
        private int accesLevel;
        private Librarian librarian;
        /// <summary>
        /// Window for work window
        /// </summary>
        /// <param name="userId"></param>
        public LibrarianWorkWindow(long userId)
        {
            InitializeComponent();
            LibrarianDataManager.LibrarianId = userId;
            user = LibrarianDataManager.GetUserById(userId);
            librarian_name_fill.Content = user.FirstName;
            librarian_status_fill.Content = user.Type;
            librarian = LibrarianDataManager.GetLibrarianById(userId);
            accesLevel = librarian.Authority;
            librarianLevel.IsEnabled = false;
            if (accesLevel == 1)
            {
                add_user.IsEnabled = false;
                add_doc.IsEnabled = false;
                copies.IsEnabled = false;
                Check_out_Copies.IsEnabled = false;

            }
            else if (accesLevel == 3)
            {
                Check_out_Copies.IsEnabled = false;
            }

        }
        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateUsersDataGrid();
            UpdateDataGridBook();
            UpdateDataGridCopies();
            UptadeDataGridAV_material();
            UpdatDataGridChekedOutCopies();
            UpdateDataGridInnerMaterials();
            UpdateDataGridJournal();
            UptadeDataGridJournalArticles();
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
        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            User user = DataGridInfoUser.SelectedItem as User;
            if (user == null)
                return;

            if (user.Type != Librarian.TYPE && user.Type != "Admin")
            {
                UserModifyWindow window = new UserModifyWindow(user, this, accesLevel);
                window.Owner = this;
                window.Show();
            }
        }

        private void grid_MouseUpForBook(object sender, MouseButtonEventArgs e)
        {
            Book book = DataGridBook.SelectedItem as Book;
            if (book == null)
                return;

            BookModifyWindow window = new BookModifyWindow(book, this, accesLevel);
            window.Owner = this;
            window.Show();

        }
        private void grid_MouseUpForAVMaterial(object sender, MouseButtonEventArgs e)
        {
            AVMaterial AVmaterial = DataGridAV_material.SelectedItem as AVMaterial;
            if (AVmaterial == null)
                return;

            ModifyAVMaterials window = new ModifyAVMaterials(AVmaterial, this, accesLevel);
            window.Owner = this;
            window.Show();

        }

        private void grid_MouseUpForCheckedOutCopies(object sender, MouseButtonEventArgs e)
        {
            Copy copy = DataGridCheckedOutCopies.SelectedItem as Copy;
            if (copy == null)
                return;

            ModifyChekedOutCopies window = new ModifyChekedOutCopies(copy.DocumentId, copy.PatronId, this);
            window.Owner = this;
            window.Show();
        }

        private void grid_LoadedUser(object sender, RoutedEventArgs e)
        {
            UpdateUsersDataGrid();
        }

        private void grid_LoaderBook(object sender, RoutedEventArgs e)
        {
            UpdateDataGridBook();
        }
        private void grid_LoaderAV_material(object sender, RoutedEventArgs e)
        {
            UptadeDataGridAV_material();
        }
        private void grid_LoaderReference_book(object sender, RoutedEventArgs e)
        {
            UpdateDataGridInnerMaterials();
        }
        private void grid_LoaderCopies(object sender, RoutedEventArgs e)
        {
            UpdateDataGridCopies();
        }
        private void grid_LoaderCheckedOutCopies(object sender, RoutedEventArgs e)
        {
            UpdatDataGridChekedOutCopies();
        }
        private void copies_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGridCopies();
        }
        public void UpdatDataGridChekedOutCopies()
        {
            List<Copy> result = new List<Copy>();
            result.Clear();
            foreach (Copy copy in LibrarianDataManager.GetCheckedCopiesList())
            {
                result.Add(copy);
            }
            DataGridCheckedOutCopies.ItemsSource = result;
        }
        public void UpdateUsersDataGrid()
        {
            List<User> result = new List<User>();
            result.Clear();
            foreach (User user in LibrarianDataManager.GetAllUsersList())
            {
                result.Add(user);
            }
            DataGridInfoUser.ItemsSource = result;
        }
        public void UpdateDataGridBook()
        {
            List<Book> result = new List<Book>();
            result.Clear();
            foreach (Book book in LibrarianDataManager.GetAllBooksList())
            {
                result.Add(book);
            }
            DataGridBook.ItemsSource = result;
        }
        public void UpdateDataGridCopies()
        {
            List<Copy> result = new List<Copy>();
            result.Clear();
            foreach (Copy copy in LibrarianDataManager.GetAllCopiesList())
            {
                result.Add(copy);
            }
            DataGridCopies.ItemsSource = result;
        }

        public void UpdateDataGridInnerMaterials()
        {
            List<InnerMaterial> result = new List<InnerMaterial>();
            result.Clear();
            foreach (InnerMaterial inner in LibrarianDataManager.GetAllInnerMaterialsList())
            {
                result.Add(inner);
            }
            DataGridRefernce_book.ItemsSource = result;
        }


        public void UpdateDataGridJournal()
        {
            List<Journal> result = new List<Journal>();
            result.Clear();
            foreach (Journal journal in LibrarianDataManager.GetAllJournalsList())
            {
                result.Add(journal);
            }
            DataGridJournal.ItemsSource = result;
        }

        public void UptadeDataGridAV_material()
        {
            List<AVMaterial> result = new List<AVMaterial>();
            result.Clear();
            foreach (AVMaterial av_material in LibrarianDataManager.GetAllAVMaterialsList())
            {
                result.Add(av_material);
            }
            DataGridAV_material.ItemsSource = result;
        }

        private void copies_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Copy copy = DataGridCopies.SelectedItem as Copy;
            if (copy == null)
                return;

            DeleteCopy window = new DeleteCopy(copy, this);
            window.Owner = this;
            window.Show();
        }

        private void log_out_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void grid_LoaderJournal(object sender, RoutedEventArgs e)
        {
            UpdateDataGridJournal();
        }
        public void UptadeDataGridJournalArticles()
        {
            List<Article> result = new List<Article>();
            result.Clear();
            foreach (Article article in LibrarianDataManager.GetAllArticlesList())
            {
                result.Add(article);
            }
            JournalArticleDataGrid.ItemsSource = result;
        }

        private void reference_book_MouseUp(object sender, MouseButtonEventArgs e)
        {
            InnerMaterial inner = DataGridRefernce_book.SelectedItem as InnerMaterial;
            if (inner == null)
                return;

            ModifyInnerMaterial window = new ModifyInnerMaterial(inner, this, accesLevel);
            window.Owner = this;
            window.Show();
        }
        private void journalArticles_Loaded(object sender, RoutedEventArgs e)
        {
            UptadeDataGridJournalArticles();
        }
        private void journalMouseUp(object sender, MouseButtonEventArgs e)
        {
            Journal journal = DataGridJournal.SelectedItem as Journal;
            if (journal == null)
                return;

            ModifyJournal window = new ModifyJournal(journal, this, accesLevel);
            window.Owner = this;
            window.Show();

        }

        private void journal_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGridJournal();
        }

        private void librarianLevel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
