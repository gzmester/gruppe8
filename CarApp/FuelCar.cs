namespace car_app;

public class FuelCar : Car, IEnergy
{
    public double EnergyLevel { get; set; }   
    public double MaxEnergy { get; set; }

    public double KmPerLiter;

    public FuelCar(string brand, string model, string licensePlate, double energyLevel, double maxEnergy,
        double kmPerLiter) : base(brand, model, licensePlate)
    {
        EnergyLevel = energyLevel;
        MaxEnergy = maxEnergy;
        KmPerLiter = kmPerLiter;
    }

    public void Refill(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Mængden skal være positiv");
        }

        EnergyLevel += amount;
        if (EnergyLevel > MaxEnergy)
        {
            EnergyLevel = MaxEnergy;
        }
    }

    public void UseEnergy(double km)
    {
        double fuelNeeded = km / KmPerLiter;

        if (fuelNeeded > EnergyLevel)
        {
            throw new InvalidOperationException("Ikke nok strøm på batteriet");
        }

        EnergyLevel -= fuelNeeded;
    }

    public override bool CanDrive(double km)
    {
        if (base.IsEngineRunning & EnergyLevel >= km / KmPerLiter)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"FuelCar;{Brand};{Model};{LicensePlate};{Odometer};{EnergyLevel};{MaxEnergy};{KmPerLiter}";
    }

    // Deserialiser fra streng
    public static new FuelCar FromString(string input)
    {
        var parts = input.Split(';');
        var typeMarker = parts[0]; // "FuelCar"
        var brand = parts[1];      // Brand (string)
        var model = parts[2];      // Model (string)
        var licensePlate = parts[3]; // LicensePlate (string)
        var odometer = double.Parse(parts[4]); // Odometer (double)
        var energyLevel = double.Parse(parts[5]); // EnergyLevel (double)
        var maxEnergy = double.Parse(parts[6]); // MaxEnergy (double)
        var kmPerLiter = double.Parse(parts[7]); // KmPerLiter (double)

        var car = new FuelCar(
            brand: brand,
            model: model,
            licensePlate: licensePlate,
            energyLevel: energyLevel,
            maxEnergy: maxEnergy,
            kmPerLiter: kmPerLiter
        )
        {
            Odometer = odometer // Opdater odometer
        };
        return car;
    }
}