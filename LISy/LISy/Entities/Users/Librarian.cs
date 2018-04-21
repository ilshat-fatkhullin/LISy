namespace LISy.Entities.Users
{
    /// <summary>
    /// Represents library workers.
    /// </summary>
    public class Librarian : User
    {
        /// <summary>
        /// String Type.
        /// </summary>
        public const string TYPE = "Librarian";

        /// <summary>
        /// Previlegues of the librarian
        /// </summary>
        public int Authority { get; set; }

        /// <summary>
        /// Initializes a new instance of library worker.
        /// </summary>
        /// <param name="firstName">First name of the worker.</param>
        /// <param name="secondName">Second name of the worker.</param>
        /// <param name="phone">Phone number of the worker.</param>
        /// <param name="address">Address of the worker.</param>
        /// <param name="authority">Privilegues of the worker..</param>
        public Librarian(string firstName, string secondName, string phone, string address, int authority) : base(firstName, secondName, phone, address)
		{
            Authority = authority;
		}
	}
}
