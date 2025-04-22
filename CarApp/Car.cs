using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_app
{
    public abstract class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public bool IsEngineOn { get; private set; }
        public double Odometer { get; protected set; }

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

        public abstract bool CanDrive();

        public abstract void UpdateEnergyLevel(double amount);

        public abstract double CalculateConsumption(double distance);

        public virtual void Drive(double distance)
        {
            if (!IsEngineOn)
            {
                Console.WriteLine("Motoren er ikke startet.");
                return;
            }

            if (!CanDrive())
            {
                Console.WriteLine("ikke nok energi til at køre");
                return;
            }

            UpdateEnergyLevel(distance);
            Odometer += (int)distance;
            Console.WriteLine($"Kørt {distance} km. Ny kilometerstand: {Odometer} km.");

        }
    }
}
