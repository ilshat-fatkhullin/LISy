using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    interface IUser
    {
        string Name { get; set; }

        long CardNumber { get; set; }

        string Phone { get; set; }

        string Address { get; set; }
    }
}
