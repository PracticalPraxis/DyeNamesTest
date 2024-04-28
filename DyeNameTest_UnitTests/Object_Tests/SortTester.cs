using DyeNamesTest.Objects;
using System.Collections.Generic;

namespace DyeNamesTest_UnitTests.Object_Tests
{
    public class SortTester
    {
        [Test]
        public void sortTest()
        {
            List<string> firstNames = new List<string> {
                "Homer",
                "Ned",
                "Seymour"
            };
            List<string> lastNames = new List<string> {
                "Simpson",
                "Flanders",
                "Skinner"
            };
            List<FullName> unsortedNames = fullNamesToList(firstNames, lastNames);
            List<FullName> sortedNames = Sorter.SortNames(unsortedNames);

            List<string> sortedFirstNames = new List<string> {
                "Ned",
                "Homer",
                "Seymour"
            };
            List<string> sortedLastNames = new List<string> {
                "Flanders",
                "Simpson",
                "Skinner"
            };
            List<FullName> correctSorted = fullNamesToList(sortedFirstNames, sortedLastNames);
            Assert.AreEqual(correctSorted, sortedNames);
        }

        [Test]
        public void sameLastNameTester()
        {
            List<string> unsortedFirst = new List<string> {
                "Homer",
                "Ned",
                "Maggie"
            };
            List<string> unsortedLast = new List<string> {
                "Simpson",
                "Flanders",
                "Simpson"
            };
            List<string> sortedFirst = new List<string> {
                "Ned",
                "Homer",
                "Maggie"
            };
            List<string> sortedLast = new List<string> {
                "Flanders",
                "Simpson",
                "Simpson"
            };
            List<FullName> unsorted = fullNamesToList(unsortedFirst, unsortedLast);
            List<FullName> testSorted = Sorter.SortNames(unsorted);
            List<FullName> correctSorted = fullNamesToList(sortedFirst, sortedLast);
            Assert.AreEqual(correctSorted, testSorted);
        }

        [Test]
        public void sameFirstNameTester()
        {
            List<string> unsortedFirst = new List<string> {
                "Seymour",
                "Ned",
                "Seymour"
            };
            List<string> unsortedLast = new List<string> {
                "Skinnerest",
                "Flanders",
                "Skinner"
            };
            List<string> sortedFirst = new List<string> {
                "Ned",
                "Seymour",
                "Seymour"
            };
            List<string> sortedLast = new List<string> {
                "Flanders",
                "Skinner",
                "Skinnerest"
            };
            List<FullName> unsorted = fullNamesToList(unsortedFirst, unsortedLast);
            List<FullName> testSorted = Sorter.SortNames(unsorted);
            List<FullName> correctSorted = fullNamesToList(sortedFirst, sortedLast);
            Assert.AreEqual(correctSorted, testSorted);
        }
        [Test]
        public void CheckIsAlphanumericOrAllowedCharsTrueTest()
        {
            bool nameValid = false;

            FullName testName = new FullName("Joseph", "Joestar");

            nameValid = Sorter.CheckIsAlphanumericOrAllowedChars(testName);

            Assert.AreEqual(nameValid, true);
        }
        [Test]
        public void CheckIsAlphanumericOrAllowedCharsFalseTest()
        {
            bool nameValid = true;

            FullName testName = new FullName("Joseph", "Joestar #TheJoeest");

            nameValid = Sorter.CheckIsAlphanumericOrAllowedChars(testName);

            Assert.AreEqual(nameValid, false);
        }
        [Test]
        public void CheckIsAlphanumericOrAllowedCharsSpecialCharTest()
        {
            bool nameValid = true;

            FullName testName = new FullName("Joseph", "Joestar-TheJoeest");

            nameValid = Sorter.CheckIsAlphanumericOrAllowedChars(testName);

            Assert.AreEqual(nameValid, true);
        }

        private List<FullName> fullNamesToList(List<string> firstNames, List<string> lastNames)
        {
            List<FullName> fullNames = new List<FullName> { };
            for (int i = 0; i < firstNames.Count; ++i)
            {
                fullNames.Add(new FullName(firstNames[i], lastNames[i]));
            }
            return fullNames;
        }
    }
}
