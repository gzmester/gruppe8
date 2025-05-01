using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_app
{
    public abstract class Car : IDrivable
    {
        public string Brand { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public double Odometer { get; protected set; }
        public bool IsEngineRunning { get; private set; }

        public Car(string brand, string model, string licensePlate)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            Odometer = 0;
            IsEngineRunning = false;
        }

        public void StartEngine()
        {
            IsEngineRunning = true;
            Console.WriteLine("Engine started.");
        }

        public void StopEngine()
        {
            IsEngineRunning = false;
            Console.WriteLine("Engine stopped.");
        }

        public virtual void Drive(double km)
        {
            if (!IsEngineRunning)
            {
                Console.WriteLine("Motoren er ikke startet.");
                return;
            }

            if (!CanDrive(km))
            {
                Console.WriteLine("ikke nok energi til at køre");
                return;
            }
            Odometer += (int)km;
            Console.WriteLine($"Kørt {km} km. Ny kilometerstand: {Odometer} km.");

        }

        public abstract bool CanDrive(double km);

        public override string ToString()
        {
            return $"{Brand};{Model};{LicensePlate};{Odometer}";
        }

        // Underklasser skal håndtere deserialisering
        public static Car FromString(string input)
        {
            throw new NotImplementedException("Brug konkrete subklasser (f.eks. FuelCar.FromString())");
        }
    }
}
