namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            PoliceStation policeStation = new PoliceStation();
            City city = new City(policeStation);
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            Taxi taxi3 = new Taxi("0003 CCC");

            PoliceCar policeCar1 = new PoliceCar("0001 CNP", true, policeStation );
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", true, policeStation);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", false, policeStation);
            policeStation.RegisterCar(policeCar1);
            policeStation.RegisterCar (policeCar2);
            policeStation.RegisterCar(policeCar3);

            Console.WriteLine(city.WriteMessage("Created"));
            Console.WriteLine(policeStation.WriteMessage("Created"));
            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(taxi3.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));
            Console.WriteLine(policeCar3.WriteMessage("Created"));

            city.RegisterTaxiLicense(taxi1);
            city.RegisterTaxiLicense(taxi2);
            city.RegisterTaxiLicense(taxi3);

            policeCar3.StartPatrolling();
            policeCar3.UseRadar(taxi1);

            taxi2.StartRide();
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            taxi2.StopRide();
            city.RemoveTaxiLicense(taxi2);
            policeCar2.EndPatrolling();
            policeCar3.EndPatrolling();

        }
    }
}
    

