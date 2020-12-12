namespace Computers.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorSetCorrectNamePropeerty()
        {
            Computer computer = new Computer("a");
            Assert.AreEqual("a", computer.Name);
        }

        [Test]
        public void ConstructorPartsCollectionIsEmpty()
        {
            Computer computer = new Computer("a");
            Assert.IsEmpty(computer.Parts);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void NamePropertyEmptyValueShouldThrowArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        public void PartsPropertyAddTwoPartsShouldAddTwoParts()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 1));
            computer.AddPart(new Part("q", 1));

            Assert.AreEqual(2, computer.Parts.Count);
        }

        [Test]
        public void TotalPriceShouldReturnCorrectResult()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 1));
            computer.AddPart(new Part("q", 2));
            computer.AddPart(new Part("e", 3));

            Assert.AreEqual(6, computer.TotalPrice);
        }

        [Test]
        public void AddPartMethodNullPartShouldThrowInvalidOperationException()
        {
            Computer computer = new Computer("a");

            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void AddPartMethodAddPartShouldAddPart()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 1));

            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        public void AddPartMethodAddPartShouldAddCorrectPart()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 1));

            Part actualPart = computer.Parts.FirstOrDefault(p => p.Name == "w");

            Assert.IsNotNull(actualPart);
            //Assert.AreEqual("w", actualPart.Name);
        }

        [Test]
        public void RemovePartMethodValidPartShouldReturnTrue()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);

            bool actResult = computer.RemovePart(part);

            Assert.IsTrue(actResult);
        }

        [Test]
        public void RemovePartMethodInvalidPartShouldReturnFalse()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            Part part2 = new Part("q", 1);

            computer.AddPart(part);

            bool actResult = computer.RemovePart(part2);

            Assert.IsFalse(actResult);
        }

        [Test]
        public void RemovePartMethodShouldRemoveSuccessfully()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);

            computer.RemovePart(part);

            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        public void RemovePartMethoRemovePartShouldRemoveCorrectPart()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);

            computer.RemovePart(part);

            Part actualPart = computer.Parts.FirstOrDefault(p => p.Name == "w");

            Assert.IsNull(actualPart);
        }

        [Test]
        public void GetPartMethoValidPartShouldReturnCorrectPart()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);

            Part actualPart = computer.GetPart("w"); ;

            Assert.AreEqual("w", actualPart.Name);
            Assert.AreEqual(1, actualPart.Price);
        }

        [Test]
        public void GetPartMethoInvalidPartShouldReturnNull()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);

            Part actualPart = computer.GetPart("q"); ;

            Assert.IsNull(actualPart);
        }
    }
}