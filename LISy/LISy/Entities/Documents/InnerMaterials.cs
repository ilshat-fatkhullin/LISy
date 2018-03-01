using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    /// <summary>
    /// Represents a set of documents which cannot be checked out.
    /// </summary>
    class InnerMaterials : Document
    {
        public int Room { get; private set; }

        public int Level { get; private set; }

        public string Type { get; private set; }

        /// <summary>
        /// Initializes a new instance of library document which cannot be checked out.
        /// </summary>
        /// <param name="authors">Authors or editors of the document.</param>
        /// <param name="title">Title of the document.</param>
        /// <param name="type">Type of the document.</param>
        /// <param name="keys">Keywords using which the document can be found.</param>
        /// <param name="room">Room where the document is stored.</param>
        /// <param name="level">Level of the room of the document.</param>
        /// <param name="coverURL">Cover of the document.</param>
        public InnerMaterials(string authors, string title, string type, string keys, int room, int level, string coverURL) : base(authors, title, keys, coverURL)
        {
            Type = type ?? throw new ArgumentNullException("Ivalid type!");
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
        }

        /// <summary>
        /// Moves the document to new place in the library.
        /// </summary>
        /// <param name="room">Room where the document will be moved.</param>
        /// <param name="level">Level of new room of the document.</param>
        public void ChangePlace(int room, int level)
        {
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
        }
    }
}
