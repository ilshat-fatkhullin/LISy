using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Users.Patrons
{
    public class Faculty: Patron
    {
        public Faculty(string firstName, string secondName, long cardNumber, string phone, string address): base(firstName, secondName, cardNumber, phone, address)
        {
            Type = "Faculty";
        }
    }
}
