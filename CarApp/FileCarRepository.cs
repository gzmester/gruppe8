using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace car_app
{
    public class FileCarRepository : ICarRepository
    {
        private readonly string _filePath;

        public FileCarRepository(string filePath)
        {
            _filePath = filePath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
                File.Create(_filePath).Close();
        }

        public IEnumerable<Car> GetAllCars()
        {
            var lines = File.ReadAllLines(_filePath);
            return lines.Select(line =>
            {
                var parts = line.Split(';');
                var type = parts[0];
                return type switch
                {
                    "FuelCar" => FuelCar.FromString(line) as Car, // Eksplicit cast til Car
                    "ElectricCar" => ElectricCar.FromString(line) as Car,
                    _ => throw new InvalidDataException("Ukendt biltype")
                };
            });
        }

        public Car? GetCar(string licensePlate)
        {
            return GetAllCars().FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public void AddCar(Car car)
        {
            File.AppendAllText(_filePath, car.ToString() + Environment.NewLine);
        }

        public void UpdateCar(Car updatedCar)
        {
            var cars = GetAllCars().ToList();
            var index = cars.FindIndex(c => c.LicensePlate == updatedCar.LicensePlate);
            if (index != -1)
            {
                cars[index] = updatedCar;
                File.WriteAllLines(_filePath, cars.Select(c => c.ToString()));
            }
        }

        public void DeleteCar(string licensePlate)
        {
            var cars = GetAllCars().Where(c => c.LicensePlate != licensePlate).ToList();
            File.WriteAllLines(_filePath, cars.Select(c => c.ToString()));
        }
    }
}