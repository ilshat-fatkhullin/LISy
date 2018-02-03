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

        /// <summary>
        /// Initializes a new instance of library client.
        /// </summary>
        /// <param name="firstName">First name of the patron.</param>
        /// <param name="secondName">Second name of the patron.</param>
        /// <param name="cardNumber">Card number of the patron.</param>
        /// <param name="phone">Phone number of the patron.</param>
        /// <param name="address">Address of the patron.</param>
        public Patron(string firstName, string secondName, string phone, string address) : base(firstName, secondName, phone, address)
        {
            TakenCopies = new List<Copy>();
        }

        /// <summary>
        /// Determines whether the patron has a copy of a document.
        /// </summary>
        /// <param name="document">Document which copy will be searched.</param>
        /// <returns>true if patron has a copy of such document, false otherwise.</returns>
        public bool HasCopyOfDocument(Takable document)
        {
            foreach (Copy temp in TakenCopies)
                if (temp.Document.Equals(document))
                {
                    LastFoundCopy = temp;
                    return true;
                }
            return false;
        }

        /// <summary>
        /// Checks out a copy of a document.
        /// </summary>
        /// <param name="document">Document which copy will be checked out.</param>
        public void CheckOutDocument(Takable document)
        {
            if (HasCopyOfDocument(document)) throw new ArgumentException("Such document has already been borrowed!");
            TakenCopies.Add(document.CheckOutCopy(this));
        }

        /// <summary>
        /// Returns a copy to the library.
        /// </summary>
        /// <param name="document">Document which copy will be returned.</param>
        public void ReturnDocument(Takable document)
        {
            if (!HasCopyOfDocument(document)) throw new ArgumentException("Such document has not been borrowed!");
            TakenCopies.Remove(LastFoundCopy);
            LastFoundCopy.Return();
        }
    }
}
