using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities.Users;

namespace LISy.Entities.Documents
{
    /// <summary>
    /// Describes properties of a set of documents that can be checked out.
    /// </summary>
    public abstract class Takable : Document
    {
        public int Price { get; protected set; }

        public List<Copy> Copies { get; protected set; }

        private Copy LastAvailableCopy;

        /// <summary>
        /// Initializes a new instance of library document that can be checked out.
        /// </summary>
        /// <param name="authors">Authors or editors of the document.</param>
        /// <param name="title">Title of the document.</param>
        /// <param name="keys">Keywords using which the document can be found.</param>
        /// <param name="image">Cover of the document.</param>
        /// <param name="price">Price of the document.</param>
        /// <param name="amount">Amount of copies of the document.</param>
        public Takable(string[] authors, string title, string[] keys, string image, int price, int amount) : base(authors, title, keys, image)
        {
            if (amount <= 0) throw new ArgumentException("Amount of copies cannot be nonpositive!");
            Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative!");
            Copies = new List<Copy>();
            for (int i = 1; i <= amount; ++i)
                Copies.Add(new Copy(this));
            LastAvailableCopy = Copies[0];
        }

        /// <summary>
        /// Evaluates amount of available copies of the document.
        /// </summary>
        /// <returns>integer of amount of available copies.</returns>
        public int AvailableCopiesAmount()
        {
            int amount = 0;
            foreach (Copy temp in Copies)
            {
                if (IsAvailable()) ++amount;
            }
            return amount;
        }

        /// <summary>
        /// Determines whether the document is available.
        /// </summary>
        /// <returns>true if the document has at least 1 copy in the library, false otherwise.</returns>
        public bool IsAvailable()
        {
            if (LastAvailableCopy != null && IsAvailable()) return true;
            foreach (Copy temp in Copies)
            {
                if (IsAvailable())
                {
                    LastAvailableCopy = temp;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Allocates a copy of the document for a Patron to check out.
        /// </summary>
        /// <param name="patron">Patron that is checking out a copy.</param>
        /// <returns>a copy that was ckecked out.</returns>
        public Copy CheckOutCopy(Patron patron)
        {
            if (patron == null) throw new ArgumentNullException("Copy must be checked out by a Patron!");
            if (!IsAvailable()) throw new Exception("No availbale copies!");
            LastAvailableCopy.CkeckOut(patron);
            return LastAvailableCopy;
        }

        /// <summary>
        /// Adds new copies of the document.
        /// </summary>
        /// <param name="n">Amount of new copies.</param>
        public void AddCopies(int n)
        {
            if (n < 1) throw new ArgumentException("Ivalid amount of new copies!");
            for (int i = 1; i <= n; ++i)
                Copies.Add(new Copy(this));
        }

        /// <summary>
        /// Removes one copy of the document.
        /// </summary>
        public void RemoveCopy()
        {
            if (!IsAvailable()) throw new Exception("No availbale copies!");
            Copies.Remove(LastAvailableCopy);
            LastAvailableCopy = null;
        }
    }
}
