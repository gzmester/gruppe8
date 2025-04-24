using System;
using car_app;

public class ElectricCar : Car, IEnergy
{
    public double EnergyLevel { get; set; }    // Batteriniveau i kWh (nuværende)
    public double MaxEnergy { get; set; }      // Batterikapacitet i kWh (maks)

    public double KmPerKWh { get; } // km per kWh  

    public ElectricCar(string brand, string model, string licensePlate, double maxEnergy, double initialEnergyLevel, double kmPerKWh)
        : base(brand, model, licensePlate)
    {
        MaxEnergy = maxEnergy;
        EnergyLevel = initialEnergyLevel;
        KmPerKWh = kmPerKWh;
    }

    public void Refill(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Mængden skal være positiv");

        EnergyLevel += amount;
        if (EnergyLevel > MaxEnergy)
            EnergyLevel = MaxEnergy;
    }

    public void UseEnergy(double km)
    {
        double energyNeeded = km / KmPerKWh;

        if (energyNeeded > EnergyLevel)
            throw new InvalidOperationException("Ikke nok strøm på batteriet");

        EnergyLevel -= energyNeeded;
    }

    public override bool CanDrive(double km)
    {
        if (!IsEngineRunning)
            throw new InvalidOperationException("Motoren skal være tændt for at køre.");

        return EnergyLevel >= km / KmPerKWh;
    }
}