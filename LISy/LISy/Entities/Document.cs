using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
	/// <summary>
	/// Represents the implementatin of common properties of library documents.
	/// </summary>
	public abstract class Document : IDocument
	{
		#region MAIN_INFO

		/// <summary>
		/// Id of a document.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Authors of a document.
		/// </summary>
		public string Authors { get; set; }

		/// <summary>
		/// Title of a document.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Keywords of a document.
		/// </summary>
		public string KeyWords { get; set; }

		/// <summary>
		/// Cover of a document.
		/// </summary>
		public string CoverURL { get; set; }

		#endregion

		/// <summary>
		/// Initializes a new instance of library document with common properties.
		/// </summary>
		public Document()
		{

		}

		/// <summary>
		/// Initializes a new instance of library document with common properties.
		/// </summary>
		/// <param name="authors">Authors or editors of the document.</param>
		/// <param name="title">Title of the document.</param>
		/// <param name="keys">KeyWords using which the document can be found.</param>
		/// <param name="coverURL">Cover of the document.</param>
		public Document(string authors, string title, string keys, string coverURL)
		{
			Authors = authors ?? throw new ArgumentNullException("Document must have authors!");
			Title = title ?? throw new ArgumentNullException("Document must have a title!");
			KeyWords = keys ?? throw new ArgumentNullException("Document must have a title!");
			CoverURL = coverURL ?? throw new ArgumentNullException("Document must have a cover!");
		}

		/// <summary>
		/// Initializes a new instance of library document with common properties.
		/// </summary>
		/// <param name="id">Id of the document.</param>
		/// <param name="authors">Authors or editors of the document.</param>
		/// <param name="title">Title of the document.</param>
		/// <param name="keys">KeyWords using which the document can be found.</param>
		/// <param name="coverURL">Cover of the document.</param>
		public Document(long id, string authors, string title, string keys, string coverURL)
		{
			Id = id >= 0 ? id : throw new ArgumentException("Invalid Id!");
			Authors = authors ?? throw new ArgumentNullException("Document must have authors!");
			Title = title ?? throw new ArgumentNullException("Document must have a title!");
			KeyWords = keys ?? throw new ArgumentNullException("Document must have a title!");
			CoverURL = coverURL ?? throw new ArgumentNullException("Document must have a cover!");
		}

		/*#region SETTER_FUNCTIONS

        /// <summary>
        /// Adds a keyword to the list of document's keywords.
        /// </summary>
        /// <param name="word">Keyword that will be added.</param>
        public void AddKeyword(string word)
        {
            if (word == null) throw new ArgumentNullException("Invalid keyword!");
            if (KeyWords.Contains(word)) return;
            KeyWords.Add(word);
        }

        /// <summary>
        /// Removes a keyword from the list of document's keywords.
        /// </summary>
        /// <param name="keyword">Keyword that will be removed.</param>
        public void RemoveKeyword(string keyword)
        {
            if (keyword == null) throw new ArgumentNullException("Invalid keyword!");
            if (!KeyWords.Contains(keyword)) throw new ArgumentException("Document has not such keyword!");
            KeyWords.Remove(keyword);
        }

        /// <summary>
        /// Changes a keyword to new one in the list of document's keywords.
        /// </summary>
        /// <param name="oldkeyword">Keyword that will be changed by new one.</param>
        /// <param name="newkeyword">Kayword that will replace old one.</param>
        public void ChangeKeyword(string oldkeyword, string newkeyword)
        {
            RemoveKeyword(oldkeyword);
            AddKeyword(newkeyword);
        }

        #endregion*/
	}
}
