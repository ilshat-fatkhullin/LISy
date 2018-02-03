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
        /// Initializes a new instance of a teacher.
        /// </summary>
        /// <param name="firstName">First name of the teacher.</param>
        /// <param name="secondName">Second name of the teacher.</param>
        /// <param name="cardNumber">Card number of the teacher.</param>
        /// <param name="phone">Phone number of the teacher.</param>
        /// <param name="address">Address of the teacher.</param>
        public Faculty(string firstName, string secondName, long cardNumber, string phone, string address) : base(firstName, secondName, cardNumber, phone, address)
        {
            Type = "Faculty";
        }
    }
}
