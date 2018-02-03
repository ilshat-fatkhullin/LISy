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
        public bool IsAMagazine { get; private set; }

        /// <summary>
        /// Initializes a new instance of library document which cannot be checked out.
        /// </summary>
        /// <param name="authors">Authors or editors of the document.</param>
        /// <param name="title">Title of the document.</param>
        /// <param name="magazine">Is the document a magazine or not.</param>
        /// <param name="keys">Keywords using which the document can be found.</param>
        /// <param name="room">Room where the document is stored.</param>
        /// <param name="level">Level of the room of the document.</param>
        /// <param name="coverURL">Cover of the document.</param>
        public InnerMaterials(string[] authors, string title, bool magazine, string[] keys, int room, int level, string coverURL) : base(authors, title, keys, room, level, coverURL)
        {
            IsAMagazine = magazine;
        }
    }
}
