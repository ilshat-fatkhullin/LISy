using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    /// <summary>
    /// Represents a book entity in the library.
    /// </summary>
    public class Book : Takable
    {
        public string Publisher { get; private set; }

        public string Edition { get; private set; }

        public int Year { get; private set; }

        public bool Bestseller { get; private set; }

        /// <summary>
        /// Initializes a new instance of a book.
        /// </summary>
        /// <param name="authors">Authors of the book.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="publisher">Publixher of the book.</param>
        /// <param name="edition">Edition of the book.</param>
        /// <param name="year">Year in with this edition was published.</param>
        /// <param name="bestseller">Is the book a bestseller or not.</param>
        /// <param name="keys">Keywords using which the book can be found.</param>
        /// <param name="image">Cover of the book.</param>
        /// <param name="price">Price of the book.</param>
        /// <param name="amount">Amount of copies of the book.</param>
        public Book(string[] authors, string title, string publisher, string edition, int year, bool bestseller, string[] keys, string image, int price, int amount) : base(authors, title, keys, image, price, amount)
        {
            Publisher = publisher ?? throw new ArgumentNullException("Book must have a publisher!");
            Edition = edition ?? throw new ArgumentNullException("Book must have an edition!");
            Year = year > 0 ? year : throw new ArgumentException("Invalid year!");
            Bestseller = bestseller;
        }

        /// <summary>
        /// Changes flag "Bestseller" of the book.
        /// </summary>
        /// <returns>true if the book is a bestseller, false otherwise.</returns>
        public bool ChangeBestseller()
        {
            Bestseller = !Bestseller;
            return Bestseller;
        }
    }
}
