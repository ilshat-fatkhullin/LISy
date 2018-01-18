using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Users.Patrons
{
    public class Faculty: Patron
    {
        public Faculty(string name, long cardNumber, string phone, string address): base(name, cardNumber, phone, address)
        {

        }
    }
}
