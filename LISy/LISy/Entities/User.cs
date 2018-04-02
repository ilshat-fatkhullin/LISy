using System;
using System.Linq;

namespace LISy.Entities
{
	/// <summary>
	/// Represents the implementation of common properties of library users.
	/// </summary>
	public class User
	{
		/// <summary>
		/// First name of a user.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Last name of a user.
		/// </summary>
		public string SecondName { get; set; }

		/// <summary>
		/// Id of a user.
		/// </summary>
		public long CardNumber { get; set; }

		/// <summary>
		/// Phone number of a user.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Address of a user.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Type of a user.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Initializes a new instance of library user.
		/// </summary>
		/// <param name="firstName">First name of the user.</param>
		/// <param name="secondName">Second name of the user.</param>
		/// <param name="phone">Phone number of the user.</param>
		/// <param name="address">Address of the user.</param>
		public User(string firstName, string secondName, string phone, string address)
		{
			FirstName = firstName ?? throw new ArgumentNullException("User must have a first name!");
			SecondName = secondName ?? throw new ArgumentNullException("User must have a second name!");
			Phone = phone ?? throw new ArgumentNullException("User must have a phone number!");
			Address = address ?? throw new ArgumentNullException("User must have an address!");
			Type = this.GetType().FullName.Split('.').Last();
		}

		/// <summary>
		/// Initializes a new instance of library user.
		/// </summary>
		public User()
		{

		}
	}
}
