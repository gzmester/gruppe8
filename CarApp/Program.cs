namespace car_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public bool IsEngineOn { get; private set; }
        public int Odometer { get; protected set; }

        public Car(string brand, string model, string licensePlate)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            IsEngineOn = false;
            Odometer = 0;
        }

        public void StartEngine()
        {
            IsEngineOn = true;
            Console.WriteLine("Engine started.");
        }

        public void StopEngine()
        {
            IsEngineOn = false;
            Console.WriteLine("Engine stopped.");
        }

    }
}