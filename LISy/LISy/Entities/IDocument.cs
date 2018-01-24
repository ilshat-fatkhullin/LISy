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
        int Room { get; }
        int Level { get; }
        // Additional
        Image Picture { get; }

        void ChangePlace(int room, int level);

        void AddKeyword(string word);

        void RemoveKeyword(string word);

        void ChangeKeyword(string old, string newone);
    }
}
