using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities.Documents;
using LISy.Entities.Users;

namespace LISy.Entities
{
    public class Copy
    {
        public Takable Document { get; private set; }

        public Patron Patron { get; private set; }

        public Copy(Takable document)
        {
            Document = document ?? throw new ArgumentNullException("Copy should refer to a document!");
            Patron = null;
        }

        public bool IsAvailable()
        {
            return Patron == null;
        }

        public void CkeckOut(Patron patron)
        {
            Patron = patron ?? throw new ArgumentNullException("Copy should be checkout to a patron!");
            // Patron.Books.Add(this)
        }

        public void Return()
        {
            Patron = null;
        }
    }
}
