using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities.Documents;

namespace LISy.Entities.Users
{
    public abstract class Patron : User, IPatron
    {
        public List<Copy> TakenCopies { get; protected set; }
        private Copy LastFoundCopy = null;

        public Patron(string name, long cardNumber, string phone, string address) : base(name, cardNumber, phone, address)
        {
            TakenCopies = new List<Copy>();
        }

        public bool FindCopyOfDocument(Takable document)
        {
            foreach (Copy temp in TakenCopies)
                if (temp.Document.Equals(document))
                {
                    LastFoundCopy = temp;
                    return true;
                }
            return false;
        }

        public void CheckOutDocument(Takable document)
        {
            if (FindCopyOfDocument(document)) throw new ArgumentException("Such document has already been borrowed!");
            TakenCopies.Add(document.CheckOutCopy(this));
        }

        public void ReturnDocument(Takable document)
        {
            if (!FindCopyOfDocument(document)) throw new ArgumentException("Such document has not been borrowed!");
            TakenCopies.Remove(LastFoundCopy);
            LastFoundCopy.Return();
        }
    }
}
