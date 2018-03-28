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
using LISy.Entities.Users;
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


		private void refresh_Click(object sender, RoutedEventArgs e)
		{
			UpdateUsersDataGrid();
			UpdateDataGridBook();
			UpdateDataGridCopies();
			UptadeDataGridAV_material();
			UpdatDataGridChekedOutCopies();
			UpdateDataGridInnerMaterials();
			UpdateDataGridJournal();
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
			IUser user = DataGridInfoUser.SelectedItem as IUser;
			if (user == null)
				return;

			if (user.Type != Librarian.TYPE)
			{
				UserModifyWindow window = new UserModifyWindow(user, this);
				window.Owner = this;
				window.Show();
			}
		}

		private void grid_MouseUpForBook(object sender, MouseButtonEventArgs e)
		{
			Book book = DataGridBook.SelectedItem as Book;
			if (book == null)
				return;

			BookModifyWindow window = new BookModifyWindow(book, this);
			window.Owner = this;
			window.Show();

		}
		private void grid_MouseUpForAVMaterial(object sender, MouseButtonEventArgs e)
		{
			AVMaterial AVmaterial = DataGridAV_material.SelectedItem as AVMaterial;
			if (AVmaterial == null)
				return;

			ModifyAVMaterials window = new ModifyAVMaterials(AVmaterial, this);
			window.Owner = this;
			window.Show();

		}

		private void grid_MouseUpForCheckedOutCopies(object sender, MouseButtonEventArgs e)
		{
			Copy copy = DataGridCheckedOutCopies.SelectedItem as Copy;
			if (copy == null)
				return;

			ModifyChekedOutCopies window = new ModifyChekedOutCopies(copy.DocumentID, copy.PatronID, this);
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
			// сюда нужны апдейты такие как для копий и книжек
			UpdateDataGridInnerMaterials();
		}
		private void grid_LoaderJournal_article(object sender, RoutedEventArgs e)
		{
			// сюда нужны апдейты такие как для копий и книжек
			UpdateDataGridJournal();
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
			List<IUser> result = new List<IUser>();
			result.Clear();
			foreach (IUser user in LibrarianDataManager.GetAllUsersList())
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
			DataGridJournal_article.ItemsSource = result;
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
	}
}
