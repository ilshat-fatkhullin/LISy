using LISy.Entities;
using LISy.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers
{
    interface ILibrarianDataManager
    {
        void AddDocument(Document document);

        void DeleteDocument(Document document);

        void EditDocument(Document document, Document newDocument);

        void AddPatron(Patron patron);

        void DeletePatron(Patron patron);

        void EditPatron(Patron patron, Patron newPatron);           
    }
}
