using RestSharp;

namespace LISy.Managers
{
    public static class PatronDataManager
    {
        public static void CheckOutDocument(long documentId, long userId)
        {
            HttpHelper.MakePutRequest("patron/check_out", new {
                DocumentId = documentId,
                UserId = userId });
        }
    }
}