using Dapper;
using LISy.Entities.Users;
using System;
using System.Data;
using System.Linq;
using System.Windows.Documents;
using LISy.Entities;
using LISy.Entities.Users.Patrons;

namespace LISy.Managers.DataManagers
{
    /// <summary>
    /// Contains database commands for users
    /// </summary>
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
                    new { FirstName = patron.FirstName, SecondName = patron.SecondName, Phone = patron.Phone }).ToList();
                if (!output[0])
                {
                    long cardNumber = CredentialsManager.AddUserCredentials(login, password);

                    patron.CardNumber = cardNumber;
                    connection.Execute("dbo.spUsers_AddUser @FirstName, @SecondName, @CardNumber, @Phone, @Address, @Type",
                        new
                        {
                            FirstName = patron.FirstName,
                            SecondName = patron.SecondName,
                            CardNumber = patron.CardNumber,
                            Phone = patron.Phone,
                            Address = patron.Address,
                            Type = patron.GetType().ToString().Split('.').Last()
                        });
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
                    new
                    {
                        CardNumber = patron.CardNumber,
                        FirstName = newPatron.FirstName,
                        SecondName = newPatron.SecondName,
                        Phone = newPatron.Phone,
                        Address = newPatron.Address
                    });
            }
        }

        public static IUser[] GetUsersList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                var output = connection.Query<TempUser>("dbo.spUsers_GetAllUsers").ToArray();
                IUser[] users = new IUser[output.Count()];
                for (int i = 0; i < users.GetLength(0); i++)
                {
                    TempUser user = output[i];
                    switch (user.Type)
                    {
                        case "Faculty":
                            users[i] = new Faculty(user.FirstName, user.SecondName, user.Phone, user.Address);
                            break;
                        case "Student":
                            users[i] = new Student(user.FirstName, user.SecondName, user.Phone, user.Address);
                            break;
                        case "Librarian":
                            users[i] = new Librarian(user.FirstName, user.SecondName, user.Phone, user.Address);
                            break;                        
                    }

                    users[i].CardNumber = output[i].CardNumber;
                }
                return users;
            }
        }
    }

    class TempUser
    {
        public string FirstName;

        public string SecondName;

        public int CardNumber;

        public string Phone;

        public string Address;

        public string Type;        
    }
}
