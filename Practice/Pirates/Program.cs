namespace P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cities = new();
            string cityInput;
            while ((cityInput = Console.ReadLine())!="Sail")
            {
                string[] tokents = cityInput.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = tokents[0];
                int population = int.Parse(tokents[1]);
                int gold = int.Parse(tokents[2]);

                if (!cities.ContainsKey(cityName))
                {
                    cities[cityName] = new int[2];

                }
                cities[cityName][0] += population;
                cities[cityName][1] += gold;

            }


            string eventInput;
            while ((eventInput=Console.ReadLine())!="End")
            {
                string[] tokents = eventInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string action = tokents[0];
                string cityName = tokents[1];

                if (action == "Plunder")
                {
                    int people = int.Parse(tokents[2]);
                    int gold = int.Parse(tokents[3]);

                    cities[cityName][0]-=people;
                    cities[cityName][1]-=gold;

                    Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[cityName][0] <= 0 || cities[cityName][1]<=0)
                    {
                        cities.Remove(cityName);
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(tokents[2]);

                    if (gold<=0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    cities[cityName][1] += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {cities[cityName][1]} gold.");
                }


            }

            if (cities.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach ((string cityName, int[] cityData) in cities)
                {
                    int people = cityData[0];
                    int gold = cityData[1];
                    Console.WriteLine($"{cityName} -> Population: {people} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
/*
Tortuga||345000||1250
Santo Domingo||240000||630
Havana||410000||1100
Sail
Plunder=>Tortuga=>75000=>380
Prosper=>Santo Domingo=>180
End
 */