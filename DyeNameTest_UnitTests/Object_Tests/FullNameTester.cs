using System;
using DyeNamesTest;

namespace DyeNamesTest_UnitTests.Object_Tests
{
    public class FullNameTester
    {

        //Test that FullName objects are equal to each other when they should be
        [Test]
        public void equalsTest()
        {
            FullName a = new FullName("Homer", "Simpson");
            FullName b = new FullName("Homer", "Simpson");
            FullName c = new FullName("Ned", "Flanders");
            Assert.AreEqual(a, b);
            Assert.AreNotEqual(a, c);
        }
    }
}
