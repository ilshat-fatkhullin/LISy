using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    /// <summary>
    /// Represents the implementatin of common properties of library documents.
    /// </summary>
    public abstract class Document : IDocument
    {
        #region MAIN_INFO

        public string[] Authors { get; protected set; }

        public string Title { get; protected set; }

        public List<string> Keywords { get; protected set; }

        public int Room { get; protected set; }

        public int Level { get; protected set; }

        #endregion

        #region ADDITIONAL

        public string CoverURL { get; protected set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of library document with common properties.
        /// </summary>
        /// <param name="authors">Authors or editors of the document.</param>
        /// <param name="title">Title of the document.</param>
        /// <param name="keys">Keywords using which the document can be found.</param>
        /// <param name="room">Room where the document is stored.</param>
        /// <param name="level">Level of the room of the document.</param>
        /// <param name="coverURL">Cover of the document.</param>
        public Document(string[] authors, string title, string[] keys, int room, int level, string coverURL)
        {
            if (keys == null) throw new ArgumentNullException("Document must have keywords!");
            Authors = authors ?? throw new ArgumentNullException("Document must have authors!");
            Title = title ?? throw new ArgumentNullException("Document must have a title!");
            Keywords = new List<string>(keys);
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
            CoverURL = coverURL;
        }

        #region SETTER_FUNCTIONS

        /// <summary>
        /// Moves the document to new place in the library.
        /// </summary>
        /// <param name="room">Room where the document will be moved.</param>
        /// <param name="level">Level of new room of the document.</param>
        public virtual void ChangePlace(int room, int level)
        {
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
        }

        /// <summary>
        /// Adds a keyword to the list of document's keywords.
        /// </summary>
        /// <param name="word">Keyword that will be added.</param>
        public void AddKeyword(string word)
        {
            if (word == null) throw new ArgumentNullException("Invalid keyword!");
            if (Keywords.Contains(word)) return;
            Keywords.Add(word);
        }

        /// <summary>
        /// Removes a keyword from the list of document's keywords.
        /// </summary>
        /// <param name="keyword">Keyword that will be removed.</param>
        public void RemoveKeyword(string keyword)
        {
            if (keyword == null) throw new ArgumentNullException("Invalid keyword!");
            if (!Keywords.Contains(keyword)) throw new ArgumentException("Document has not such keyword!");
            Keywords.Remove(keyword);
        }

        /// <summary>
        /// Changes a keyword to new one in the list of document's keywords.
        /// </summary>
        /// <param name="oldkeyword">Keyword that will be changed by new one.</param>
        /// <param name="newkeyword">Kayword that will replace old one.</param>
        public void ChangeKeyword(string oldkeyword, string newkeyword)
        {
            RemoveKeyword(oldkeyword);
            AddKeyword(newkeyword);
        }

        #endregion
    }
}
