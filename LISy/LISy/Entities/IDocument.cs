using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    interface IDocument
    {
        string Title { get; set; }

        string Author { get; set; }

        int Room { get; set; }

        int Level { get; set; }
    }
}
