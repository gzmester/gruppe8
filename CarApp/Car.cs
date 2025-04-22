using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_app
{
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

        public virtual void Drive(double distance)
        {
            Console.WriteLine($"Driving {distance} km.");
            Odometer += (int)distance;

        }
    }
}
