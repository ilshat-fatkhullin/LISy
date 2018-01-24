using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    public class JournalArticle : Document
    {
        public Journal Journal { get; private set; }

        public JournalArticle(string[] authors, string title, string[] keys, Journal journal) : base(authors, title, keys, journal.Room, journal.Level, null)
        {
            Journal = journal;
        }
    }
}
