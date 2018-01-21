using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    /// <summary>
    /// Interface of "Document" entity
    /// </summary>
    public interface IDocument
    {
        string Title { get; set; }

        string Author { get; set; }

        int Room { get; set; }

        int Level { get; set; }
    }
}
