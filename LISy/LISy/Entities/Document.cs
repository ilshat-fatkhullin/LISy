using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    /// <summary>
    /// Shouldn't be declared somewhere
    /// It is just an implementation of interface <code>IDocument</code>
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

        public Document(string[] authors, string title, string[] keys, int room, int level, string coverURL)
        {
            if (keys == null) throw new ArgumentNullException("Document should have keywords!");
            Authors = authors ?? throw new ArgumentNullException("Document should have authors!");
            Title = title ?? throw new ArgumentNullException("Document should have title!");
            Keywords = new List<string>(keys);
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
            CoverURL = coverURL;
        }

        #region SETTER_FUNCTIONS

        public void ChangePlace(int room, int level)
        {
            Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
            Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
        }

        public void AddKeyword(string word)
        {
            if (word == null) throw new ArgumentNullException("Invalid keyword!");
            if (Keywords.Contains(word)) return;
            Keywords.Add(word);
        }

        public void RemoveKeyword(string keyword)
        {
            if (keyword == null) throw new ArgumentNullException("Invalid keyword!");
            if (!Keywords.Contains(keyword)) throw new ArgumentException("Document has not such keyword!");
            Keywords.Remove(keyword);
        }

        public void ChangeKeyword(string keyword, string newKeyword)
        {
            RemoveKeyword(keyword);
            AddKeyword(newKeyword);
        }

        #endregion
    }
}
