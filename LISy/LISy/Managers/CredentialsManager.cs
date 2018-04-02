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
            return HttpHelper.MakeGetRequest<long>("credentials/authorize",
                new Tuple<string, string>[] {
                    new Tuple<string, string>("login", login),
                    new Tuple<string, string>("password", password)
                });
        }        
        
        public static void EditUserCredentials(long userId, string password)
        {
            HttpHelper.MakePutRequest("credentials/edit_user_credentials", new {
                UserId = userId,
                Password = password });
        }                
    }
}