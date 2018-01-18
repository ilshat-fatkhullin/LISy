using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    public class Document
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Room { get; set; }

        public int Level { get; set; }

        public Document(string title, string author, int room, int level)
        {
            Title = title;
            Author = author;
            Room = room;
            Level = level;
        }
    }
}
