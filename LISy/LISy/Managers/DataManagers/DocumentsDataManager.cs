using Dapper;
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using System;
using System.Data;
using System.Linq;
using System.Windows;

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
            var type = document.GetType();
            if (type == typeof(AVMaterial))
            {

            }
            else if (type == typeof(Book))
            {

            }
            else if (type == typeof(InnerMaterials))
            {

            }
            else if (type == typeof(Journal))
            {

            }
            else if (type == typeof(JournalArticle))
            {

            }
        }

        /// <summary>
        /// Deletes a document from the database.
        /// </summary>
        /// <param name="document">Document, which is going to be deleted.</param>
        public static void DeleteDocument(IDocument document)
        {
            var type = document.GetType();
            if (type == typeof(AVMaterial))
            {

            }
            else if (type == typeof(Book))
            {

            }
            else if (type == typeof(InnerMaterials))
            {

            }
            else if (type == typeof(Journal))
            {

            }
            else if (type == typeof(JournalArticle))
            {

            }
        }

        /// <summary>
        /// Replaces <code>document</code> on <code>newDocument</code> in the database.
        /// </summary>
        /// <param name="document">Document, which is going to be replaced.</param>
        /// <param name="newDocument">Document, which is going to be instead of <code>document</code>.</param>
        public static void EditDocument(IDocument document, IDocument newDocument)
        {
            var type = document.GetType();
            if (type != newDocument.GetType()) throw new ArgumentException("Types of documents are not the same!");
            if (type == typeof(AVMaterial))
            {

            }
            else if (type == typeof(Book))
            {

            }
            else if (type == typeof(InnerMaterials))
            {

            }
            else if (type == typeof(Journal))
            {

            }
            else if (type == typeof(JournalArticle))
            {

            }
        }

        public static void CheckOutDocument(long documentId, long userId)
        {
            if (!IsAvailable(documentId, userId))
                return;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                string date = "";
                string type = GetType(documentId);
                if (type == "Inner")
                {
                    return;
                }
                else if (type == "Book")
                {
                    var outputDoc = connection.Query<TempBook>("dbo.spBooks_GetAllById @DocumentId", new { DocumentId = documentId }).ToArray();
                    Book[] documents = new Book[outputDoc.Count()];
                    for (int i = 0; i < documents.GetLength(0); i++)
                        documents[i] = new Book(outputDoc[i].Authors, outputDoc[i].Title, outputDoc[i].Publisher, outputDoc[i].Edition.ToString(), outputDoc[i].Year, outputDoc[i].IsBestseller, "", "", 0, 0);
                    var patronType = connection.Query<string>("dbo.spUsers_GetType @UserId", new { UserId = userId }).ToList();
                    date = documents[0].EvaluateReturnDate(patronType[0]);
                }
                else if (type == "AV")
                {
                    var outputDoc = connection.Query<TempAV>("dbo.spAudioVideos_GetAllById @DocumentId", new { DocumentId = documentId }).ToArray();
                    AVMaterial[] documents = new AVMaterial[outputDoc.Count()];
                    for (int i = 0; i < documents.GetLength(0); i++)
                        documents[i] = new AVMaterial(outputDoc[i].Authors, outputDoc[i].Title, "", "", 0, 0);
                    var patronType = connection.Query<string>("dbo.spUsers_GetType @UserId", new { UserId = userId }).ToList();
                    date = documents[0].EvaluateReturnDate(patronType[0]);
                }
                else if (type == "Journal Article")
                {
                    var outputDoc = connection.Query<TempJournal>("dbo.spAudioVideos_GetAllById @DocumentId", new { DocumentId = documentId }).ToArray();
                    Journal[] documents = new Journal[outputDoc.Count()];
                    for (int i = 0; i < documents.GetLength(0); i++)
                        documents[i] = new Journal(outputDoc[i].Editors, outputDoc[i].Title, outputDoc[i].Publisher, outputDoc[i].Issue, outputDoc[i].PublicationDate, "", "", 0, 0);
                    var patronType = connection.Query<string>("dbo.spUsers_GetType @UserId", new { UserId = userId }).ToList();
                    date = documents[0].EvaluateReturnDate(patronType[0]);
                }

                var output = connection.Query<long>("dbo.spCopies_GetAvailableCopies @BookId, @UserId", new { BookId = documentId, UserId = userId }).ToList();
                connection.Execute("dbo.spCopies_takeCopyWithReturningDate @CopyId, @UserId, @ReturningDate", new { CopyId = output[0], UserId = userId, ReturningDate = date });
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

        /// <summary>
        /// Get type of document
        /// </summary>
        /// <param name="documentId">ID of document</param>
        /// <returns>String with type of document</returns>
        public static string GetType(long documentId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<string>("dbo.spDocuments_GetType @DocumentId", new { DocumentId = documentId }).ToList();
                return (output[0]);
            }
        }

        public static Copy[] GetAllCopiesList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {


                var output = connection.Query<TempCopy>("dbo.spCopies_GetAllCopies").ToArray();
                Copy[] copies = new Copy[output.Count()];
                for (int i = 0; i < copies.GetLength(0); i++)
                    copies[i] = new Copy(output[i].CopyId, output[i].BookId, output[i].UserId, output[i].Checked, output[i].ReturningDate, output[i].Room, output[i].Level);
                return copies;
            }
        }
    }

    class TempCopy
    {
        public int CopyId { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }

        public bool Checked { get; set; }

        public int Room { get; set; }

        public int Level { get; set; }

        public string ReturningDate { get; set; }
    }

    class TempBook
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }

        public string Publisher { get; set; }

        public int Edition { get; set; }

        public int Year { get; set; }

        public bool IsBestseller { get; set; }
    }

    class TempAV
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }
    }

    class TempJournal
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int Issue { get; set; }

        public string Editors { get; set; }

        public string PublicationDate { get; set; }
    }
}
