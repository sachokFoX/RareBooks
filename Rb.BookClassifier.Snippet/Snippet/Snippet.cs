﻿using System.Collections.Generic;
using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class Snippet : ISnippet
    {
        public bool IsMoreInfoExists { get; set; }

        public string Author { get; set; }

        public List<ISnippetData> Data { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}