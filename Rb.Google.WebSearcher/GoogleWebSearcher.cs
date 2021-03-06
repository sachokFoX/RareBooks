﻿using System;
using Rb.Common.Enums;
using Rb.Common.WebSearcher;
using Rb.Data.Entities;
using Rb.RequestFactories.Google;

namespace Rb.Google.WebSearcher
{
    internal class GoogleWebSearcher : WebSearcherBase
    {
        private readonly GoSearchEngine m_searchEngine;

        public GoogleWebSearcher(int availableRequests)
            : base(availableRequests)
        {
            m_searchEngine = new GoSearchEngine();
            Books = GetBooks(i => !i.ProcessedByGoogle);
        }

        public void Process()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("There are no books for google processing.");
                return;
            }

            foreach (var book in Books)
            {
                var lastRequestType = GetLastRequest<GoogleSearchResult>(book);
                var requestStartIndex = RequestTypes.IndexOf(lastRequestType) + 1;

                for (var j = requestStartIndex; j < RequestTypes.Count; j++)
                {
                    if (AvailableRequests == 0)
                    {
                        Console.WriteLine("There are no available requests for today...");
                        return;
                    }

                    var request = GoRequestFactory.GetRequest(book, RequestTypes[j]);

                    if (string.IsNullOrEmpty(request.Query))
                    {
                        Console.WriteLine("Empty query, continue...");
                        continue;
                    }

                    Console.WriteLine("Getting result for {0}", book.Title);
                    var result = m_searchEngine.Execute(request);

                    if (result != null)
                    {
                        AvailableRequests--;
                        SaveResult(GetSerchResult(result, book, RequestTypes[j]));
                        Console.WriteLine("Saved {0} result(s) for {1}", result.ResultItems.Count, book.Title);
                    }
                }

                book.ProcessedByGoogle = true;

                UpdateBook(book);
                Console.WriteLine("Updated book status {0}", book.Title);
            }
        }

        private static GoogleSearchResult GetSerchResult(GoSearchResult result, Book book, RequestType requestType)
        {
            var googleSearchResult = new GoogleSearchResult
            {
                BookId = book.Id,
                BookInternalId = book.InternalId,
                QueryString = result.Query,
                RequestType = requestType,
                TimeStamp = DateTime.Now,
                TotalResults = result.TotalResults
            };

            foreach (var goSearchResultItem in result.ResultItems)
            {
                googleSearchResult.Items.Add(new GoogleSearchResultItem
                {
                    Snippet = goSearchResultItem.Snippet,
                    Title = goSearchResultItem.Title,
                    Url = goSearchResultItem.Url
                });
            }

            return googleSearchResult;
        }
    }
}