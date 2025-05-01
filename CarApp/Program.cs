using System;
using System.Collections.Generic;
using car_app;

namespace car_app
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Slet gamle filer før test
            if (File.Exists("cars.txt")) File.Delete("cars.txt");
            if (File.Exists("trips.txt")) File.Delete("trips.txt");

            // Opret repositories
            var carRepo = new FileCarRepository("cars.txt");
            var tripRepo = new FileTripRepository("trips.txt");

            // Tilføj testbiler
            var tesla = new ElectricCar("Tesla", "Model S", "EL12345", 100, 80, 6.5);
            var toyota = new FuelCar("Toyota", "Corolla", "FUEL678", 50, 60, 15);

            carRepo.AddCar(tesla);
            carRepo.AddCar(toyota);

            // Hent og vis alle biler
            Console.WriteLine("Alle biler i systemet:");
            foreach (var car in carRepo.GetAllCars())
            {
                if (car is ElectricCar ec)
                {
                    Console.WriteLine($"[EL-BIL] {ec.Brand} {ec.Model}, Reg.nr: {ec.LicensePlate}, Batteri: {ec.EnergyLevel}/{ec.MaxEnergy} kWh");
                }
                else if (car is FuelCar fc)
                {
                    Console.WriteLine($"[BENZIN] {fc.Brand} {fc.Model}, Reg.nr: {fc.LicensePlate}, Tank: {fc.EnergyLevel}/{fc.MaxEnergy} liter");
                }
            }

            // Tilføj en tur til Tesla'en
            var teslaTrip = new Trip
            {
                CarRegNr = "EL12345",
                Distance = 120,
                Date = DateTime.Now.Date,
                StartTime = TimeSpan.FromHours(8),
                EndTime = TimeSpan.FromHours(10)
            };

            tripRepo.AddTrip(teslaTrip);

            // Hent og vis ture for Tesla'en
            Console.WriteLine("\nTure for Tesla EL12345:");
            var trips = tripRepo.GetTripsForCar("EL12345");
            foreach (var trip in trips)
            {
                Console.WriteLine($"Dato: {trip.Date:dd/MM/yyyy}, " +
                                  $"Distance: {trip.Distance} km, " +
                                  $"Tid: {trip.StartTime:hh\\:mm} til {trip.EndTime:hh\\:mm}");
            }

            // Test: Hent en enkelt bil
            var foundCar = carRepo.GetCar("FUEL678");
            Console.WriteLine("\nFandt bil: " + foundCar?.LicensePlate);

            // Test: Slet en bil
            carRepo.DeleteCar("FUEL678");
            Console.WriteLine("\nBiler efter sletning af FUEL678:");
            foreach (var car in carRepo.GetAllCars())
            {
                Console.WriteLine(car.LicensePlate);
            }
        }
    }
}