﻿using LISy.Entities.Users.Patrons;
using System;

namespace LISy.Entities.Documents
{
    /// <summary>
    /// Represents a Book entity in the library.
    /// </summary>
    public class Book : Takable
	{
        public const int FACULTY_RETURN_TIME = 28;

        public const int STUDENT_BESTSELLER_RETURN_TIME = 14;

        public const int STUDENT_RETURN_TIME = 21;

        public string Publisher { get; set; }

		public string Edition { get; set; }

		public int Year { get; set; }

		public bool IsBestseller { get; set; }

		/// <summary>
		/// Initializes a new instance of a Book.
		/// </summary>
		public Book() : base()
		{

		}

		/// <summary>
		/// Initializes a new instance of a Book.
		/// </summary>
		/// <param name="authors">Authors of the Book.</param>
		/// <param name="title">Title of the Book.</param>
		/// <param name="publisher">Publixher of the Book.</param>
		/// <param name="edition">Edition of the Book.</param>
		/// <param name="year">Year in with this edition was published.</param>
		/// <param name="bestseller">Is the Book a bestseller or not.</param>
		/// <param name="keys">KeyWords using which the Book can be found.</param>
		/// <param name="image">Cover of the Book.</param>
		/// <param name="price">Price of the Book.</param>
		public Book(string authors, string title, string publisher, string edition, int year, bool bestseller, string keys, string image, int price) : base(authors, title, keys, image, price)
		{
			Publisher = publisher ?? throw new ArgumentNullException("Book must have a publisher!");
			Edition = edition ?? throw new ArgumentNullException("Book must have an edition!");
			Year = year > 0 ? year : throw new ArgumentException("Invalid year!");
			IsBestseller = bestseller;
		}

		/// <summary>
		/// Initializes a new instance of a Book.
		/// </summary>
		/// <param name="id">Id of the Book.</param>
		/// <param name="authors">Authors of the Book.</param>
		/// <param name="title">Title of the Book.</param>
		/// <param name="publisher">Publixher of the Book.</param>
		/// <param name="edition">Edition of the Book.</param>
		/// <param name="year">Year in with this edition was published.</param>
		/// <param name="bestseller">Is the Book a bestseller or not.</param>
		/// <param name="keys">KeyWords using which the Book can be found.</param>
		/// <param name="image">Cover of the Book.</param>
		/// <param name="price">Price of the Book.</param>
		public Book(long id, string authors, string title, string publisher, string edition, int year, bool bestseller, string keys, string image, int price) : base(id, authors, title, keys, image, price)
		{
			Publisher = publisher ?? throw new ArgumentNullException("Book must have a publisher!");
			Edition = edition ?? throw new ArgumentNullException("Book must have an edition!");
			Year = year > 0 ? year : throw new ArgumentException("Invalid year!");
			IsBestseller = bestseller;
		}

		/// <summary>
		/// Changes flag "Bestseller" of the Book.
		/// </summary>
		/// <returns>true if the Book is a bestseller, false otherwise.</returns>
		public bool ChangeBestseller()
		{
			IsBestseller = !IsBestseller;
			return IsBestseller;
		}

        public override string EvaluateReturnDate(string patronType)
        {
            DateTime date = DateTime.Today;
            if (patronType.Equals(Guest.TYPE))
            {
                date = date.AddDays(GUEST_RETURN_TIME);
            }
            else if (patronType.Equals(Faculty.TYPE))
            {
                date = date.AddDays(FACULTY_RETURN_TIME);
            }
            else if (IsBestseller)
            {
                date = date.AddDays(STUDENT_BESTSELLER_RETURN_TIME);
            }
            else
            {
                date = date.AddDays(STUDENT_RETURN_TIME);
            }
            return date.ToShortDateString();
        }
    }
}
