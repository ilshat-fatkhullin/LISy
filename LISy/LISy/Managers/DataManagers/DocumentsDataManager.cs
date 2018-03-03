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
            if (document == null) throw new ArgumentNullException("Invalid document!");
            var type = document.GetType();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                if (type == typeof(AVMaterial))
                {
                    AVMaterial temp = document as AVMaterial;
                    connection.Execute("dbo.spAudioVideos_AddAV @Title, @Authors, @KeyWords, @Price",
                        new
                        {
                            Title = temp.Title,
                            Authors = temp.Authors,
                            KeyWords = temp.KeyWords,
                            Price = temp.Price
                        });
                }
                else if (type == typeof(Book))
                {
                    Book temp = document as Book;
                    connection.Execute("dbo.spBooks_AddBook @Title, @Authors, @Publisher, @Edition, @Year, @IsBestseller, @KeyWords, @Price",
                        new
                        {
                            Title = temp.Title,
                            Authors = temp.Authors,
                            Publisher = temp.Publisher,
                            Edition = temp.Edition,
                            Year = temp.Year,
                            IsBestseller = temp.IsBestseller,
                            KeyWords = temp.KeyWords,
                            Price = temp.Price
                        });
                }
                else if (type == typeof(InnerMaterials))
                {
                    InnerMaterials temp = document as InnerMaterials;
                    connection.Execute("dbo.spInnerMaterials_AddInnerMaterial @Title, @Authors, @Type, @KeyWords",
                        new
                        {
                            Title = temp.Title,
                            Authors = temp.Authors,
                            KeyWords = temp.KeyWords,
                            Type = temp.Type
                        });
                }
                else if (type == typeof(Journal))
                {
                    Journal temp = document as Journal;
                    connection.Execute("dbo.spJournals_AddJournal @Title, @Editors, @Publisher, @Issue, @PublicationDate, @KeyWords, @Price",
                        new
                        {
                            Title = temp.Title,
                            Editors = temp.Authors,
                            Publisher = temp.Publisher,
                            Issue = temp.Issue,
                            PublicationDate = temp.PublicationDate,
                            KeyWords = temp.KeyWords,
                            Price = temp.Price
                        });
                }
                else if (type == typeof(JournalArticle))
                {
                    JournalArticle temp = document as JournalArticle;
                    connection.Execute("dbo.spJournalArticles_AddJournalArticle @Title, @Authors, @JournalId, @KeyWords",
                        new
                        {
                            Title = temp.Title,
                            Authors = temp.Authors,
                            KeyWords = temp.KeyWords,
                            JournalId = temp.JournalId
                        });
                }
            }
        }

        /// <summary>
        /// Deletes a document from the database.
        /// </summary>
        /// <param name="document">Document, which is going to be deleted.</param>
        public static void DeleteDocument(IDocument document)
        {
            if (document == null) throw new ArgumentNullException("Invalid document!");
            var type = document.GetType();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                connection.Execute("dbo.spDocuments_DeleteDocument @Id", new { Id = document.Id });
            }
        }

        /// <summary>
        /// Replaces <code>document</code> on <code>newDocument</code> in the database.
        /// </summary>
        /// <param name="newDocument">Document, which is going to be instead of <code>document</code>.</param>
        public static void EditDocument(IDocument newDocument)
        {
            if (newDocument == null) throw new ArgumentNullException("Invalid document!");
            var type = newDocument.GetType();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                if (type == typeof(AVMaterial))
                {
                    AVMaterial temp = newDocument as AVMaterial;
                    connection.Execute("dbo.spAudioVideos_ModifyAV @Id, @Title, @Authors, @KeyWords, @Price",
                        new
                        {
                            Id = temp.Id,
                            Title = temp.Title,
                            Authors = temp.Authors,
                            KeyWords = temp.KeyWords,
                            Price = temp.Price
                        });
                }
                else if (type == typeof(Book))
                {
                    Book temp = newDocument as Book;
                    connection.Execute("dbo.spBooks_ModifyBook @Id, @Title, @Authors, @Publisher, @Edition, @Year, @IsBestseller, @KeyWords, @Price",
                        new
                        {
                            Id = temp.Id,
                            Title = temp.Title,
                            Authors = temp.Authors,
                            Publisher = temp.Publisher,
                            Edition = temp.Edition,
                            Year = temp.Year,
                            IsBestseller = temp.IsBestseller,
                            KeyWords = temp.KeyWords,
                            Price = temp.Price
                        });
                }
                else if (type == typeof(InnerMaterials))
                {
                    InnerMaterials temp = newDocument as InnerMaterials;
                    connection.Execute("dbo.spInnerMaterials_ModifyInnerMaterial @Id, @Title, @Authors, @KeyWords",
                        new
                        {
                            Id = temp.Id,
                            Title = temp.Title,
                            Authors = temp.Authors,
                            KeyWords = temp.KeyWords,
                        });
                }
                else if (type == typeof(Journal))
                {
                    Journal temp = newDocument as Journal;
                    connection.Execute("dbo.spJournals_ModifyJournal @Id, @Title, @Editors, @Publisher, @Issue, @PublicationDate, @KeyWords, @Price",
                        new
                        {
                            Id = temp.Id,
                            Title = temp.Title,
                            Editors = temp.Authors,
                            Publisher = temp.Publisher,
                            Issue = temp.Issue,
                            PublicationDate = temp.PublicationDate,
                            KeyWords = temp.KeyWords,
                            Price = temp.Price
                        });
                }
                else if (type == typeof(JournalArticle))
                {
                    JournalArticle temp = newDocument as JournalArticle;
                    connection.Execute("dbo.spJournalArticles_ModifyJournalArticle @Id, @Title, @Authors, @KeyWords",
                        new
                        {
                            Id = temp.Id,
                            Title = temp.Title,
                            Authors = temp.Authors,
                            KeyWords = temp.KeyWords,
                        });
                }
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
                        documents[i] = new Book(outputDoc[i].Authors, outputDoc[i].Title, outputDoc[i].Publisher, outputDoc[i].Edition, outputDoc[i].Year, outputDoc[i].IsBestseller, "", "", outputDoc[i].Price);
                    var patronType = connection.Query<string>("dbo.spUsers_GetType @UserId", new { UserId = userId }).ToList();
                    date = documents[0].EvaluateReturnDate(patronType[0]);
                }
                else if (type == "AV")
                {
                    var outputDoc = connection.Query<TempAV>("dbo.spAudioVideos_GetAllById @DocumentId", new { DocumentId = documentId }).ToArray();
                    AVMaterial[] documents = new AVMaterial[outputDoc.Count()];
                    for (int i = 0; i < documents.GetLength(0); i++)
                        documents[i] = new AVMaterial(outputDoc[i].Authors, outputDoc[i].Title, "", "", outputDoc[i].Price);
                    var patronType = connection.Query<string>("dbo.spUsers_GetType @UserId", new { UserId = userId }).ToList();
                    date = documents[0].EvaluateReturnDate(patronType[0]);
                }
                else if (type == "Journal Article")
                {
                    var outputDoc = connection.Query<TempJournal>("dbo.spJournals_GetAllById @DocumentId", new { DocumentId = documentId }).ToArray();
                    Journal[] documents = new Journal[outputDoc.Count()];
                    for (int i = 0; i < documents.GetLength(0); i++)
                        documents[i] = new Journal(outputDoc[i].Editors, outputDoc[i].Title, outputDoc[i].Publisher, outputDoc[i].Issue, outputDoc[i].PublicationDate, "", "", outputDoc[i].Price);
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
        /// <param name="documentId">Id of document</param>
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
                var output = connection.Query<TempCopy>("dbo.spCopies_GetAll").ToArray();
                Copy[] copies = new Copy[output.Count()];
                for (int i = 0; i < copies.GetLength(0); i++)
                    copies[i] = new Copy(output[i].CopyId, output[i].BookId, output[i].UserId, output[i].Checked, output[i].ReturningDate, output[i].Room, output[i].Level);
                return copies;
            }
        }

        public static AVMaterial[] GetAllAVMaterialsList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<AVMaterial>("dbo.spAudioVideos_GetAll").ToArray();
                AVMaterial[] temp = new AVMaterial[output.Count()];
                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    temp[i] = new AVMaterial(output[i].Authors, output[i].Title, "", "", output[i].Price);
                    temp[i].Id = output[i].Id;
                }

                return temp;
            }
        }

        public static Book[] GetAllBooksList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<TempBook>("dbo.spBooks_GetAll").ToArray();
                Book[] books = new Book[output.Count()];
                for (int i = 0; i < books.GetLength(0); i++)
                {
                    books[i] = new Book(output[i].Authors, output[i].Title, output[i].Publisher, output[i].Edition, output[i].Year, output[i].IsBestseller, output[i].KeyWords, output[i].CoverURL, output[i].Price);
                    books[i].Id = output[i].Id;
                }

                return books;
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

        public string Edition { get; set; }

        public int Year { get; set; }

        public bool IsBestseller { get; set; }

        public int Price { get; set; }

        public string KeyWords { get; set; }

        public string CoverURL { get; set; }
    }

    class TempAV
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }

        public int Price { get; set; }
    }

    class TempJournal
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int Issue { get; set; }

        public string Editors { get; set; }

        public string PublicationDate { get; set; }

        public int Price { get; set; }
    }
}
