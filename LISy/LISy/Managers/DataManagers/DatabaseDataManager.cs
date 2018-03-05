using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers.DataManagers
{
    public static class DatabaseDataManager
    {
        public static void ClearAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LibraryDB")))
            {
                connection.Execute("dbo.spLISy_ClearAll");
            }
        }
    }
}