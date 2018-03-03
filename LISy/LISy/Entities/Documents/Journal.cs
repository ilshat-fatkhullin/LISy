using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    /// <summary>
    /// Represents a journal entity in the library.
    /// </summary>
    public class Journal : Takable
    {
        public string Publisher { get; private set; }

        public int Issue { get; private set; }

        public string PublicationDate { get; private set; }

        //public JournalArticle[] Articles { get; private set; }

        /// <summary>
        /// Initializes a new instance of a journal.
        /// </summary>
        /// <param name="authors">Editors of the journal.</param>
        /// <param name="title">Title of the journal.</param>
        /// <param name="publisher">Publisher of the journal.</param>
        /// <param name="issue">Issue of the journal.</param>
        /// <param name="date">Publication date of the journal.</param>
        /// <param name="keys">Keywords using which the journal can be found.</param>
        /// <param name="image">Cover of the journal.</param>
        /// <param name="price">Price of the journal.</param>
        /*/// <param name="art_amount">Amount of articles in the journal.</param>
        /// <param name="art_authors">Authors of journal's atricles.</param>
        /// <param name="art_titles">Titles of journal's atricles.</param>
        /// <param name="art_keys">Keywords using which every journal's atricle can be found.</param>*/
        public Journal(string authors, string title, string publisher, int issue, string date, string keys, string image, int price/*,
            int art_amount, string[] art_authors, string[] art_titles, string[] art_keys*/) : base(authors, title, keys, image, price)
        {
            Publisher = publisher ?? throw new ArgumentNullException("Journal must have a publisher!");
            Issue = issue > 0 ? issue : throw new ArgumentNullException("Invalid issue!");
            PublicationDate = date ?? throw new ArgumentNullException("Journal must have a publication date!");
            /*Articles = art_amount > 0 ? new JournalArticle[art_amount] : throw new ArgumentException("Journal must contain articles!");
            if (art_authors == null) throw new ArgumentNullException("Articles must have authors!");
            if (art_titles == null) throw new ArgumentNullException("Articles must have titles!");
            if (art_keys == null) throw new ArgumentNullException("Articles must have keywords!");
            if (art_amount != art_authors.Length) throw new ArgumentException("Invalid amount of collections of articles' authors!");
            if (art_amount != art_titles.Length) throw new ArgumentException("Invalid amount of titles of articles!");
            if (art_amount != art_keys.Length) throw new ArgumentException("Invalid amount of collections of articles' keywords!");
            for (int i = 0; i < art_amount; ++i)
                Articles[i] = new JournalArticle(art_authors[i], art_titles[i], art_keys[i]);*/
        }
    }
}
