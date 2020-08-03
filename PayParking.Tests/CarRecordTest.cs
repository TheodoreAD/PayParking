namespace PayParking.Tests
{
    using Xunit;

    public class CarRecordTest
    {
        [Fact]
        public void HasRegistration_CaseInsensitive()
        {
            const string registration = "B10xyz";
            var carRecord = new CarRecord(registration);

            Assert.True(carRecord.HasRegistration(registration.ToLower()));
            Assert.True(carRecord.HasRegistration(registration.ToUpper()));
        }

        [Fact]
        public void RonOwed_FirstHour()
        {
            var carRecord = new CarRecord("B10ABC");

            Assert.Equal(carRecord.RonOwed, CarRecord.RonOwedPerFirstHour);
        }
    }
}