using Dapper;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using System;
using System.Data;
using System.Linq;

namespace LISy.Entities
{
    /// <summary>
    /// Represents physical copies of documents.
    /// </summary>
    public class Copy
    {
        public Takable Document { get; private set; }

        public Patron Patron { get; private set; }

        public int Room { get; private set; }

        public int Level { get; private set; }

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
        /// Records a Patron that is checking out the copy.
        /// </summary>
        /// <param name="patron">Patron that is checking out the copy.</param>
        public void CkeckOut(Patron patron)
        {
            Patron = patron ?? throw new ArgumentNullException("Copy must be checked out by a Patron!");
        }

        /// <summary>
        /// Records that the copy was returned to the library.
        /// </summary>
        public void Return()
        {
            Patron = null;
        }

        /// <summary>
        /// Moves the copy to new place in the library.
        /// </summary>
        /// <param name="room">Room where the copy will be moved.</param>
        /// <param name="level">Level of new room of the copy.</param>
        public void ChangePlace(int room, int level)
        {
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
        }
    }
}
