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
        public string[] Authors { get; protected set; }
        public string Title { get; protected set; }
        public LinkedList<string> Keywords { get; protected set; }
        public string Room { get; protected set; }
        public int Level { get; protected set; }
        // Additional
        public string Image { get; protected set; }

        public Document(string[] authors, string title, string[] keys)
        {
            Authors = authors;
            Title = title;
            for (int i = 0; i < keys.Length; ++i)
                Keywords.AddLast(keys[i]);
        }

        public void changePlace(string room, int level)
        {
            if (room == null || level <= 0) return;
            Room = room;
            Level = level;
        }

        public void addKeyword(string word)
        {
            if (word == null || Keywords.Find(word) != null) return;
            Keywords.AddLast(word);
        }

        public void removeKeyword(string word)
        {
            Keywords.Remove(word);
        }

        public void changeKeyword(string old, string newone)
        {
            removeKeyword(old);
            addKeyword(newone);
        }

        /*
        public void addCopy()
        {

        }

        public void addCopies(int n)
        {   
            // check n > 1
            for(int i = 1; i <= n; ++i) addCopy();
        }

        public void removeCopy()
        {
            // check if Copies.amount > 0. If yes, check if there are some untaken copies.
        }

        public void removeCopies(int n)
        {
            // check n > 1
            for (int i = 1; i <= n; ++i) removeCopy();
        }*/
    }
}
