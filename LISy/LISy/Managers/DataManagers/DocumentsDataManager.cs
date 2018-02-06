using Dapper;
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using System;
using System.Data;
using System.Linq;

namespace LISy.Managers.DataManagers
{
    /// <summary>
    /// Contains database commands for documents
    /// </summary>
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

        private static string EvaluateReturnData(Takable document, IPatron patron)
        {
            DateTime date = DateTime.Today;
            if (document.GetType() == typeof(Book))
            {
                if (patron.GetType() == typeof(Faculty)) date = date.AddDays(28);
                else if (!(document as Book).Bestseller) date = date.AddDays(21);
            }
            else date = date.AddDays(14);
            return date.ToShortDateString();
        }

        public static void CheckOutDocument(long documentId, long userId)
        {
            if (!IsAvailable(documentId, userId))
                return;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<long>("dbo.spCopies_GetAvailableCopies @BookId, @UserId", new { BookId = documentId, UserId = userId }).ToList();
                connection.Execute("dbo.spCopies_takeCopy @CopyId, @UserId", new { CopyId = output[0], UserId = userId });
            }
        }

        public static void ReturnDocument(long documentId, long userId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Execute("dbo.spCopies_ReturnDocument @DocumentId, @UserId", new { DocumentId = documentId, UserId = userId });
            }
        }

        /// <summary>
        /// Determines whether the copy is checked out by some Patron.
        /// </summary>
        /// <returns>true if copy is not checked out, false otherwise.</returns>
        public static bool IsAvailable(long documentID, long userID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<long>("dbo.spCopies_GetAvailableCopies @BookId, @UserId", new { BookId = documentID, UserId = userID }).ToList();
                return (output.Count != 0);
            }
        }

        public static Copy[] GetAllCopiesList()
        {
            throw new NotImplementedException();
        }
    }
}
