namespace Presents.Tests
{
    using System;
    using NUnit.Framework;

    public class PresentsTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestIfPresentCtorWorksCorrectly()
        {
            string expectedName = "Stick";
            double expectedMagic = 100;

            Present present = new Present(expectedName, expectedMagic);

            Assert.AreEqual(expectedName, present.Name);
            Assert.AreEqual(expectedMagic, present.Magic);
        }

        [Test]
        public void TestIfBagCtorWorksCorrectly()
        {
            Bag bag = new Bag();

            Assert.IsNotNull(bag.GetPresents());
        }
    }
}
