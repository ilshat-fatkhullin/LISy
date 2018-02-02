using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    /// <summary>
    /// Shouldn't be declared somewhere
    /// It is just an implementation of interface <code>IUser</code>
    /// </summary>
<<<<<<< HEAD
    public class User: IUser
    {   
        public string FirstName { get; set; }

        public string SecondName { get; set; }
=======
    public abstract class User: IUser
    {
        public string Name { get; set; }
>>>>>>> origin/master

        public long CardNumber { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public User(string firstName, string secondName, long cardNumber, string phone, string address)
        {
<<<<<<< HEAD
            FirstName = firstName;
            SecondName = secondName;
            CardNumber = cardNumber;
            Phone = phone;
            Address = address;
=======
            Name = name ?? throw new ArgumentNullException("User must have a name!");
            CardNumber = cardNumber >= 0 ? cardNumber : throw new ArgumentException("Invalid card number!");
            Phone = phone ?? throw new ArgumentNullException("User must have a phone number!");
            Address = address ?? throw new ArgumentNullException("User must have an address!");
>>>>>>> origin/master
        }
    }
}
