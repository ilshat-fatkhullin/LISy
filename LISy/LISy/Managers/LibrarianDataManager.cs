using LISy.Entities;
using LISy.Entities.Documents;
using RestSharp;
using System;
using System.Collections.Generic;

namespace LISy.Managers
{
    /// <summary>
    /// Contains database commands for librarians
    /// </summary>
    public static class LibrarianDataManager
    {
        public static long AddArticle(Article article)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_article", article);
        }

        public static void EditArticle(Article article)
        {
            HttpHelper.MakePutRequest("librarian/edit_article", article);
        }

        public static long AddAVMaterial(AVMaterial avMaterial)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_av_material", avMaterial);
        }

        public static void EditAVMaterial(AVMaterial avMaterial)
        {
            HttpHelper.MakePutRequest("librarian/edit_av_material", avMaterial);
        }

        public static long AddBook(Book book)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_book", book);
        }

        public static void EditBook(Book book)
        {
            HttpHelper.MakePutRequest("librarian/edit_book", book);
        }

        public static long AddInnerMaterial(InnerMaterial innerMaterial)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_inner_material", innerMaterial);
        }

        public static void EditInnerMaterial(InnerMaterial innerMaterial)
        {
            HttpHelper.MakePutRequest("librarian/edit_inner_material", innerMaterial);
        }

        public static long AddJournal(Journal journal)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_journal", journal);
        }

        public static void EditJournal(Journal journal)
        {
            HttpHelper.MakePutRequest("librarian/edit_journal", journal);
        }

        public static void ReturnDocument(long documentId, long userId)
        {
            HttpHelper.MakePutRequest("librarian/return_document", new { documentId, userId });
        }
        
        public static bool AddUser(User user, string login, string password)
        {
            return HttpHelper.MakePostRequest<bool>("librarian/add_user", new { user, login, password });
        }
        
        public static void DeleteUser(User user)
        {
            HttpHelper.MakeDeleteRequest("librarian/add_user", user);
        }
        
        public static void EditUser(User newUser)
        {
            HttpHelper.MakePutRequest("librarian/edit_user", newUser);
        }
        
        public static void AddCopies(int n, Copy copy)
        {
            HttpHelper.MakePostRequest("librarian/add_copies", new { n, copy });
        }
        
        public static void DeleteCopy(Copy copy)
        {
            HttpHelper.MakeDeleteRequest("librarian/delete_copies", copy);
        }
        
        public static void DeleteCopyByDocId(Copy copy)
        {
            HttpHelper.MakeDeleteRequest("librarian/delete_copy_by_id", copy);
        }
        
        public static Copy[] GetAllCopiesList()
        {
            return HttpHelper.MakeGetRequest<List<Copy>>("librarian/get_all_copies", null).ToArray();  
        }
        
        public static void ClearAll()
        {
            HttpHelper.MakeDeleteRequest("librarian/clear_all", null);
        }
        
        public static Copy[] GetCheckedCopiesList()
        {
            return HttpHelper.MakeGetRequest<List<Copy>>("librarian/get_checked_copies", null).ToArray();
        }
        
        public static User[] GetAllUsersList()
        {
            return HttpHelper.MakeGetRequest<List<User>>("librarian/get_all_users", null).ToArray();
        }
        
        public static AVMaterial[] GetAllAVMaterialsList()
        {
            return HttpHelper.MakeGetRequest<List<AVMaterial>>("librarian/get_all_av_materials", null).ToArray();
        }
        
        public static Book[] GetAllBooksList()
        {
            return HttpHelper.MakeGetRequest<List<Book>>("librarian/get_all_books", null).ToArray();
        }
        
        public static int GetNumberOfDocuments()
        {
            return HttpHelper.MakeGetRequest<int>("librarian/get_documents_number", null);
        }
        
        public static int GetNumberOfUsers()
        {
            return HttpHelper.MakeGetRequest<int>("librarian/get_users_number", null);
        }
        
        public static int GetNumberOfCopies()
        {
            return HttpHelper.MakeGetRequest<int>("librarian/get_copies_number", null);
        }
        
        public static InnerMaterial[] GetAllInnerMaterialsList()
        {
            return HttpHelper.MakeGetRequest<List<InnerMaterial>>("librarian/get_all_inner_materials", null).ToArray();
        }
        
        public static Journal[] GetAllJournalsList()
        {
            return HttpHelper.MakeGetRequest<List<Journal>>("librarian/get_all_journals", null).ToArray();
        }
        public static Article[] GetAllArticlesList()
        {
            return HttpHelper.MakeGetRequest<List<Article>>("librarian/get_all_articles", null).ToArray();
        }
        
        public static User GetUserById(long userId)
        {
            return HttpHelper.MakeGetRequest<User>("librarian/get_user", new Tuple<string, string>[] {
                    new Tuple<string, string>("userId", Convert.ToString(userId))                    
                });
        }
        
        public static Copy[] GetCheckedByUserCopiesList(long userId)
        {
            return HttpHelper.MakeGetRequest<List<Copy>>("librarian/get_copies_checked_by_user",
                new Tuple<string, string>[] {
                    new Tuple<string, string>("userId", Convert.ToString(userId))                    
                }).ToArray();
        }        
        
        public static bool IsAvailable(long documentId, long patronId)
        {
            return HttpHelper.MakeGetRequest<bool>("librarian/is_available",
                new Tuple<string, string>[] {
                    new Tuple<string, string>("documentId", Convert.ToString(documentId)),
                    new Tuple<string, string>("patronId", Convert.ToString(patronId))
                });
        }

        public static void DeleteDocument(long id)
        {
            HttpHelper.MakeDeleteRequest("librarian/delete_document", new { id });
        }
    }
}
