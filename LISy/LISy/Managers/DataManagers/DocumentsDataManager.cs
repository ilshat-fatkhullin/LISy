using LISy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers.DataManagers
{
    public class DocumentsDataManager
    {

        public DocumentsDataManager()
        {

        }

        /// <summary>
        /// Adds new document to the database.
        /// </summary>
        /// <param name="document">Document, which is going to be added.</param>
        public void AddDocument(IDocument document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a document from the database.
        /// </summary>
        /// <param name="document">Document, which is going to be deleted.</param>
        public void DeleteDocument(IDocument document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replaces <code>document</code> on <code>newDocument</code> in the database.
        /// </summary>
        /// <param name="document">Document, which is going to be replaced.</param>
        /// <param name="newDocument">Document, which is going to be instead of <code>document</code>.</param>
        public void EditDocument(IDocument document, IDocument newDocument)
        {
            throw new NotImplementedException();
        }
    }
}
