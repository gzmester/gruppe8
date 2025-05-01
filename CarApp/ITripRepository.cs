using System.Collections.Generic;

namespace car_app
{
    public interface ITripRepository
    {
        List<Trip> GetTripsForCar(string regNr);
        void AddTrip(Trip trip);
        void DeleteTrip(Trip trip);
    }
}