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

        public string[] Authors { get; private set; }

        public string Title { get; private set; }

        public List<string> Keywords { get; private set; }

        public int Room { get; private set; }

        public int Level { get; private set; }

        #endregion

        #region ADDITIONAL

        public string CoverURL { get; private set; }

        #endregion

        public Document(string[] authors, string title, string[] keys, int room, int level, string coverURL)
        {
            Authors = authors;
            Title = title;

            foreach (string key in keys)
                Keywords.Add(key);

            Room = room;
            Level = level;
            CoverURL = coverURL;
        }

        public void ChangePlace(int room, int level)
        {
            if (room <= 0 || level <= 0)
            {
                throw new ArgumentException();
            }
            Room = room;
            Level = level;
        }

        public void AddKeyword(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException();
            }
            if (Keywords.Contains(word))
                return;
            Keywords.Add(word);
        }

        public void RemoveKeyword(string keyword)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException();
            }
            if (!Keywords.Contains(keyword))
            {
                throw new ArgumentException();
            }
            Keywords.Remove(keyword);
        }

        public void ChangeKeyword(string keyword, string newKeyword)
        {
            RemoveKeyword(keyword);
            AddKeyword(newKeyword);
        }
    }
}
