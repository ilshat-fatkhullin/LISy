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
    public class User: IUser
    {   
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public long CardNumber { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public User(string firstName, string secondName, long cardNumber, string phone, string address)
        {
            FirstName = firstName;
            SecondName = secondName;
            CardNumber = cardNumber;
            Phone = phone;
            Address = address;
        }
    }
}
