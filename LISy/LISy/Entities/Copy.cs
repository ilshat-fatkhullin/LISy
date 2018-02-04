using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
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
        /// Determines whether the copy is checked out by some Patron.
        /// </summary>
        /// <returns>true if copy is not checked out, false otherwise.</returns>
        public bool IsAvailable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<long>("dbo.spCopies_GetAvailableCopies @BookId", new { BookId = Document.ID }).ToList();
                return (output.Count != 0);
            }

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
