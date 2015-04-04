﻿using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestBookVectorizer : TestBookVectorizer<TestBook, TestBookRanges>
    {
        public TestBookVectorizer(TestBookRanges ranges)
            : base(ranges)
        {
        }

        public override double[] GetVector(TestBook snippet)
        {
            var result = GetBaseVector(snippet);

            var yandexResults = GetNormalized(snippet.YandexResults, Ranges.YandexResults);

            result.Add(yandexResults);

            return result.ToArray();
        }
    }
}