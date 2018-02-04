using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    /// <summary>
    /// Represents a part of Journal.
    /// </summary>
    public class JournalArticle : Document
    {
        public Journal Journal { get; private set; }

        /// <summary>
        /// Initializes a new instance of article in journal.
        /// </summary>
        /// <param name="authors">Authors  of the article.</param>
        /// <param name="title">Title of the article.</param>
        /// <param name="keys">Keywords using which the article can be found.</param>
        /// <param name="journal">Journal in which the article is.</param>
        public JournalArticle(string[] authors, string title, string[] keys, Journal journal) : base(authors, title, keys, null)
        {
            Journal = journal ?? throw new ArgumentNullException("Article must refer to a journal!");
        }
    }
}
