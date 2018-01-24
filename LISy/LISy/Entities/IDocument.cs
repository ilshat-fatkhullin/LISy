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
        // Main info
        string Title { get; }
        string[] Authors { get; }
        LinkedList<string> Keywords { get; }
        string Room { get; }
        int Level { get; }
        // Additional
        string Image { get; }

        void changePlace(string room, int level);

        void addKeyword(string word);

        void removeKeyword(string word);

        void changeKeyword(string old, string newone);
    }
}
