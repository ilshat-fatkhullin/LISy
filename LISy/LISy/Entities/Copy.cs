using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities.Documents;

namespace LISy.Entities
{
    public class Copy
    {
        public Takable Doc { get; private set; }
        public User Patron { get; set; }

        public Copy(Takable doc)
        {
            Doc = doc;
            Patron = null;
        }

        public bool IsAvailable()
        {
            return Patron == null;
        }

        public void CkeckOut(User patron)
        {
            Patron = patron;
        }
    }
}
