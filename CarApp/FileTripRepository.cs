using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace car_app
{
    public class FileTripRepository : ITripRepository
    {
        private readonly string _filePath;

        public FileTripRepository(string filePath)
        {
            _filePath = filePath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
                File.Create(_filePath).Close();
        }

        public List<Trip> GetTripsForCar(string regNr)
        {
            return File.ReadAllLines(_filePath)
                      .Select(Trip.FromString)
                      .Where(t => t.CarRegNr == regNr)
                      .ToList();
        }

        public void AddTrip(Trip trip)
        {
            File.AppendAllText(_filePath, trip.ToString() + Environment.NewLine);
        }

        public void DeleteTrip(Trip trip)
        {
            var trips = File.ReadAllLines(_filePath)
                          .Select(Trip.FromString)
                          .Where(t => t.ToString() != trip.ToString())
                          .ToList();

            File.WriteAllLines(_filePath, trips.Select(t => t.ToString()));
        }
    }
}