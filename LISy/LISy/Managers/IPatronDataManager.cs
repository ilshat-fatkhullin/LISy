using LISy.Entities;
using LISy.Entities.Users;

namespace LISy.Managers
{
    public interface IPatronDataManager
    {
        void CheckOutDocument(IDocument document, IPatron patron);
    }
}
