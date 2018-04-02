namespace LISy.Entities.Users.Patrons
{
    /// <summary>
    /// Represents students of the university.
    /// </summary>
    public class Student : Patron
	{
		/// <summary>
		/// String Type.
		/// </summary>
		public const string TYPE = "Student";

		/// <summary>
		/// Queue priority.
		/// </summary>
		public const int PRIORITY = 1;

		/// <summary>
		/// Initializes a new instance of a student.
		/// </summary>
		/// <param name="firstName">First name of the student.</param>
		/// <param name="secondName">Second name of the student.</param>
		/// <param name="phone">Phone number of the student.</param>
		/// <param name="address">Address of the student.</param>
		public Student(string firstName, string secondName, string phone, string address) : base(firstName, secondName, phone, address)
		{
			Priority = PRIORITY;
		}
	}
}
