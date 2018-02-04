using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities
{
    /// <summary>
    /// Represents common properties of library documents.
    /// </summary>
    public interface IDocument
    {
        #region MAIN_INFO

        long ID { get; set; }

        string Title { get; }

        string[] Authors { get; }

        List<string> Keywords { get; }

        string CoverURL { get; }

        #endregion

        #region SETTER_FUNCTIONS

        void AddKeyword(string keyword);

        void RemoveKeyword(string keyword);

        void ChangeKeyword(string keyword, string newKeyword);

        #endregion
    }
}
