using car_app;

public class ElectricCar : Car
{
    public double BatteryCapacity { get; set; } // i kWh
    public double Batterylevel { get; set; } // i procent
    public double KmPerKWh { get; set; } // km per kWh  


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

    public override void Drive(double distance){

        base.Drive(0); // Tjekker om motoren er tændt
        double energyNeeded = distance / KmPerKWh; // Energi der skal bruges for at køre distancen
        if(energyNeeded > BatteryCapacity){
            throw new InvalidOperationException("Ikke nok energi til at køre distancen.");
        }else{
            BatteryCapacity -= energyNeeded; // Opdaterer batterikapaciteten
            Odometer += distance; // Opdaterer kilometertælleren
            Console.WriteLine($"Batterikapacitet efter kørsel: {BatteryCapacity} kWh");
        }
    }


}