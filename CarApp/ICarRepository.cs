using System.Collections.Generic;

namespace car_app
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car? GetCar(string licensePlate);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(string licensePlate);
    }
}