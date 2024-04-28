using System;
using System.Collections.Generic;
using DyeNamesTest.Objects;

namespace DyeNamesTest_UnitTests.File_IO_Tests
{
    public class ImportTester
    {
        [Test]
        public void basicReadTest()
        {
            List<string> firstNames = new List<string> {
                "Ned",
                "Homer",
                "Seymour"
            };
            List<string> lastNames = new List<string> {
                "Flanders",
                "Simpson",
                "Skinner"
            };
            List<FullName> fullNames = new List<FullName> { };
            for (int i = 0; i < firstNames.Count; ++i)
            {
                fullNames.Add(new FullName(firstNames[i], lastNames[i]));
            }
            var testNames = NameImporter.importNames("../../../Testing_Files/sorted-names-test.txt");
            Assert.AreEqual(testNames, fullNames);
        }
    }
}
