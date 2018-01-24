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
        public Takable Doc { get; private set; }
        public Patron Patron { get; private set; }

        public Copy(Takable doc)
        {
            Doc = doc;
            Patron = null;
        }

        public bool IsAvailable()
        {
            return Patron == null;
        }

        public void CkeckOut(Patron patron)
        {
            Patron = patron;
            // Patron.Books.AddLast(this)
        }

        public void Return()
        {
            Patron = null;
            Doc.ReturnCopy();
        }
    }
}
