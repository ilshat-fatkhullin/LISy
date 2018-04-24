using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities.Users.Patrons;

namespace LISy.Entities.Documents
{
	/// <summary>
	/// Describes properties of a set of documents that can be checked out.
	/// </summary>
	public class Takable : Document
	{
		/// <summary>
		/// Amount of days a non-guest patron can hold document.
		/// </summary>
		public const int BASIC_RETURN_TIME = 14;

		/// <summary>
		/// Amount of days a guest patron can hold document.
		/// </summary>
		public const int GUEST_RETURN_TIME = 7;

		/// <summary>
		/// Price of a document.
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// Is document outstanding or not
		/// </summary>
		public bool IsOutstanding { get; set; }

		/// <summary>
		/// Initializes a new instance of library document that can be checked out.
		/// </summary>
		public Takable() : base()
		{

		}

		/// <summary>
		/// Initializes a new instance of library document that can be checked out.
		/// </summary>
		/// <param name="authors">Authors or editors of the document.</param>
		/// <param name="title">Title of the document.</param>
		/// <param name="keys">KeyWords using which the document can be found.</param>
		/// <param name="image">Cover of the document.</param>
		/// <param name="price">Price of the document.</param>
		public Takable(string authors, string title, string keys, string image, int price) : base(authors, title, keys, image)
		{
			Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative!");
			/*Copies = new List<Copy>();
            for (int i = 1; i <= amount; ++i)
                Copies.Add(new Copy(this));
            LastAvailableCopy = Copies[0];*/
		}

		/// <summary>
		/// Initializes a new instance of library document that can be checked out.
		/// </summary>
		/// <param name="id">Id or editors of the document.</param>
		/// <param name="authors">Authors or editors of the document.</param>
		/// <param name="title">Title of the document.</param>
		/// <param name="keys">KeyWords using which the document can be found.</param>
		/// <param name="image">Cover of the document.</param>
		/// <param name="price">Price of the document.</param>
		public Takable(long id, string authors, string title, string keys, string image, int price) : base(id, authors, title, keys, image)
		{
			Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative!");
		}

		/// <summary>
		/// Evaluates return date of a document.
		/// </summary>
		/// <param name="patronType">Type of booking patron.</param>
		/// <returns></returns>
		public virtual long EvaluateReturnDate(string patronType)
		{
			DateTime date = DateTime.Today;
			if (patronType.Equals(Guest.TYPE))
			{
				date = date.AddDays(GUEST_RETURN_TIME);
			}
			else
			{
				date = date.AddDays(BASIC_RETURN_TIME);
			}
			return date.ToFileTimeUtc();
		}
	}
}
