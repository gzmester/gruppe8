namespace Electric_test
{
    [TestClass]
    public class ElectricTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ElectricCar electricCar = new ElectricCar("Tesla", "Model S", "CD67890", 1000, 100, 5);
            electricCar.StartEngine();
            electricCar.Drive(50);
            Console.WriteLine($"ElectricCar Odometer: {electricCar.Odometer} km, Battery left: {electricCar.Batterylevel:F2} kWh");



        }
    }
}
