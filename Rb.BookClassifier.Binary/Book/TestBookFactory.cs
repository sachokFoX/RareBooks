﻿using OfficeOpenXml;
using Rb.BookClassifier.Common.Reader;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestBookFactory : TestSetFactory, ITestSetFactory<TestBook>
    {
        public TestBook Create(ExcelWorksheet worksheet, int row)
        {
            var address = new ExcelAddress(worksheet.Cells[row, 1].FullAddress);
            var testSetItem = GetTestSetItem(worksheet.Workbook, address.Start.Row);

            var isMoreInfoExists = worksheet.Cells[row, 2].GetValue<bool>();

            return new TestBook
            {
                Annotation = testSetItem.Annotation,
                Author = testSetItem.Author,
                InternalId = testSetItem.InternalId,
                IsBbkExists = testSetItem.IsBbkExists,
                IsMoreInfoExists = isMoreInfoExists,
                Language = testSetItem.Language,
                Title = testSetItem.Title,
                Year = testSetItem.Year
            };
        }
    }
}