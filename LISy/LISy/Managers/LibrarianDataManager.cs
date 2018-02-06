using LISy.Entities;
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

        public static void EditDocument(IDocument document, IDocument newDocument)
        {
            DocumentsDataManager.EditDocument(document, newDocument);
        }

        public static bool AddPatron(IPatron patron, string login, string password)
        {
            return UsersDataManager.AddPatron(patron, login, password);
        }

        public static void DeletePatron(IPatron patron)
        {
            UsersDataManager.DeletePatron(patron);
        }

        public static void EditPatron(IPatron patron, IPatron newPatron)
        {
            UsersDataManager.EditPatron(patron, newPatron);
        }

        public static IDocument[] GetAllCopiesList()
        {
            return DocumentsDataManager.GetAllCopiesList();
        }
    }
}
