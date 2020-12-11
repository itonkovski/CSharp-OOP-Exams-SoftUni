namespace Presents.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class PresentsTests
    {
        private  Bag bag;
        // readonly not working

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
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

        [Test]
        public void CreateShouldThrowExceptionWithNullPresent()
        {
            Present present = null;

            Assert.That(() =>
            {
                bag.Create(present);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void CreateShouldThrowExceptionWithLikeSamePresent()
        {
            Present present = new Present("Stick", 100);

            bag.Create(present);

            Assert.That(() =>
            {
                bag.Create(present);
            }, Throws.InvalidOperationException.With.Message
                .EqualTo("This present already exists!"));
        }

        [Test]
        public void CreateShouldPhysicallyAddThePresents()
        {
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, magic);

            bag.Create(p1);
            bag.Create(p2);

            IReadOnlyCollection<Present> exp = new List<Present>()
            {
                p1, p2
            };

            IReadOnlyCollection<Present> act = bag.GetPresents();

            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        public void CreateShouldReturnCorrectMessage()
        {
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);

            string exp = $"Successfully added present {p1.Name}.";
            string res = bag.Create(p1);

            Assert.AreEqual(exp, res);
        }

        [Test]
        public void RemoveShouldPhysicallyRemoveThePresent()
        {
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, magic);

            bag.Create(p1);
            bag.Create(p2);

            bool res = bag.Remove(p1);

            IReadOnlyCollection<Present> exp = new List<Present>()
            {
                p2
            };

            IReadOnlyCollection<Present> act = bag.GetPresents();

            Assert.IsTrue(res);
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        public void TryRemovingNonExistingPresentShouldReturnFalse()
        {
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);

            bool res = bag.Remove(p1);

            Assert.IsFalse(res);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkCorrectly()
        {
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, 50);
            Present exp = new Present(name, 20);

            bag.Create(p1);
            bag.Create(p2);
            bag.Create(exp);

            Present act = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void GetPresentWithLeastMAgicShouldThrowExceptionWhenBagEmpty()
        {
            Assert.That(() =>
            {
                bag.GetPresentWithLeastMagic();
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void GetPresentShouldReturnCorrectPresentWhenNoDuplicates()
        {
            string expName = "Stick";

            Present exp = new Present(expName, 100);
            Present p2 = new Present("Another present", 50);

            bag.Create(exp);
            bag.Create(p2);

            Present act = bag.GetPresent(expName);

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void GetPresentShouldReturnFirstPresentWhenDuplicates()
        {
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, magic);

            bag.Create(p1);
            bag.Create(p2);

            Present act = bag.GetPresent(name);

            Assert.AreEqual(p1, act);
        }

        [Test]
        public void GetPresentShouldReturnNullWhenNameDoesntExist()
        {
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, magic);

            bag.Create(p1);
            bag.Create(p2);

            string invalidName = "Non existing name";

            Present act = bag.GetPresent(invalidName);

            Assert.IsNull(act);
        }
    }
}
