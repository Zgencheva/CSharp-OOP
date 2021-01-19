using System;

namespace NeedForSpeed
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            Vehicle veh = new Vehicle(45, 10);
            veh.Drive(50);
            Console.WriteLine(veh.Fuel);

            Motorcycle mot = new Motorcycle(45, 10);
            mot.Drive(50);
            Console.WriteLine(mot.Fuel);

            Car car = new Car(45, 10);
            car.Drive(50);
            Console.WriteLine(car.Fuel);

            RaceMotorcycle race = new RaceMotorcycle(45, 10);
            race.Drive(50);
            Console.WriteLine(race.Fuel);

            CrossMotorcycle crossMotor = new CrossMotorcycle(45, 10);
            crossMotor.Drive(50);
            Console.WriteLine(crossMotor.Fuel);

            FamilyCar famcar = new FamilyCar(45, 10);
            famcar.Drive(50);
            Console.WriteLine(famcar.Fuel);

            SportCar sportCar = new SportCar(45, 10);
            sportCar.Drive(50);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
