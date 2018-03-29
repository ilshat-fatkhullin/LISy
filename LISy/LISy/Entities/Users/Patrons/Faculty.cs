using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Users.Patrons
{
	/// <summary>
	/// Represents teachers of the university.
	/// </summary>
	public class Faculty : Patron
	{
		/// <summary>
		/// String Type.
		/// </summary>
		public const string TYPE = "Faculty";

		/// <summary>
		/// Subtype.
		/// </summary>
		public const string INSTRUCTOR_SUBTYPE = "Instructor";

		/// <summary>
		/// Subtype.
		/// </summary>
		public const string TA_SUBTYPE = "TA";

		/// <summary>
		/// Subtype.
		/// </summary>
		public const string PROFESSOR_SUBTYPE = "Professor";

		/// <summary>
		/// Queue priority of instructors.
		/// </summary>
		public const int INSTRUCTOR_PRIORITY = 2;

		/// <summary>
		/// Queue priority of TA's.
		/// </summary>
		public const int TA_PRIORITY = 3;

		/// <summary>
		/// Queue priority of professors.
		/// </summary>
		public const int PROFESSOR_PRIORITY = 5;

		/// <summary>
		/// Initializes a new instance of a teacher.
		/// </summary>
		/// <param name="firstName">First name of the teacher.</param>
		/// <param name="secondName">Second name of the teacher.</param>
		/// <param name="phone">Phone number of the teacher.</param>
		/// <param name="address">Address of the teacher.</param>
		/// <param name="subtype">Type of the teacher.</param>
		public Faculty(string firstName, string secondName, string phone, string address, string subtype) : base(firstName, secondName, phone, address)
		{
			if (subtype.Equals(INSTRUCTOR_SUBTYPE)) Priority = INSTRUCTOR_PRIORITY;
			else if (subtype.Equals(TA_SUBTYPE)) Priority = TA_PRIORITY;
			else if (subtype.Equals(PROFESSOR_SUBTYPE)) Priority = PROFESSOR_PRIORITY;
			//else throw new ArgumentException("Invalid faculty type.");
		}
	}
}
