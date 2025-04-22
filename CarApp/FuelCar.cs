namespace car_app;

public class FuelCar : Car
{
    public double FuelLevel { get; set; }
    public double TankCapacity { get; set; }
    double KmPerLiter { get; set; }

    public FuelCar(string brand, string model, string licensePlate, double fuelLevel, double tankCapacity,
        double kmPerLiter) : base(brand, model, licensePlate)
    {
        FuelLevel = fuelLevel;
        TankCapacity = tankCapacity;
        KmPerLiter = kmPerLiter;
    }

    public void Refuel(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Brændstof mængde skal være over 0.");
        }

        if (amount + FuelLevel > TankCapacity)
        {
            throw new ArgumentException("Der kan ikke fyldes mere brændstof på end tankens kapacitet.");
        }
        
        FuelLevel += amount;
    }

    public override void Drive(double distance)
    {
        base.StartEngine();
        if(!IsEngineOn)
        {
            throw new InvalidOperationException("Motoren skal være tændt for at køre.");
        }
        if (distance < 0)
        {
            throw new ArgumentException("Afstand skal være over 0.");
        }
        
        double fuelNeeded = distance / KmPerLiter;
        if (fuelNeeded > FuelLevel)
        {
            throw new InvalidOperationException("Ikke nok brændstof til at køre distancen.");
        }
        else
        {
            FuelLevel -= fuelNeeded;
            Odometer += distance;
            Console.WriteLine($"Tanken indeholder efter kørsel: {FuelLevel} liter");
        }
    }

    public override bool CanDrive()
    {
        if (base.IsEngineOn && FuelLevel > 0)
        {
            return true;
        }
        return false;
    }

    public override double CalculateConsumption(double distance)
    {
        double fuelNeeded = distance / KmPerLiter;
        return fuelNeeded;
    }

    public override void UpdateEnergyLevel(double distance)
    {
        double fuelNeeded = CalculateConsumption(distance);
        FuelLevel -=  fuelNeeded;
    }
}