﻿using LISy.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
        public void AddPatron(IPatron patron)
        {
            if (patron == null)
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                connection.Execute("dbo.spUsers_AddUser @FirstName, @SecondName, @CardNumber, @Phone, @Address", patron);
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
                connection.Execute("dbo.spUsers_UpdateUser @CardNumber, @FirstName, @SecondName, @Phone, @Address", new { CardNumber = patron.CardNumber, FirstName = newPatron.FirstName,
                    SecondName = newPatron.SecondName, Phone = newPatron.Phone, Address = newPatron.Address });
            }
        }
    }
}