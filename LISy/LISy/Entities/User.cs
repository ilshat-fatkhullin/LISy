using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    public class User: IUser
    {
        public string Name { get; set; }

        public long CardNumber { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public User(string name, long cardNumber, string phone, string address)
        {
            Name = name;
            CardNumber = cardNumber;
            Phone = phone;
            Address = address;
        }
    }
}
