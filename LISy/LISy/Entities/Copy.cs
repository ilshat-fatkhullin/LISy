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
        public long ID { get; private set; }

        public long DocumentID { get; private set; }

        public long PatronID { get; private set; }

        public bool Checked { get; private set; }

        public string ReturningTime { get; private set; }

        public int Room { get; private set; }

        public int Level { get; private set; }

        public Copy()
        {
        }

        public Copy(long id, long documentid, long patronid, bool check, string time, int room, int level)
        {
            ID = id >= 0 ? id : throw new ArgumentException("Invalid ID!");
            DocumentID = documentid >= 0 ? documentid : throw new ArgumentException("Invalid document ID!");
            PatronID = patronid; //>= 0 ? patronid : throw new ArgumentException("Invalid user ID!");
            Checked = check;
            ReturningTime = time ?? throw new ArgumentNullException("Invalid returning time!");
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
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
