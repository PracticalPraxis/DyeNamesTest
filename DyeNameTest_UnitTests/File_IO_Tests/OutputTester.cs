using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using DyeNamesTest.File_IO;

namespace DyeNamesTest_UnitTests.File_IO_Tests
{
    public class OutputTester
    {
        [Test]
        public void simpleOutputTest()
        {
            var sortedFirstNames = new List<string> {
                "Ned",
                "Homer",
                "Seymour"
            };
            var sortedLastNames = new List<string> {
                "Flanders",
                "Simpson",
                "Skinner"
            };
            var sortedFullNames = fullNamesToList(sortedFirstNames, sortedLastNames);
            NameExporter.exportNames(sortedFullNames, "sorted-names-output-test.txt");
            checkEqual("../../../Testing_Files/output-test.txt", "sorted-names-output-test.txt");
        }
        private List<FullName> fullNamesToList(List<string> firstNames, List<string> lastNames)
        {
            var people = new List<FullName> { };
            for (int i = 0; i < firstNames.Count; ++i)
            {
                people.Add(new FullName(firstNames[i], lastNames[i]));
            }
            return people;
        }

        private void checkEqual(string pathOne, string pathTwo)
        {
            byte[] hashOne;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(pathOne))
                {
                    hashOne = md5.ComputeHash(stream);
                }
            }
            byte[] hashTwo;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(pathTwo))
                {
                    hashTwo = md5.ComputeHash(stream);
                }
            }
            Assert.True(hashOne.SequenceEqual(hashTwo));
        }
    }
}
