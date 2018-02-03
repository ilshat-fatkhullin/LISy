using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities.Documents;
using LISy.Entities.Users;

namespace LISy.Entities
{
    /// <summary>
    /// Represents physical copies of documents.
    /// </summary>
    public class Copy
    {

        public Takable Document { get; private set; }

        public Patron Patron { get; private set; }

        /// <summary>
        /// Initializes an instance of document copy.
        /// </summary>
        /// <param name="document">Document to that copy refers.</param>
        public Copy(Takable document)
        {
            Document = document ?? throw new ArgumentNullException("Copy must refer to a document!");
            Patron = null;
        }

        /// <summary>
        /// Determines whether the copy is checked out by some Patron.
        /// </summary>
        /// <returns>true if copy is not checked out, false otherwise.</returns>
        public bool IsAvailable()
        {
            return Patron == null;
        }

        /// <summary>
        /// Records a patron that is checking out the copy.
        /// </summary>
        /// <param name="patron">Patron that is checking out the copy.</param>
        public void CkeckOut(Patron patron)
        {
            Patron = patron ?? throw new ArgumentNullException("Copy must be checked out by a patron!");
        }

        /// <summary>
        /// Records that the copy was returned to the library.
        /// </summary>
        public void Return()
        {
            Patron = null;
        }
    }
}
