using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Managers.DataManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers
{
    /// <summary>
    /// Contains database commands for patrons
    /// </summary>
    public static class PatronDataManager
    {
        public static void CheckOutDocument(long documentID, long userID)
        {
            DocumentsDataManager.CheckOutDocument(documentID, userID);
        }
    }
}
