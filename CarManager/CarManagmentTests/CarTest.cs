using CarManager;
using NUnit.Framework;
using System;

namespace CarManagmentTests
{
   [TestFixture]
    public class CarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            Assert.AreEqual("Vw",car.Make);
            Assert.AreEqual("Golf",car.Model);
            Assert.AreEqual(2, car.FuelConsumption);
            Assert.AreEqual(100,car.FuelCapacity);
            Assert.AreEqual(0,car.FuelAmount);
        }
        
        [Test]
        public void ModelShouldThrowArgExWhenNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Car("Vw", null, 2, 100));
        }
       
        [Test]
        public void MakeShouldThrowArgExWhenNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Car(null,"Golf", 2, 100));
        }
       
        [Test]
        public void FuelConsumptionShouldThrowArgExWhenIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("Vw", "Golf", -10, 100));

        }

        [Test]
        public void FuelConsumptionShouldThrowArgExWhenIsZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("Vw", "Golf", 0, 100));
        }
        [Test]
        public void FuelCapacityShouldThrowArgExWhenIsZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("Vw", "Golf", 2, 0));
        }
       
        [Test]
        public void FuelCapacityShouldThrowArgExWhenIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("Vw", "Golf", 2, -10));
        }
       
        [Test]
        [TestCase(null, "Golf", 2, 100)]
        [TestCase("Vw", null, 2, 100)]
        [TestCase("Vw", "Golf", 0, 100)]
        [TestCase("Vw", "Golf", -2, 100)]
        [TestCase("Vw", "Golf", 2, 0)]
        [TestCase("Vw", "Golf", 2, -10)]
        public void ValidateAllProperties(string make, string model, double fuelConsumption, double fuelCapacity)
        {

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShouldRefuelNormally()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            car.Refuel(10);
            double expectedFuelAmount = 10;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
       
        [Test]
        public void ShouldRefuelUntillTotalFuelCapacity()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            car.Refuel(150);
            double expectedFuelAmount = 100;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        
        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void ShouldRefuelThrowArgExWhenInputAmountIsBelloZero(double inputAmount)
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }
       
        [Test]
        public void ShouldDriveNormally()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            car.Refuel(20);
            car.Drive(20);
            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
       
        [Test]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelAmountIsNotEnough()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}
