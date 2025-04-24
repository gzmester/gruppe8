using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_app;

public class Taxi : Car, IEnergy
{
    public double StartPrice { get; private set; } // i kr
    public double PricePerKm { get; private set; } // i kr. per km
    public double PricePerMinute { get; private set;} // i kr. per minut
    public bool MeterStarted { get; private set; } // true hvis taxameteret er startet

    public Taxi(string brand, string model, string licensePlate, double startPrice, double pricePerKm, double pricePerMinute) : base(brand, model, licensePlate)
    {
        StartPrice = startPrice;
        PricePerKm = pricePerKm;
        PricePerMinute = pricePerMinute;
        MeterStarted = false;
        
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

    public override bool CanDrive(){

    return MeterStarted && IsEngineOn; // Kan kun køre hvis motoren er tændt og taxameteret er startet

    }

    public double CalculateFare(double distance, double minutes)
    {
      
        if (!MeterStarted)
        {
            throw new InvalidOperationException("Taxameteret er ikke startet.");
        }
        double fare = StartPrice + (PricePerKm * distance) + (PricePerMinute * minutes);
        return fare;
        Console.WriteLine($"Total pris: {fare} kr.");

    }

    public override void UpdateEnergyLevel(double distance)
    {
        // Ingen opdatering af energiniveau for taxa, da det er en generel bil
        // Kan implementeres hvis taxaen er elektrisk eller hybrid
    }

    public override double CalculateConsumption(double distance)
    {
        // Ingen specifik brændstofberegning for taxa, da det er en generel bil
        // Kan implementeres hvis taxaen er elektrisk eller hybrid
        return 0;
    }



}