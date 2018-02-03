using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{

    public abstract class User : IUser
    {
        public string FirstName { get; protected set; }

        public string SecondName { get; protected set; }

        public long CardNumber { get; protected set; }

        public string Phone { get; protected set; }

        public string Address { get; protected set; }

        public User(string firstName, string secondName, long cardNumber, string phone, string address)
        {
            FirstName = firstName ?? throw new ArgumentNullException("User must have a first name!");
            SecondName = secondName ?? throw new ArgumentNullException("User must have a second name!");
            CardNumber = cardNumber >= 0 ? cardNumber : throw new ArgumentException("Invalid card number!");
            Phone = phone ?? throw new ArgumentNullException("User must have a phone number!");
            Address = address ?? throw new ArgumentNullException("User must have an address!");
        }
    }
}
