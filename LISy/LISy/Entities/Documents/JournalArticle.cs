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
        public long JournalId { get; set; }

        /// <summary>
        /// Initializes a new instance of article in journal.
        /// </summary>
        public JournalArticle() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of article in journal.
        /// </summary>
        /// <param name="authors">Authors of the article.</param>
        /// <param name="title">Title of the article.</param>
        /// <param name="keys">KeyWords using which the article can be found.</param>
        ///// <param name="journal">Journal in which the article is.</param>
        public JournalArticle(string authors, string title, string keys) : base(authors, title, keys, "")
        {
            //Journal = journal ?? throw new ArgumentNullException("Article must refer to a journal!");
        }

        /// <summary>
        /// Initializes a new instance of article in journal.
        /// </summary>
        /// <param name="id">Id of the article.</param>
        /// <param name="authors">Authors of the article.</param>
        /// <param name="title">Title of the article.</param>
        /// <param name="keys">KeyWords using which the article can be found.</param>
        ///// <param name="journal">Journal in which the article is.</param>
        public JournalArticle(long id, string authors, string title, string keys) : base(id, authors, title, keys, "")
        {
        }
    }
}
