using LISy.Entities;
using LISy.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers
{
    public interface ILibrarianDataManager
    {
        void AddDocument(IDocument document);

        void DeleteDocument(IDocument document);

        void EditDocument(IDocument document, IDocument newDocument);

        void AddPatron(Patron patron);

        void DeletePatron(Patron patron);

        void EditPatron(Patron patron, Patron newPatron);           
    }
}
