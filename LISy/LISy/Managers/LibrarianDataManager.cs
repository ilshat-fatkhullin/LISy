using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
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

        public static long AddAVMaterial(AVMaterial avMaterial)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_av_material", avMaterial);
        }

        public static long AddBook(Book book)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_book", book);
        }

        public static long AddInnerMaterial(InnerMaterial innerMaterial)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_inner_material", innerMaterial);
        }

        public static long AddJournal(Journal journal)
        {
            return HttpHelper.MakePostRequest<long>("librarian/add_journal", journal);
        }

        public static void EditArticle(Article article)
        {
            HttpHelper.MakePutRequest("librarian/edit_article", article);
        }        

        public static void EditAVMaterial(AVMaterial avMaterial)
        {
            HttpHelper.MakePutRequest("librarian/edit_av_material", avMaterial);
        }        

        public static void EditBook(Book book)
        {
            HttpHelper.MakePutRequest("librarian/edit_book", book);
        }        

        public static void EditInnerMaterial(InnerMaterial innerMaterial)
        {
            HttpHelper.MakePutRequest("librarian/edit_inner_material", innerMaterial);
        }        

        public static void EditJournal(Journal journal)
        {
            HttpHelper.MakePutRequest("librarian/edit_journal", journal);
        }

        public static void ReturnDocument(long documentId, long userId)
        {
            HttpHelper.MakePutRequest("librarian/return_document", new {
                DocumentId = documentId,
                UserId = userId });
        }
        
        public static bool AddLibrarian(Librarian librarian, string login, string password)
        {
            return HttpHelper.MakePostRequest<bool>("librarian/add_librarian", new {
                Librarian = librarian,
                Login = login,
                Password = password });
        }

        public static bool AddFaculty(Faculty faculty, string login, string password)
        {
            return HttpHelper.MakePostRequest<bool>("librarian/add_faculty", new
            {
                Faculty = faculty,
                Login = login,
                Password = password
            });
        }

        public static bool AddStudent(Student student, string login, string password)
        {
            return HttpHelper.MakePostRequest<bool>("librarian/add_student", new
            {
                Student = student,
                Login = login,
                Password = password
            });
        }

        public static bool AddGuest(Guest guest, string login, string password)
        {
            return HttpHelper.MakePostRequest<bool>("librarian/add_guest", new
            {
                Guest = guest,
                Login = login,
                Password = password
            });
        }

        public static void EditLibrarian(Librarian librarian)
        {
            HttpHelper.MakePutRequest("librarian/edit_librarian", librarian);
        }

        public static void EditFaculty(Faculty faculty)
        {
            HttpHelper.MakePutRequest("librarian/edit_faculty", faculty);
        }

        public static void EditStudent(Student student)
        {
            HttpHelper.MakePutRequest("librarian/edit_student", student);
        }

        public static void EditGuest(Guest guest)
        {
            HttpHelper.MakePutRequest("librarian/edit_guest", guest);
        }

        public static void DeleteUser(long userId)
        {
            HttpHelper.MakeDeleteRequest("librarian/delete_user", new {
                UserId = userId });
        }                
        
        public static void AddCopies(int n, Copy copy)
        {
            HttpHelper.MakePostRequest("librarian/add_copies", new {
                N = n,
                Copy = copy });
        }
        
        public static void DeleteCopy(long id)
        {
            HttpHelper.MakeDeleteRequest("librarian/delete_copies", new { Id = id });
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
