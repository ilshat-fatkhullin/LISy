using Dapper;
using LISy.Entities.Users;
using System;
using System.Data;
using System.Linq;
using System.Windows;

namespace LISy.Managers.DataManagers
{
    public class UsersDataManager
    {
        public UsersDataManager()
        {

        }

        /// <summary>
        /// Adds new patron to the database.        
        /// </summary>
        /// <param name="patron">Patron, which is going to be added.</param>
        public bool AddPatron(IPatron patron, string login, string password)
        {

            if (patron == null)
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<bool>("dbo.spUsers_IsUserInTable @FirstName, @SecondName, @Phone", 
                    new { FirstName = patron.FirstName, SecondName = patron.SecondName, Phone = patron.Phone}).ToList();
                if (!output[0])
                {
                    long cardNumber = CredentialsManager.AddUserCredentials(login, password);

                    patron.CardNumber = cardNumber;
                    connection.Execute("dbo.spUsers_AddUser @FirstName, @SecondName, @CardNumber, @Phone, @Address, @Type", 
                        new { FirstName = patron.FirstName, SecondName = patron.SecondName, CardNumber = patron.CardNumber,
                        Phone = patron.Phone, Address = patron.Address, Type = patron.GetType().ToString().Split('.').Last()});
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// Deletes a patron from the database.
        /// </summary>
        /// <param name="patron">Patron, which is going to be deleted.</param>
        public void DeletePatron(IPatron patron)
        {

            if (patron == null)
            {
                throw new ArgumentNullException();
            }

            CredentialsManager.DeleteUserCredentials(patron.CardNumber);

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                connection.Execute("dbo.spUsers_DeleteUser @CardNumber", patron);
            }
        }

        /// <summary>
        /// Replaces <code>patron</code> on <code>newPatron</code> in the database.
        /// </summary>
        /// <param name="patron">Patron, which is going to be replaced.</param>
        /// <param name="newPatron">Patron, which is going to be instead of <code>patron</code>.</param>
        public void EditPatron(IPatron patron, IPatron newPatron)
        {
            if (patron == null || newPatron == null)
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                connection.Execute("dbo.spUsers_ModifyUser @CardNumber, @FirstName, @SecondName, @Phone, @Address", 
                    new { CardNumber = patron.CardNumber, FirstName = newPatron.FirstName,
                        SecondName = newPatron.SecondName, Phone = newPatron.Phone, Address = newPatron.Address });
            }
        }
    }
}
