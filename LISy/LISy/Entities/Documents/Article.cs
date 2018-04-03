namespace LISy.Entities.Documents
{
    /// <summary>
    /// Represents a part of Journal.
    /// </summary>
    public class Article : Document
	{
		/// <summary>
		/// Id of a journal to which an article belongs.
		/// </summary>
		public long JournalId { get; set; }

		/// <summary>
		/// Initializes a new instance of article in journal.
		/// </summary>
		public Article() : base()
		{

		}

		/// <summary>
		/// Initializes a new instance of article in journal.
		/// </summary>
		/// <param name="authors">Authors of the article.</param>
		/// <param name="title">Title of the article.</param>
		/// <param name="keys">KeyWords using which the article can be found.</param>
		/// <param name="image">Cover of the article.</param>
		///// <param name="journal">Journal in which the article is.</param>
		public Article(string authors, string title, string keys, string image) : base(authors, title, keys, image)
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
		/// <param name="image">Cover of the article.</param>
		///// <param name="journal">Journal in which the article is.</param>
		public Article(long id, string authors, string title, string keys, string image) : base(id, authors, title, keys, image)
		{

		}
	}
}
