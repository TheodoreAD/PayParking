namespace PayParking
{
    using System;
    using System.Linq;

    internal static class Program
    {
        internal static string LastCommand { get; set; } = "";
        internal static Garage Garage { get; set; }

        [STAThread]
        private static void Main()
        {
            Console.WriteLine("Welcome to PayParking!");
            Console.WriteLine("Commands: enter <registration>, leave <registration>, list, price, quit");
            Garage = new Garage(10);
            while (!LastCommand.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    Console.WriteLine("Waiting for user input...");
                    LastCommand = Console.ReadLine();
                    if (LastCommand.Length == 0) { continue; }
                    GetActionFromCommand(LastCommand)();
                }
                catch (Exception ex) when (ex is System.IO.IOException || ex is OutOfMemoryException)
                {
                }
            }
        }

        private static Action GetActionFromCommand(string value)
        {
            var parts = value.Split();
            var command = parts.First();
            var arg = parts.ElementAtOrDefault(1);
            return command switch
            {
                "enter" when !string.IsNullOrEmpty(arg) => () => Garage.AddCar(arg),
                "leave" when !string.IsNullOrEmpty(arg) => () => Garage.RemoveCar(arg),
                "list" when string.IsNullOrEmpty(arg) => () => Console.WriteLine(Garage.CarsReport),
                "price" when string.IsNullOrEmpty(arg) => () => Console.WriteLine(CarRecord.PriceReport),
                "quit" when string.IsNullOrEmpty(arg) => () => Console.WriteLine("Thank you for using PayParking. Exiting..."),
                _ => () => Console.WriteLine("Command not understood, please try again.")
            };
        }
    }
}