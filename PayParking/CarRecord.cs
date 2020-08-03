namespace PayParking
{
    using System;

    internal class CarRecord
    {
        internal static readonly int RonOwedPerFirstHour = 10;
        internal static readonly int RonOwedPerHourPastFirst = 5;

        internal static string PriceReport
            => $"First hour: {RonOwedPerFirstHour} lei :: Each hour past the first: {RonOwedPerHourPastFirst} lei";

        internal string Registration { get; }
        internal DateTime EnterTime { get; }
        internal TimeSpan TimeElapsed => DateTime.UtcNow - EnterTime;
        internal string TimeElapsedAsString => TimeElapsed.ToString(@"hh\h\:mm\m\:ss\s");
        internal int RonOwed => RonOwedPerFirstHour + RonOwedPerHourPastFirst * (int)Math.Floor(TimeElapsed.TotalHours);

        internal CarRecord(string registrationNumber)
        {
            EnterTime = DateTime.UtcNow;
            Registration = registrationNumber;
        }

        internal bool HasRegistration(string value)
            => value.Equals(Registration, StringComparison.OrdinalIgnoreCase);
    }
}