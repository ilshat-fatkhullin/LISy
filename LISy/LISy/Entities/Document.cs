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
    public class Document//: IDocument // I'm not sure if there are abstract classes in C#, but if yes, Documents should be such one.
    {
        private string[] Authors { get; } // we should discuss setters, getters, publicity.

        private string Title { get; }

        private int Price { get; }

        private string[] Keywords { get; }

        //private LinkedList<Copy> Copies { get; }

        public Document(string[] authors, string title, int price, string[] keys, int copy_amount)
        {
            Authors = authors;
            Title = title;
            Price = price;
            Keywords = keys;
        }

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
        }

        // Reserved, not mine. (c)Svyat

        /* public string Title { get; set; }

        public string Author { get; set; }

        public int Room { get; set; }

        public int Level { get; set; }

        public Document(string title, string author, int room, int level)
        {
            Title = title;
            Author = author;
            Room = room;
            Level = level;
        }*/
    }
}
