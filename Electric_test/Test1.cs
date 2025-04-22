using car_app;

namespace Electric_test
{
    [TestClass]
    public class ElectricTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            // Test electric car
            ElectricCar electricCar = new ElectricCar("Tesla", "Model S", "CD67890", 1000, 100, 5);
            electricCar.StartEngine();
            electricCar.Drive(50);
            Console.WriteLine($"ElectricCar Odometer: {electricCar.Odometer} km, Battery left: {electricCar.Batterylevel:F2} kWh");

            // Test fuel car
            FuelCar fuelCar = new FuelCar("Toyota", "Corolla", "EF12345", 50, 50, 20);
            fuelCar.StartEngine();
            fuelCar.Drive(100);
            Console.WriteLine($"FuelCar Odometer: {fuelCar.Odometer} km, Fuel level: {fuelCar.FuelLevel:F2} L");

            // Test taxi
            Taxi taxi = new Taxi("Mercedes", "E-Class", "TX11223", 49.0, 12.3, 7.5);
            taxi.StartEngine();
            taxi.StartMeter();
            taxi.Drive(20);
            double fare = taxi.CalculateFare(20, 30);
            taxi.StopMeter();
            Console.WriteLine($"Taxi Odometer: {taxi.Odometer} km, Fare: {fare:F2} kr.");

        }
    }
}
