namespace PayParking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Garage
    {
        internal ICollection<CarRecord> Cars { get; }
        internal int MaximumCapacity { get; }
        internal int CurrentCapacity => Cars.Count();
        internal bool IsFull => CurrentCapacity == MaximumCapacity;

        internal string CarsReport => string.Join("\n", Cars
            .Select(x => $"{x.Registration} :: Spent {x.TimeElapsedAsString} :: Owes {x.RonOwed} lei")
            .ToList()
        );

        internal bool HasCar(string registration) => Cars.Any(x => x.HasRegistration(registration));

        internal Garage(int maximumCapacity)
        {
            MaximumCapacity = maximumCapacity;
            Cars = new List<CarRecord>();
        }

        internal bool AddCar(string registration)
        {
            if (IsFull)
            {
                Console.WriteLine("Entry failed, garage is full.");
                return false;
            }
            if (HasCar(registration))
            {
                Console.WriteLine($"Entry failed, car with registration {registration} already in garage.");
                return false;
            }
            Cars.Add(new CarRecord(registration));
            Console.WriteLine("Entry succeeded.");
            return true;
        }

        internal CarRecord RemoveCar(string registration)
        {
            var car = Cars.FirstOrDefault(x => x.HasRegistration(registration));
            if (car is null)
            {
                Console.WriteLine($"Leave failed, car with registration {registration} not found in garage.");
                return null;
            }
            Cars.Remove(car);
            Console.WriteLine(
                $"Car with registration {registration} left after {car.TimeElapsedAsString}, paid {car.RonOwed} lei."
            );
            return car;
        }
    }
}