using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    class InnerMaterials : Document
    {
        public bool IsAMagazine { get; private set; }

        public InnerMaterials(string[] authors, string title, bool magazine, string[] keys, int room, int level, string coverURL) : base(authors, title, keys, room, level, coverURL)
        {
            IsAMagazine = magazine;
        }
    }
}
