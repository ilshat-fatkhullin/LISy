using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    /// <summary>
    /// Interface of "User" entity
    /// </summary>
    public interface IUser
    {
        string FirstName { get; set; }

        string SecondName { get; set; }

        long CardNumber { get; set; }

        string Phone { get; set; }

        string Address { get; set; }
    }
}
