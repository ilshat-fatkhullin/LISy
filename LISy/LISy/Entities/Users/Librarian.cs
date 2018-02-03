using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Users
{
    /// <summary>
    /// Represents library workers.
    /// </summary>
    public class Librarian : User, ILibrarian
    {

        /// <summary>
        /// Initializes a new instance of library worker.
        /// </summary>
        /// <param name="firstName">First name of the worker.</param>
        /// <param name="secondName">Second name of the worker.</param>
        /// <param name="cardNumber">Card number of the worker.</param>
        /// <param name="phone">Phone number of the worker.</param>
        /// <param name="address">Address of the worker.</param>
        public Librarian(string firstName, string secondName, long cardNumber, string phone, string address) : base(firstName, secondName, cardNumber, phone, address)
        {
<<<<<<< HEAD
            Type = "Librarian";
=======

>>>>>>> 1d1e82005e3385d129df80e12d13861de0bd7293
        }
    }
}
