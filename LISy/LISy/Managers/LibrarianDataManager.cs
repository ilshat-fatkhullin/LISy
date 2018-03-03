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

        public static Copy[] GetAllCopiesList()
        {
            return DocumentsDataManager.GetAllCopiesList();
        }

        public static Copy[] GetCheckedCopiesList()
        {
            return DocumentsDataManager.GetCheckedCopiesList();
        }

        public static IUser[] GetAllUsersList()
        {
            return UsersDataManager.GetUsersList();
        }
        public static Book[] GetAllBooksList()
        {
            return DocumentsDataManager.GetAllBooksList();

        }

        public static AVMaterial[] GetAllAVMaterialList()

        {
            return DocumentsDataManager.GetAllAVMaterialsList();
        }
        public static void ReturnDocument(long DocumentId, long UserId)
        {
            DocumentsDataManager.ReturnDocument(DocumentId,UserId);
        }
    }
}
