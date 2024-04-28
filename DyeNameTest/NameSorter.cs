using System;
using System.Globalization;
using DyeNamesTest.File_IO;
using DyeNamesTest.Objects;

namespace DyeNamesTest
{
    /// <summary>
    /// This exports a list of alphabetically sorted names to an external file
    /// </summary>
    class NameSorter
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Incorrect number of arguments entered.");
                return;
            }

            String filename = args[1];
            List<FullName> unsortedNames = NameImporter.importNames(filename);
            List<FullName> sortedNames = new List<FullName>();

            // Comment added to test Travis build
            if (!Sorter.CheckIsAlphanumericOrAllowedChars(unsortedNames)) {
                Console.Error.WriteLine("File contains non-alphanumeric characters - please correct the data and re-submit.");
                return;
            }

            sortedNames = Sorter.SortNames(unsortedNames);
            NameExporter.exportNames(sortedNames, "sorted-names-list.txt");
        }
    }
}
