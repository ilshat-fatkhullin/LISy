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
        // Main Info
        public string[] Authors { get; protected set; }
        public string Title { get; protected set; }
        public LinkedList<string> Keywords { get; protected set; }
        public int Room { get; protected set; }
        public int Level { get; protected set; }
        // Additional
        public Image Picture { get; protected set; }

        public Document(string[] authors, string title, string[] keys, int room, int level, Image image)
        {
            Authors = authors;
            Title = title;
            LinkedList<string> Keywords = new LinkedList<string>(keys);
            Room = room;
            Level = level;
            Picture = image;
        }

        public void ChangePlace(int room, int level)
        {
            if (room <= 0 || level <= 0) return;
            Room = room;
            Level = level;
        }

        public void AddKeyword(string word)
        {
            if (word == null || Keywords.Contains(word)) return;
            Keywords.AddLast(word);
        }

        public void RemoveKeyword(string word)
        {
            if (word == null) return;
            Keywords.Remove(word);
        }

        public void ChangeKeyword(string old, string newone)
        {
            RemoveKeyword(old);
            AddKeyword(newone);
        }
    }
}
