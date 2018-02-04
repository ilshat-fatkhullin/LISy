﻿using Dapper;
using System;
using System.Data;
using System.Linq;

namespace LISy.Managers
{
    public static class CredentialsManager
    {
        /// <summary>
        /// Checks is user with current login and password exist in the database.
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password</param>        
        /// <returns>Returns card number, if credentials is correct, -1 otherwise</returns>
        public static long Authorize(string login, string password)
        {            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {

                var output = connection.Query<long>("dbo.spCredentials_Authorize @Login, @Password", new { Login = login,
                    Password = password }).ToList();
                if (output.Count > 0)
                {
                    return output[0];
                }
            }

            return -1;
        
        }

        /// <summary>
        /// Returns type of account of user with current login.
        /// </summary>
        /// <param name="cardNumber">User's card number</param>
        /// <returns>User's type</returns>
        public static string GetUserType(long cardNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<String>("dbo.spUsers_GetUserTypeByCard  @CardNumber", new { CardNumber = cardNumber }).ToList();
                return output[0];
            }
        }

        /// <summary>
        /// Adds new credentials to the database
        /// </summary>
        /// <param name="login">Account's login</param>
        /// <param name="password">Account's password</param>
        /// <param name="cardNumber">Account's card number</param>
        public static long AddUserCredentials(string login, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<long>("dbo.spCredentials_AddCredential @Login, @Password", new { Login = login, Password = password}).ToList();
                return output[0];
            }
        }

        /// <summary>
        /// Deletes current credentials from the database
        /// </summary>
        /// <param name="cardNumber">Account's card number</param>        
        public static void DeleteUserCredentials(long cardNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                connection.Execute("dbo.spCredentials_DeleteCredential @CardNumber", new { CardNumber = cardNumber });
            }
        }

        /// <summary>
        /// Modify current credentials
        /// </summary>
        /// <param name="cardNumber">Account's card number</param>        
        public static void ModifyUserCredentials(long cardNumber, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                connection.Execute("dbo.spCredentials_ModifyCredential @CardNumber, @Password",
                    new { CardNumber = cardNumber, Password = password });
            }
        }
    }
}