using Dapper;
using LISy.Entities;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using System;
using System.Data;
using System.Linq;

namespace LISy.Managers
{
    /// <summary>
    /// Contains database commands for credentials
    /// </summary>
    public static class CredentialsManager
	{        
        public static long Authorize(string login, string password)
        {
            return HttpHelper.MakeGetRequest<long>("librarian/authorize", new { login, password });
        }
        
        public static string GetUserType(long userId)
        {
            return HttpHelper.MakeGetRequest("librarian/get_user_type", new { userId });
        }
        
        public static long AddUserCredentials(string login, string password)
        {
            return HttpHelper.MakeGetRequest<long>("librarian/add_user_credentials", new { login, password });
        }
        
        public static void DeleteUserCredentials(long userId)
        {
            HttpHelper.MakeDeleteRequest("librarian/delete_user_credentials", new { userId });
        }
        
        public static void ModifyUserCredentials(long userId, string password)
        {
            HttpHelper.MakePutRequest("librarian/edit_user_credentials", new { userId, password });
        }
        
        public static User GetUserById(long userId)
        {
            return HttpHelper.MakeGetRequest<User>("librarian/get_user_by_id", new { userId });
        }
    }
}