using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_app;

public class ElectricCar : Car
{
    public double BatteryCapacity { get; private set; } // i kWh
    public double Batterylevel { get; } // i procent
    public double KmPerKWh { get; } // km per kWh  


    public ElectricCar(string brand, string model, string licensePlate, double batteryCapacity, double batterylevel, double kmPerKWh) : base(brand, model, licensePlate)
    {
        BatteryCapacity = batteryCapacity;
        Batterylevel = batterylevel;
        KmPerKWh = kmPerKWh;
    }


    public void Charge(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Batteri niveau skal være over 0.");
        }

        Batterylevel += amount;
        if (Batterylevel > 100)
        {
            Batterylevel = 100;
        }
    }

    public override bool CanDrive()
    {

        if (!IsEngineOn)
        {
            throw new InvalidOperationException("Motoren skal være tændt for at køre.");
        }
        return BatteryCapacity > 0; // Kan kun køre hvis batterikapaciteten er over 0
    }
    public override void UpdateEnergyLevel(double distance)
    {
            double energyNeeded = distance / KmPerKWh;
            if (energyNeeded > BatteryLevel)
                throw new InvalidOperationException("Ikke nok batteri.");
            BatteryLevel -= energyNeeded;
    }

    public override double CalculateConsumption(double distance)
    {
        return distance / KmPerKWh;
    }

    /*
    public override void Drive(double distance){
        base.StartEngine(); // Starter motoren
        if(!IsEngineOn)
        {
            throw new InvalidOperationException("Motoren skal være tændt for at køre.");
        }
        if (distance < 0)
        {
            throw new ArgumentException("Afstand skal være over 0.");
        }
        double energyNeeded = distance / KmPerKWh; // Energi der skal bruges for at køre distancen
        if(energyNeeded > BatteryCapacity){
            throw new InvalidOperationException("Ikke nok energi til at køre distancen.");
        }else{
            BatteryCapacity -= energyNeeded; // Opdaterer batterikapaciteten
            Odometer += distance; // Opdaterer kilometertælleren
            Console.WriteLine($"Batterikapacitet efter kørsel: {BatteryCapacity} kWh");
        }
    }
    */
}