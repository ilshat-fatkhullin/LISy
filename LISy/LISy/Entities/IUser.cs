using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{

    public interface IUser
    {
        string FirstName { get; }

        string SecondName { get; }

        long CardNumber { get; }

        string Phone { get; }

        string Address { get; }
    }
}
