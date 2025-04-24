using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_app;

public class ElectricCar : Car, IEnergy
{
    public double BatteryCapacity { get; private set; } // i kWh
    public double Batterylevel { get; private set; } // i kWh
    public double KmPerKWh { get; } // km per kWh  


    public ElectricCar(string brand, string model, string licensePlate, double batteryCapacity, double batterylevel, double kmPerKWh) : base(brand, model, licensePlate)
    {
        BatteryCapacity = batteryCapacity;
        Batterylevel = batterylevel;
        KmPerKWh = kmPerKWh;
    }

    public double EnergyLevel => Batterylevel;
    public double MaxEnergy => BatteryCapacity;

    public void Refill(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Mængden skal være positiv");
        }

        Batterylevel += amount;
        if (Batterylevel > BatteryCapacity)
        {
            Batterylevel = BatteryCapacity;
        }
    }

    public void UseEnergy(double km)
    {
        double energyNeeded = km / KmPerKWh;
        if (energyNeeded > Batterylevel)
        {
            throw new InvalidOperationException("Ikke nok strøm på batteriet");
        }
        
        Batterylevel -= energyNeeded;
    }

    public override bool CanDrive(double km)
    {

        if (!IsEngineRunning)
        {
            throw new InvalidOperationException("Motoren skal være tændt for at køre.");
        }
        return (Batterylevel >= km / KmPerKWh);
    }
}