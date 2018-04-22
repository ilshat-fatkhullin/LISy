using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities;
using LISy.Entities.Documents;

namespace LISy.Managers
{
    public class SearchManager
    {
        private static IDictionary<Document, int> filterByAuthor
            (
            Document[] allDocuments,
            string searchRequest,
            Type searchType,
            IDictionary<Document, int> rankedFilteredDocuments
            )
        {
            string parsedSearchRequest = searchRequest.ToLower().Replace(".", " ").Replace(",", " ").Replace(";", " ").Replace(":", " ").Replace("!", " ").Replace("?", " ").Replace("(", " ").Replace(")", " ").Replace("  ", " ");
            string[] authorsToSearch = parsedSearchRequest.Split(' ');
            foreach (Document document in allDocuments) {
                foreach (string author in authorsToSearch)
                {
                    var documentType = document.GetType();
                    if (searchType == documentType && document.Authors.ToLower().Contains(author))
                    {
                        if (rankedFilteredDocuments.TryGetValue(document, out int rank))
                        {
                            rankedFilteredDocuments[document] = rank + 1;
                        }
                        else
                        {
                            rankedFilteredDocuments[document] = 1;
                        }
                    }
                }
            }

            return rankedFilteredDocuments;
        }

        private static IDictionary<Document, int> filterByTitle
            (
            Document[] allDocuments,
            string searchRequest,
            Type searchType,
            IDictionary<Document, int> rankedFilteredDocuments
            )
        {
            string parsedSearchRequest = searchRequest.ToLower().Replace(".", " ").Replace(",", " ").Replace(";", " ").Replace(":", " ").Replace("!", " ").Replace("?", " ").Replace("(", " ").Replace(")", " ").Replace("  ", " ");
            string[] titleToSearch = parsedSearchRequest.Split(' ');
            foreach (Document document in allDocuments)
            {
                foreach (string title in titleToSearch)
                {
                    var documentType = document.GetType();
                    if (searchType == documentType && document.Title.ToLower().Contains(title))
                    {
                        if (rankedFilteredDocuments.TryGetValue(document, out int rank))
                        {
                            rankedFilteredDocuments[document] = rank + 1;
                        }
                        else
                        {
                            rankedFilteredDocuments[document] = 1;
                        }
                    }
                }
            }

            return rankedFilteredDocuments;
        }

        private static IDictionary<Document, int> filterByKeyWords
            (
            Document[] allDocuments,
            string searchRequest,
            Type searchType,
            IDictionary<Document, int> rankedFilteredDocuments
            )
        {
            string parsedSearchRequest = searchRequest.ToLower().Replace(".", " ").Replace(",", " ").Replace(";", " ").Replace(":", " ").Replace("!", " ").Replace("?", " ").Replace("(", " ").Replace(")", " ").Replace("  ", " ");
            string[] keyWordsToSearch = parsedSearchRequest.Split(' ');
            foreach (Document document in allDocuments)
            {
                foreach (string keyWord in keyWordsToSearch)
                {
                    var documentType = document.GetType();
                    if (searchType == documentType && document.KeyWords.ToLower().Contains(keyWord))
                    {
                        if (rankedFilteredDocuments.TryGetValue(document, out int rank))
                        {
                            rankedFilteredDocuments[document] = rank + 1;
                        }
                        else
                        {
                            rankedFilteredDocuments[document] = 1;
                        }
                    }
                }
            }

            return rankedFilteredDocuments;
        }

        public static Document[] search
            (
            Document[] allDocuments,
            string searchRequest,
            Type type,
            bool searchByAuthor,
            bool searchByTitle,
            bool searchByKeyWords
            )
        {
            IDictionary<Document, int> rankedFilteredDocuments = new Dictionary<Document, int>();
            if (searchByAuthor)
            {
                rankedFilteredDocuments = filterByAuthor(allDocuments, searchRequest, type, rankedFilteredDocuments);
            }
            if (searchByTitle)
            {
                rankedFilteredDocuments = filterByTitle(allDocuments, searchRequest, type, rankedFilteredDocuments);
            }
            if (searchByKeyWords)
            {
                rankedFilteredDocuments = filterByKeyWords(allDocuments, searchRequest, type, rankedFilteredDocuments);
            }
            List <Document> filteredDocuments = new List<Document>();
            foreach (KeyValuePair<Document, int> item in rankedFilteredDocuments.OrderByDescending(document => document.Value))
            {
                filteredDocuments.Add(item.Key);
            }
            return filteredDocuments.ToArray();
        }


    }
}
