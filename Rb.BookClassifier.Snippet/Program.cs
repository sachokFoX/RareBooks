﻿using System;
using System.IO;
using System.Linq;

namespace Rb.BookClassifier.Snippet
{
    internal class Program
    {
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException +=
                (sender, args) => File.WriteAllText("error.txt", args.ExceptionObject.ToString());
            StartApplication();
        }

        private static void StartApplication()
        {
            Console.WriteLine("Learn / Check / Save classified / Randon test? [1 / 2 / 3 / 4]");

            var classifier = new Classifier();

            var allowedOprations = new[] { "1", "2", "3", "4" };
            var operation = Console.ReadLine();

            if (!allowedOprations.Contains(operation))
            {
                Console.Clear();
                StartApplication();
            }

            if (operation == "1")
            {
                Console.WriteLine("Learning...");
                classifier.Learn();
            }

            if (operation == "2")
            {
                Console.WriteLine("Checking...");
                classifier.Check();
            }

            if (operation == "3")
            {
                Console.WriteLine("Saving...");
                classifier.SaveClassified();
            }

            if (operation == "4")
            {
                Console.WriteLine("Random test...");
                classifier.RandomTest();
            }
        }
    }
}