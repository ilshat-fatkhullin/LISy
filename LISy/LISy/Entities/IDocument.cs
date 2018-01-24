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
        #region MAIN_INFO

        string Title { get; }

        string[] Authors { get; }

        List<string> Keywords { get; }

        int Room { get; }

        int Level { get; }

        #endregion

        #region ADDITIONAL_INFO

        string CoverURL { get; }

        void ChangePlace(int room, int level);

        void AddKeyword(string keyword);

        void RemoveKeyword(string keyword);

        void ChangeKeyword(string keyword, string newKeyword);

        #endregion
    }
}
