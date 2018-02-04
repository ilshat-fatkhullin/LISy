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
    public static class PatronDataManager
    {
        public static void CheckOutDocument(Takable document, IPatron patron)
        {
            DocumentsDataManager.CheckOutDocument(document, patron);
        }
    }
}
