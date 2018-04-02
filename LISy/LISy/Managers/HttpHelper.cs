using RestSharp;
using System;

namespace LISy.Managers
{
    public static class HttpHelper
    {
        private const string MAIN_URL = "http://lisyrest.azurewebsites.net/api/";
        //private const string MAIN_URL = "http://localhost:53725/api/";

        public static void MakePostRequest(string requestURL, object data)
        {
            RestClient client = new RestClient(MAIN_URL + requestURL);
            var request = new RestRequest(Method.POST);
            if (data != null)
                request.AddJsonBody(data);
            client.Execute(request);
        }

        public static T MakePostRequest<T>(string requestURL, object data) where T : new()
        {
            RestClient client = new RestClient(MAIN_URL + requestURL);
            var request = new RestRequest(Method.POST);
            if (data != null)
                request.AddJsonBody(data);
            return client.Execute<T>(request).Data;
        }

        public static void MakePutRequest(string requestURL, object data)
        {
            RestClient client = new RestClient(MAIN_URL + requestURL);
            var request = new RestRequest(Method.PUT);
            if (data != null)
                request.AddJsonBody(data);
            client.Execute(request);
        }

        public static void MakeDeleteRequest(string requestURL, object data)
        {
            RestClient client = new RestClient(MAIN_URL + requestURL);
            var request = new RestRequest(Method.DELETE);
            if (data != null)
                request.AddJsonBody(data);
            client.Execute(request);
        }

        public static T MakeGetRequest<T>(string requestURL, Tuple<string, string>[] data) where T : new()
        {
            RestClient client = new RestClient(MAIN_URL + requestURL);
            var request = new RestRequest(Method.GET);
            if (data != null)
            {
                foreach (var parameter in data)
                {
                    request.AddQueryParameter(parameter.Item1, parameter.Item2);
                }
            }
            return client.Execute<T>(request).Data;
        }

        public static string MakeGetRequest(string requestURL, Tuple<string, string>[] data)
        {
            RestClient client = new RestClient(MAIN_URL + requestURL);
            var request = new RestRequest(Method.GET);
            if (data != null)
            {
                foreach (var parameter in data)
                {
                    request.AddQueryParameter(parameter.Item1, parameter.Item2);
                }
            }
            return client.Execute(request).Content;
        }
    }
}
