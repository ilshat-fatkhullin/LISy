using LISy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Managers
{
    public interface IUsersDataManager
    {
        void AddDocument(IDocument document);

        void DeleteDocument(IDocument document);                
    }
}
