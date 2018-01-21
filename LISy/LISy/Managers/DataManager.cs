using LISy.Entities;
using LISy.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers
{
    public class DataManager: ILibrarianDataManager, IPatronDataManager
    {
        public DataManager()
        {

        }

        public void AddDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public void EditDocument(Document document, Document newDocument)
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
