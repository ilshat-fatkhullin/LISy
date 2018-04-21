using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities;

namespace LISy.Managers
{
    public class SearchManager
    {
        private IDictionary<Document, int> filterByAuthor
            (
            List<Document> allDocuments, 
            string searchRequest, 
            string type, 
            IDictionary<Document, int> rankedFilteredDocuments
            )
        {
            string parsedSearchRequest = searchRequest.ToLower().Replace(".", " ").Replace(",", " ").Replace(";", " ").Replace(":", " ").Replace("!", " ").Replace("?", " ").Replace("(", " ").Replace(")", " ").Replace("  ", " ");
            string[] authorsToSearch = parsedSearchRequest.Split(' ');
            foreach (Document document in allDocuments) {
                foreach (string author in authorsToSearch)
                {
                    if (document.GetType().ToString().Equals(type) && document.Authors.ToLower().Contains(author))
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

        private IDictionary<Document, int> filterByTitle
            (
            List<Document> allDocuments,
            string searchRequest,
            string type,
            IDictionary<Document, int> rankedFilteredDocuments
            )
        {
            string parsedSearchRequest = searchRequest.ToLower().Replace(".", " ").Replace(",", " ").Replace(";", " ").Replace(":", " ").Replace("!", " ").Replace("?", " ").Replace("(", " ").Replace(")", " ").Replace("  ", " ");
            string[] titleToSearch = parsedSearchRequest.Split(' ');
            foreach (Document document in allDocuments)
            {
                foreach (string title in titleToSearch)
                {
                    if (document.GetType().ToString().Equals(type) && document.Title.ToLower().Contains(title))
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

        private IDictionary<Document, int> filterByKeyWords
            (
            List<Document> allDocuments,
            string searchRequest,
            string type,
            IDictionary<Document, int> rankedFilteredDocuments
            )
        {
            string parsedSearchRequest = searchRequest.ToLower().Replace(".", " ").Replace(",", " ").Replace(";", " ").Replace(":", " ").Replace("!", " ").Replace("?", " ").Replace("(", " ").Replace(")", " ").Replace("  ", " ");
            string[] keyWordsToSearch = parsedSearchRequest.Split(' ');
            foreach (Document document in allDocuments)
            {
                foreach (string keyWord in keyWordsToSearch)
                {
                    if (document.GetType().ToString().Equals(type) && document.KeyWords.ToLower().Contains(keyWord))
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

        public List<Document> search
            (
            List<Document> allDocuments,
            string searchRequest,
            string type,
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
            foreach (KeyValuePair<Document, int> item in rankedFilteredDocuments.OrderBy(document => document.Value))
            {
                filteredDocuments.Add(item.Key);
            }
            return filteredDocuments;
        }


    }
}
