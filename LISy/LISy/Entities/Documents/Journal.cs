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
            Publisher = publisher ?? throw new ArgumentNullException("Journal should have publisher!");
            Issue = issue ?? throw new ArgumentNullException("Journal should have issue!");
            Articles = art_amount > 0 ? new JournalArticle[art_amount] : throw new ArgumentException("Journal should contain articles!"); ;
            for (int i = 0; i < art_amount; ++i)
                Articles[i] = new JournalArticle(art_authors[i], art_titles[i], art_keys[i], this);
        }
    }
}
