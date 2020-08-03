namespace PayParking.Tests
{
    using System.Linq;
    using Xunit;

    public class GarageTest
    {
        [Theory]
        [InlineData(new string[] { "B10XYZ" }, new string[] { "B10XYZ" }, 1)]
        [InlineData(new string[] { "B10XYZ", "B10XYZ", "B30XYZ" }, new string[] { "B10XYZ", "B30XYZ" }, 2)]
        [InlineData(new string[] { "B10XYZ", "B20KLM", "B30XYZ" }, new string[] { "B10XYZ", "B20KLM", "B30XYZ" }, 3)]
        public void AddCars_Count(
            string[] inputCarRegistrations,
            string[] expectedCarRegistrations,
            int expectedCarCount
        )
        {
            var garage = new Garage(10);
            foreach (string carRegistration in inputCarRegistrations)
            {
                garage.AddCar(carRegistration);
            }
            var garageCarRegistrations = garage.Cars.Select((x) => x.Registration).ToArray();
            Assert.Equal(garageCarRegistrations.Count(), expectedCarCount);
            Assert.Equal(garage.CurrentCapacity, expectedCarCount);
            Assert.Equal(garageCarRegistrations, expectedCarRegistrations);
        }

        [Theory]
        [InlineData("B10XYZ", "B10XYZ", false)]
        [InlineData("B10XYZ", "B20KLM", true)]
        public void AddCars_Duplicates(
            string firstCarRegistration,
            string secondCarRegistration,
            bool expectedSecondAddResult
        )
        {
            var garage = new Garage(10);
            Assert.True(garage.AddCar(firstCarRegistration));
            Assert.Equal(garage.AddCar(secondCarRegistration), expectedSecondAddResult);
        }

        [Theory]
        [InlineData("B10XYZ", "B10XYZ", false)]
        [InlineData("B10XYZ", "B20KLM", true)]
        public void RemoveCars_Mismatch(string addedRegistration, string removedRegistration, bool expectedIsNullReturn)
        {
            var garage = new Garage(10);
            garage.AddCar(addedRegistration);
            var car = garage.RemoveCar(removedRegistration);
            Assert.Equal(car is null, expectedIsNullReturn);
        }

        [Fact]
        public void Garage_CapacityNotExceeded()
        {
            var capacity = 10;
            var garage = new Garage(10);
            for (int i = 0; i < capacity - 1; i++)
            {
                Assert.True(garage.AddCar(i.ToString()));
            }
            Assert.False(garage.IsFull);
            Assert.True(garage.AddCar("10"));
            Assert.True(garage.IsFull);
            Assert.False(garage.AddCar("11"));
            Assert.True(garage.IsFull);
        }
    }
}