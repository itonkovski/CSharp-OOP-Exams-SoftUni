namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]

    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectlyAllProperties()
        {
            string name = "Strange";
            int capacity = 10;

            Aquarium aquarium = new Aquarium(name, capacity);

            string expectedName = "Strange";
            int expectedCapacity = 10;

            string actualName = aquarium.Name;
            int actualCapacity = aquarium.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void SetNameShouldThrowExceptionWhenItIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10));

            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 10));


        }

        [Test]
        public void SetCapacityShouldThrowExceptionWhenItIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Strange", -10));
        }

        [Test]
        public void AddFishShouldAddFishInAquariumWhenCapacityValid()
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void AddFishShouldThrowExceptionWhenCapacityIsInvalid()
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 0);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void RemoveFishShouldRemoveFishFromAquarium()
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            aquarium.RemoveFish("Nemo");

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void RemoveFishShouldThrowExceptionWhenNameIsNotFound()
        {
            Aquarium aquarium = new Aquarium("Strange", 0);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("None"));
        }

        [Test]
        public void SellFishShouldSetAvailablePropertyToFalse()
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            Fish soldFish = aquarium.SellFish("Nemo");

            var expectedAvailability = false;

            Assert.AreEqual(expectedAvailability, soldFish.Available);
        }

        [Test]
        public void SellFishShouldThrowExceptionWhenNameIsNotFound()
        {
            Aquarium aquarium = new Aquarium("Strange", 0);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("None"));
        }

        [Test]
        public void ValidateReportMessage()
        {
            Fish fish = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            aquarium.Add(fish2);

            string expectedResult = "Fish available at Strange: Nemo, Nemo2";
            string actualResult = aquarium.Report();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
 