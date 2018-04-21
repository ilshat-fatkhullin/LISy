using LISy.Entities.Notifications;
using System;
using System.Collections.Generic;

namespace LISy.Managers
{
    public static class PatronDataManager
    {
        public static long PatronId { get; set; }

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

        public static Notification[] GetNotifications(long patronId)
        {
            var output = HttpHelper.MakeGetRequest<List<Notification>>("patron/get_notifications",
                new Tuple<string, string>[] {
                    new Tuple<string, string>("patronId", Convert.ToString(patronId))
                });
            if (output == null)
                return new Notification[] { };
            return output.ToArray();
        }

        public static void ReadNotification(long notificationId)
        {
            HttpHelper.MakePutRequest("patron/read_notification", new
            {
                PatronId,
                Id = notificationId,                
            });
        }
    }
}