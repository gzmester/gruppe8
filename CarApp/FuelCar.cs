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
}