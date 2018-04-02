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

        public static void RenewDocument(long documentId, long patronId)
        {
            HttpHelper.MakePutRequest("patron/renew_copy", new
            {
                DocumentId = documentId,
                PatronId = patronId
            });
        }

        public static void AddToQueue(long documentId, long patronId)
        {
            HttpHelper.MakePostRequest("patron/add_to_queue", new
            {
                DocumentId = documentId,
                PatronId = patronId
            });
        }
    }
}