using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Managers.DataManagers;

namespace LISy.Managers
{
    /// <summary>
    /// Contains database commands for librarians
    /// </summary>
    public static class LibrarianDataManager
    {
        public static void AddDocument(IDocument document)
        {
            DocumentsDataManager.AddDocument(document);
        }

        public static void DeleteDocument(IDocument document)
        {
            DocumentsDataManager.DeleteDocument(document);
        }

        public static void EditDocument(IDocument newDocument)
        {
            DocumentsDataManager.EditDocument(newDocument);
		}

		public static void ReturnDocument(long DocumentId, long UserId)
		{
			DocumentsDataManager.ReturnDocument(DocumentId, UserId);
		}

		public static bool AddUser(IUser user, string login, string password)
        {
            return UsersDataManager.AddUser(user, login, password);
        }

        public static void DeleteUser(IUser user)
        {
            UsersDataManager.DeleteUser(user);
        }

        public static void EditUser(IUser newUser)
        {
            UsersDataManager.EditUser(newUser);
        }

        public static void AddCopy(int n, Copy copy)
        {
            DocumentsDataManager.AddCopy(n, copy);
        }

        public static void DeleteCopy(Copy copy)
        {
            DocumentsDataManager.DeleteCopy(copy);
        }

        public static void DeleteCopyByDocId(Copy copy)
        {
            DocumentsDataManager.DeleteCopyByDocId(copy);
        }

        public static Copy[] GetAllCopiesList()
        {
            return DocumentsDataManager.GetAllCopiesList();
        }

        public static void ClearAll()
        {
            DatabaseDataManager.ClearAll();
        }

        public static Copy[] GetCheckedCopiesList()
        {
            return DocumentsDataManager.GetCheckedCopiesList();
        }

        public static IUser[] GetAllUsersList()
        {
            return UsersDataManager.GetUsersList();
        }

        public static AVMaterial[] GetAllAVMaterialsList()
        {
            return DocumentsDataManager.GetAllAVMaterialsList();
        }

        public static Book[] GetAllBooksList()
        {
            return DocumentsDataManager.GetAllBooksList();
        }

        public static int GetNumberOfDocuments()
        {
            return DocumentsDataManager.GetNumberOfDocuments();
        }

        public static int GetNumberOfUsers()
        {
            return UsersDataManager.GetNumberOfUsers();
        }

        public static int GetNumberOfCopies()
        {
            return DocumentsDataManager.GetNumberOfCopies();
        }

        public static InnerMaterial[] GetAllInnerMaterialsList()
        {
            return DocumentsDataManager.GetAllInnerMaterialsList();
        }

        public static Journal[] GetAllJournalsList()
        {
            return DocumentsDataManager.GetAllJournalsList();
        }

        public static JournalArticle[] GetAllJournalArticlesList()
        {
            return DocumentsDataManager.GetAllJournalArticlesList();
        }

        public static IUser GetUserById(long userId)
        {
            return CredentialsManager.GetUserByID(userId);
        }
    }
}
