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

            // Test fuel car
            FuelCar fuelCar = new FuelCar("Toyota", "Corolla", "EF12345", 50, 50, 20);
            fuelCar.StartEngine();
            fuelCar.Drive(100);


        }

        [TestMethod]
        public void TestFuelTaxi()
        {
            // Test taxi
            FuelCar fuelCar = new FuelCar("Toyota", "Corolla", "EF12345", 50, 15, 20);
            Taxi fuelTaxi = new Taxi("Toyota", "Corolla", "EF12345", 40, 12, 4, fuelCar);

            ElectricCar electricCar = new ElectricCar("Tesla", "Model S", "CD67890", 100, 5, 20);
            Taxi electricTaxi = new Taxi("Tesla", "Model S", "CD67890", 40, 10, 4, electricCar);

            //Test begge taxityper
            Console.WriteLine("Tester Fuel Taxi:");
            TestTaxi(fuelTaxi);

            Console.WriteLine("Tester Electric Taxi:");
            TestTaxi(electricTaxi);

        }
        [TestMethod]
        private void TestTaxi(Taxi taxi)
        {
            taxi.StartEngine();
            taxi.StartMeter();
            taxi.Drive(10);
            double fare = taxi.CalculateFare(10, 15);
            taxi.StopMeter();
            taxi.StopEngine();

            Console.WriteLine($"Taxi Odometer: {taxi.Odometer} km, Fare: {fare:F2} kr");
            Console.WriteLine($"Taxi Energy level: {taxi.EnergyLevel:F2} L or kWh");
        }
    }
}
