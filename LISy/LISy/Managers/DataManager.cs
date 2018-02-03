using LISy.Entities;
using LISy.Entities.Users;
using LISy.Managers.DataManagers;

namespace LISy.Managers
{
    /// <summary>
    /// Shouldn't be declared somewhere.
    /// It is just an implementation of interfaces <code>ILibrarianDataManager</code> and <code>IPatronDataManager</code>.
    /// The main data manager class.
    /// Contains of two classes <code>DocumentsDataManager</code> and <code>UsersDataManager</code>, which implement data managment functions.
    /// </summary>
    public class DataManager: ILibrarianDataManager, IPatronDataManager
    {
        private DocumentsDataManager documentsDataManager;
        private UsersDataManager usersDataManager;

        public DataManager()
        {            
            documentsDataManager = new DocumentsDataManager();
            usersDataManager = new UsersDataManager();
        }

        /// <summary>
        /// Adds new document to the database.
        /// </summary>
        /// <param name="document">Document, which is going to be added.</param>
        public void AddDocument(IDocument document)
        {
            documentsDataManager.AddDocument(document);
        }

        /// <summary>
        /// Deletes a document from the database.
        /// </summary>
        /// <param name="document">Document, which is going to be deleted.</param>
        public void DeleteDocument(IDocument document)
        {
            documentsDataManager.DeleteDocument(document);
        }

        /// <summary>
        /// Replaces <code>document</code> on <code>newDocument</code> in the database.
        /// </summary>
        /// <param name="document">Document, which is going to be replaced.</param>
        /// <param name="newDocument">Document, which is going to be instead of <code>document</code>.</param>
        public void EditDocument(IDocument document, IDocument newDocument)
        {
            documentsDataManager.EditDocument(document, newDocument);
        }

        /// <summary>
        /// Adds new patron to the database.        
        /// </summary>
        /// <param name="patron">Patron, which is going to be added.</param>
        /// <param name="password">Patron's account password</param>
        public bool AddPatron(IPatron patron, string login, string password)
        {
            return usersDataManager.AddPatron(patron, login, password);
        }

        /// <summary>
        /// Deletes a patron from the database.
        /// </summary>
        /// <param name="patron">Patron, which is going to be deleted.</param>
        public void DeletePatron(IPatron patron)
        {
            usersDataManager.DeletePatron(patron);
        }

        /// <summary>
        /// Replaces <code>patron</code> on <code>newPatron</code> in the database.
        /// </summary>
        /// <param name="patron">Patron, which is going to be replaced.</param>
        /// <param name="newPatron">Patron, which is going to be instead of <code>patron</code>.</param>
        public void EditPatron(IPatron patron, IPatron newPatron)
        {
            usersDataManager.EditPatron(patron, newPatron);
        }

                
        public void CheckOutDocument(IDocument document, IPatron patron)
        {
            documentsDataManager.CheckOutDocument(document, patron);
        }
    }
}
