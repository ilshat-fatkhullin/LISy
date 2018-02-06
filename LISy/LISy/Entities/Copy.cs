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
        public long ID { get; set; }

        public long DocumentID { get; private set; }

        public long PatronID { get; private set; }

        public bool Checked { get; set; }

        public string ReturningTime { get; set; }

        public int Room { get; set; }

        public int Level { get; set; }

        public Copy()
        {
        }

        public Copy(long documentid, long patronid)
        {
            DocumentID = documentid > 0 ? documentid : throw new ArgumentNullException("Copy must refer to a document!");
            PatronID = patronid; //> 0 ? patronid : throw new ArgumentNullException("Copy must refer to a document!");
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
