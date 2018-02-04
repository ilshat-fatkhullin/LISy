﻿using Dapper;
using LISy.Entities.Users;
using System;
using System.Data;
using System.Linq;

namespace LISy.Managers.DataManagers
{
    static class UsersDataManager
    {        
        /// <summary>
        /// Adds new Patron to the database.        
        /// </summary>
        /// <param name="patron">Patron, which is going to be added.</param>
        public static bool AddPatron(IPatron patron, string login, string password)
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
        /// Deletes a Patron from the database.
        /// </summary>
        /// <param name="patron">Patron, which is going to be deleted.</param>
        public static void DeletePatron(IPatron patron)
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
        /// Replaces <code>Patron</code> on <code>newPatron</code> in the database.
        /// </summary>
        /// <param name="patron">Patron, which is going to be replaced.</param>
        /// <param name="newPatron">Patron, which is going to be instead of <code>Patron</code>.</param>
        public static void EditPatron(IPatron patron, IPatron newPatron)
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
