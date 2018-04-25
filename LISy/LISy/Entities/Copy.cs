using System;

namespace LISy.Entities
{
	/// <summary>
	/// Represents physical copies of documents.
	/// </summary>
	public class Copy
	{		
		/// <summary>
		/// Id of a copy.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Id of a document of which copy is.
		/// </summary>
		public long DocumentId { get; set; }

		/// <summary>
		/// Id of a patron who took copy.
		/// </summary>
		public long PatronId { get; set; }

		/// <summary>
		/// Denotes if copy is taken.
		/// </summary>
		public bool Checked { get; set; }

		/// <summary>
		/// Date when copy must be returned.
		/// </summary>
		public long ReturningDate { get; set; }

		/// <summary>
		/// Room where copy is placed.
		/// </summary>
		public int Room { get; set; }

		/// <summary>
		/// Level of copy room.
		/// </summary>
		public int Level { get; set; }

		/// <summary>
		/// Is copy renewed or not.
		/// </summary>
		public bool IsRenewed { get; set; }

		/// <summary>
		/// Initializes a new instance of Copy.
		/// </summary>
		public Copy()
		{

		}

		/// <summary>
		/// Initializes a new instance of Copy.
		/// </summary>
		/// <param name="id">Id of a copy.</param>
		/// <param name="documentid">Id of a document of which copy is.</param>
		/// <param name="patronid">Id of a patron who took copy.</param>
		/// <param name="check">Denotes if copy is taken</param>
		/// <param name="time">Date when copy must be returned.</param>
		/// <param name="room">Room where copy is placed.</param>
		/// <param name="level">Level of copy room.</param>
		public Copy(long id, long documentid, long patronid, bool check, long time, int room, int level)
		{
			Id = id >= 0 ? id : throw new ArgumentException("Invalid Id!");
			DocumentId = documentid >= 0 ? documentid : throw new ArgumentException("Invalid document Id!");
			PatronId = patronid; //>= 0 ? patronid : throw new ArgumentException("Invalid user Id!");
			Checked = check;
			ReturningDate = time; //?? throw new ArgumentNullException("Invalid returning time!");
			Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
			Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
		}

		/// <summary>
		/// Initializes a new instance of Copy.
		/// </summary>
		/// <param name="documentId">Id of a document of which copy is.</param>
		/// <param name="room">Room where copy is placed.</param>
		/// <param name="level">Level of copy room.</param>
		public Copy(long documentId, int room, int level)
		{
			DocumentId = documentId >= 0 ? documentId : throw new ArgumentException("Invalid document Id!");
			Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
			Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
		}

		/// <summary>
		/// Moves the copy to new place in the library.
		/// </summary>
		/// <param name="room">Room where the copy will be moved.</param>
		/// <param name="level">Level of new room of the copy.</param>
		public void ChangePlace(int room, int level)
		{
			Room = room > 0 ? room : throw new ArgumentException("Invalid room number!");
			Level = level > 0 ? level : throw new ArgumentException("Invalid level number!");
		}
	}
}
