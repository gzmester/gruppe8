using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_app;

public class Taxi : Car
{
    public double StartPrice { get; private set; } // i kr
    public double PricePerKm { get; private set; } // i kr. per km
    public double PricePerMinute { get; private set;} // i kr. per minut
    public bool MeterStarted { get; private set; } // true hvis taxameteret er startet

    private IEnergy car; // Komposition

    public Taxi(string brand, string model, string licensePlate, double startPrice, double pricePerKm, double pricePerMinute, IEnergy car) : base(brand, model, licensePlate)
    {
        StartPrice = startPrice;
        PricePerKm = pricePerKm;
        PricePerMinute = pricePerMinute;
        MeterStarted = false;
        this.car = car;
        
    }


    public void StartMeter()
    {
        if (MeterStarted)
        {
            throw new InvalidOperationException("Taxameteret er allerede startet.");
        }
        MeterStarted = true;
        Console.WriteLine("Taxameteret er startet.");
    }

    public void StopMeter()
    {
        if (!MeterStarted)
        {
            throw new InvalidOperationException("Taxameteret er ikke startet.");
        }
        MeterStarted = false;
        Console.WriteLine("Taxameteret er stoppet.");
    }

    public override bool CanDrive(double km){

    return MeterStarted && IsEngineRunning; // Kan kun køre hvis motoren er tændt og taxameteret er startet

    }

    // IEnergy Interface
    public double EnergyLevel
    {
        get { return car.EnergyLevel; }
        set { car.EnergyLevel = value; }
    }

    public double MaxEnergy
    {
        get { return car.MaxEnergy; }
        set { car.MaxEnergy = value; }
    }

    public void Refill(double amount)
    {
        car.Refill(amount);
    }

    public void UseEnergy(double km)
    {
        car.UseEnergy(km);
    }



    public double CalculateFare(double distance, double minutes)
    {
      
        if (!MeterStarted)
        {
            throw new InvalidOperationException("Taxameteret er ikke startet.");
        }
        double fare = StartPrice + (PricePerKm * distance) + (PricePerMinute * minutes);
        Console.WriteLine($"Total pris: {fare} kr.");
        return fare;
    }

    private IEnergy _energy;

    public override void Drive(double km)
    {
        if (!IsEngineRunning)
        {
            Console.WriteLine("Motoren er ikke startet.");
            return;
        }
        if (!CanDrive(km))
        {
            Console.WriteLine("Ikke nok energi til at køre");
            return;
        }
        _energy.UseEnergy(km);
        Odometer += (int)km;
        Console.WriteLine($"Kørt {km} km. Ny kilometerstand: {Odometer} km.");
    }



}