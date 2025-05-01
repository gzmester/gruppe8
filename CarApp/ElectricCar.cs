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

    // Serialiser ElectricCar-specifikke data
    public override string ToString()
    {
        return $"ElectricCar;{Brand};{Model};{LicensePlate};{Odometer};{EnergyLevel};{MaxEnergy};{KmPerKWh}";
    }
    // Deserialiser fra streng
    public static new ElectricCar FromString(string input)
    {
        var parts = input.Split(';');
        var typeMarker = parts[0]; // "ElectricCar"
        var brand = parts[1];
        var model = parts[2];
        var licensePlate = parts[3]; // Rettet fra parts[2] til parts[3]
        var odometer = double.Parse(parts[4]); // Rettet fra parts[3] til parts[4]
        var energyLevel = double.Parse(parts[5]);
        var maxEnergy = double.Parse(parts[6]);
        var kmPerKWh = double.Parse(parts[7]); // Tilføjet parts[7]

        var car = new ElectricCar(
            brand: brand,
            model: model,
            licensePlate: licensePlate,
            maxEnergy: maxEnergy,
            initialEnergyLevel: energyLevel,
            kmPerKWh: kmPerKWh
        )
        {
            Odometer = odometer
        };
        return car;
    }
}