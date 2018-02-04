using Dapper;
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using System;
using System.Data;

namespace LISy.Managers.DataManagers
{
    static class DocumentsDataManager
    {
        /// <summary>
        /// Adds new document to the database.
        /// </summary>
        /// <param name="document">Document, which is going to be added.</param>
        public static void AddDocument(IDocument document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a document from the database.
        /// </summary>
        /// <param name="document">Document, which is going to be deleted.</param>
        public static void DeleteDocument(IDocument document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replaces <code>document</code> on <code>newDocument</code> in the database.
        /// </summary>
        /// <param name="document">Document, which is going to be replaced.</param>
        /// <param name="newDocument">Document, which is going to be instead of <code>document</code>.</param>
        public static void EditDocument(IDocument document, IDocument newDocument)
        {
            throw new NotImplementedException();
        }

        public static Copy CheckOutDocument(Takable document, IPatron patron)
        {
            Copy copy = new Copy(document);

            if (copy.IsAvailable())
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
                {
                    connection.Query<long>("dbo.", patron);
                }
            }

            return copy;
        }
    }
}
