using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    /// <summary>
    /// Represents common properties of library users.
    /// </summary>
    public interface IUser
    {
        long CardNumber { get; set; }

        string FirstName { get; }

        string SecondName { get; }

        string Phone { get; }

        string Address { get; }

        string Type { get; }
    }
}
