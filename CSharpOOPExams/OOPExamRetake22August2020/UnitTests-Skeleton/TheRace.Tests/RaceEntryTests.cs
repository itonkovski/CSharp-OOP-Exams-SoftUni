using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenNull()
        {
            var raceEntry = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionIfDriverExist()
        {
            var raceEntry = new RaceEntry();
            var unitDriver = new UnitDriver("Ivan", new UnitCar("model", 10, 10));
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver));
        }

        [Test]
        public void AddDriverMethodShouldWorkProperly()
        {
            var raceEntry = new RaceEntry();
            var unitDriver = new UnitDriver("Ivan", new UnitCar("model", 10, 10));
            var result = raceEntry.AddDriver(unitDriver);

            Assert.AreEqual("Driver Ivan added in race.", result);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceprionWhenNotEnoughParticipants()
        {
            var raceEntry = new RaceEntry();
            var unitDriver = new UnitDriver("Ivan", new UnitCar("model", 10, 10));
            var result = raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }

        [Test]
        
        public void CalculateAverageHorsePowerShouldWork()
           
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("VW", 100, 450);
            var uniDriver = new UnitDriver("Kiro", unitCar);

            var unitCar2 = new UnitCar("BMW", 100, 500);
            var uniDriver2 = new UnitDriver("Ivan", unitCar);

            var unitCar3 = new UnitCar("VW", 100, 560);
            var uniDriver3 = new UnitDriver("Lada", unitCar);

            raceEntry.AddDriver(uniDriver);
            raceEntry.AddDriver(uniDriver2);
            raceEntry.AddDriver(uniDriver3);

            var result = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(100, result);
        }
    }
}