using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    public class Journal : Takable
    {
        public string Publisher { get; private set; }
        public string Issue { get; private set; }
        public JournalArticle[] Articles { get; private set; }

        public Journal(string[] authors, string title, string publisher, string issue, string[] keys, int room, int level, string image, int price, int amount,
            int art_amount, string[][] art_authors, string[] art_titles, string[][] art_keys) : base(authors, title, keys, room, level, image, price, amount)
        {
            Publisher = publisher ?? throw new ArgumentNullException("Journal must have a publisher!");
            Issue = issue ?? throw new ArgumentNullException("Journal must have an issue!");
            Articles = art_amount > 0 ? new JournalArticle[art_amount] : throw new ArgumentException("Journal must contain articles!");
            if (art_authors == null) throw new ArgumentNullException("Articles must have authors!");
            if (art_titles == null) throw new ArgumentNullException("Articles must have titles!");
            if (art_keys == null) throw new ArgumentNullException("Articles must have keywords!");
            if (art_amount != art_authors.Length) throw new ArgumentException("Invalid amount of collections of articles' authors!");
            if (art_amount != art_titles.Length) throw new ArgumentException("Invalid amount of titles of articles!");
            if (art_amount != art_keys.Length) throw new ArgumentException("Invalid amount of collections of articles' keywords!");
            for (int i = 0; i < art_amount; ++i)
                Articles[i] = new JournalArticle(art_authors[i], art_titles[i], art_keys[i], this);
        }
    }
}
