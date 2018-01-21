using LISy.Entities;
using LISy.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers
{
    /// <summary>
    /// Shouldn't be declared somewhere
    /// It is just an implementation of interfaces <code>ILibrarianDataManager</code> and <code>IPatronDataManager</code>
    /// </summary>
    public class DataManager: ILibrarianDataManager, IPatronDataManager
    {
        public DataManager()
        {
            throw new NotImplementedException();
        }

        public void AddDocument(IDocument document)
        {            
            throw new NotImplementedException();
        }

        public void DeleteDocument(IDocument document)
        {
            throw new NotImplementedException();
        }

        public void EditDocument(IDocument document, IDocument newDocument)
        {
            throw new NotImplementedException();
        }

        public void AddPatron(Patron patron)
        {
            throw new NotImplementedException();
        }

        public void DeletePatron(Patron patron)
        {
            throw new NotImplementedException();
        }

        public void EditPatron(Patron patron, Patron newPatron)
        {
            throw new NotImplementedException();
        }
    }
}
