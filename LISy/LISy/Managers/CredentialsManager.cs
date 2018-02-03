using System;

namespace LISy.Managers
{
    public static class CredentialsManager
    {
        /// <summary>
        /// Checks is user with current login and password exist in the database.
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password</param>        
        /// <returns>Returns true, if credentials is correct, false otherwise</returns>
        public static bool Authorize(string login, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns type of account of user with current login.
        /// </summary>
        /// <param name="cardNumber">User's card number</param>
        /// <returns>User's type</returns>
        public static Type GetUserType(long cardNumber)
        {
            //typeof(ILibrarian) -- пример того, как получить тип
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds new credentials to the database
        /// </summary>
        /// <param name="login">Account's login</param>
        /// <param name="password">Account's password</param>
        /// <param name="cardNumber">Account's card number</param>
        public static void AddUserCredentials(string login, string password, long cardNumber)
        {            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes current credentials from the database
        /// </summary>
        /// <param name="cardNumber">Account's login</param>        
        /// <param name="accountType">Type of an account</param>
        public static void DeleteUserCredentials(long cardNumber)
        {
            throw new NotImplementedException();
        }
    }
}