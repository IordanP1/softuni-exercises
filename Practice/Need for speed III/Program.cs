namespace Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            Dictionary<string, int[]> cars = new();
            for (int i = 0; i < carsCount; i++)
            {
                string[] inputCars = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string carName = inputCars[0];
                int milage = int.Parse(inputCars[1]);
                int fuel = int.Parse(inputCars[2]);
                if (!cars.ContainsKey(carName))
                {
                    cars[carName] = new int[2];
                }
                cars[carName][0] += milage;
                cars[carName][1] += fuel;
            }


            string command = "";
            while ((command=Console.ReadLine())!= "Stop")
            {
                string[] action = command.Split(" : ");
                string operation = action[0];

                switch (operation)
                {
                    case "Drive":
                        string carName = action[1];
                        int distance = int.Parse(action[2]);
                        int fuel = int.Parse(action[3]);
                        if (cars[carName][1] <= fuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            cars[carName][0] += distance;
                            cars[carName][1] -=fuel;
                            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }
                        if (cars[carName][1]>=100000)
                        {
                            cars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }
                            break;
                    case "Refuel":
                        string carToRefuel = action[1];
                        int fuelToAdd = int.Parse(action[2]);
                        int currentFuel = cars[carToRefuel][1];
                        if (currentFuel + fuelToAdd >= 75)
                        {
                            fuelToAdd = 75 - currentFuel;
                            cars[carToRefuel][1] = 75;
                            Console.WriteLine($"{carToRefuel} refueled with {fuelToAdd} liters");
                        }
                        else
                        {
                            cars[carToRefuel][1] += fuelToAdd;
                            Console.WriteLine($"{carToRefuel} refueled with {fuelToAdd} liters");
                        }
                        break;
                    case "Revert":
                        string carToRevert = action[1];
                        int kilometers = int.Parse(action[2]);

                        cars[carToRevert][0] -= kilometers;
                        if (cars[carToRevert][0] < 10000)
                        {
                            cars[carToRevert][0] = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{carToRevert} mileage decreased by {kilometers} kilometers");
                        }
                        break;
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
/*
3
Audi A6|38000|62
Mercedes CLS|11000|35
Volkswagen Passat CC|45678|5
Drive : Audi A6 : 543 : 47
Drive : Mercedes CLS : 94 : 11
Drive : Volkswagen Passat CC : 69 : 8
Refuel : Audi A6 : 50
Revert : Mercedes CLS : 500
Revert : Audi A6 : 30000
Stop
 */
