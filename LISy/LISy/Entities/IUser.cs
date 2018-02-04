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
        string FirstName { get; }

        string SecondName { get; }

        long CardNumber { get; set; }

        string Phone { get; }

        string Address { get; }        
    }
}
