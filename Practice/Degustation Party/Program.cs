namespace Degustation_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guestMeals = new();
            int dislikeFoodCount = 0;
            string command = "";
            while ((command=Console.ReadLine())!= "Stop")
            {
                string[] tokens = command.Split("-",StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string guestName = tokens[1];
                string meal = tokens[2];
                if (action == "Like")
                {
                    if (!guestMeals.ContainsKey(guestName))
                    {
                        guestMeals[guestName] = new List<string>();
                    }
                    if (!guestMeals[guestName].Contains(meal))
                    {
                        guestMeals[guestName].Add(meal);
                    }
                }
                else if (action == "Dislike")
                {
                    if (!guestMeals.ContainsKey(guestName))
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                    else if (!guestMeals[guestName].Contains(meal))
                    {
                        Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        guestMeals[guestName].Remove(meal);
                        dislikeFoodCount++;
                        Console.WriteLine($"{guestName} doesn't like the {meal}.");
                    }
                }

            }
            foreach (var gm in guestMeals)
            {
                string guest = gm.Key;
                List<string> meals = gm.Value;
                Console.WriteLine($"{guest}: {string.Join(", ",meals)}");
            }
            Console.WriteLine($"Unliked meals: {dislikeFoodCount}");
        }
    }
}
/*
Like-Krisi-shrimps
Like-Krisi-soup
Like-Penelope-dessert
Like-Misho-salad
Stop
 */