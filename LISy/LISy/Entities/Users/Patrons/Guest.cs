using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Users.Patrons
{
	/// <summary>
	/// Represents visiting professors of the university.
	/// </summary>
	public class Guest : Patron
	{
		/// <summary>
		/// String Type.
		/// </summary>
		public const string TYPE = "Guest";

		/// <summary>
		/// Initializes a new instance of a visiting professor.
		/// </summary>
		/// <param name="firstName">First name of the visiting professor.</param>
		/// <param name="secondName">Second name of the visiting professor.</param>
		/// <param name="phone">Phone number of the visiting professor.</param>
		/// <param name="address">Address of the visiting professor.</param>
		public Guest(string firstName, string secondName, string phone, string address) : base(firstName, secondName, phone, address)
		{

		}
	}
}
