namespace MissionToMars
{
    /*
     40, 40, 40, 40, 40, 40, 40 
     40, 50, 60, 20, 30, 5, 2 
     */

    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<int> solarEnergy = new Stack<int>(Console.ReadLine()
               .Split(", ",StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));
            Queue<int> dailyDistance = new Queue<int>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> recurses = new Dictionary<string, int>()
            {
                { "Iron",80},
                { "Titanium",90},
                { "Aluminium",100},
                { "Chlorine",60},
                { "Sulfur",70},
            };
            Queue<string> recurcesEnergy = new(recurses.Keys);
            List<string> colectedResurces = new List<string>();

            while (solarEnergy.Any()&&dailyDistance.Any()&&recurcesEnergy.Any())
            {
                int totaleneryAndDistance = solarEnergy.Pop() + dailyDistance.Dequeue();


                string recurceName = recurcesEnergy.Peek();

                int recurceKg = recurses[recurceName];
                if (totaleneryAndDistance>=recurceKg)
                {
                    colectedResurces.Add(recurcesEnergy.Dequeue());
                }
            }
            if (!recurcesEnergy.Any())
            {
                Console.WriteLine("Mission complete! All minerals have been collected.");
            }
            else
            {
                Console.WriteLine("Mission not completed! Awaiting further instructions from Earth.");
                    
            }
            if (colectedResurces.Any())
            {
                Console.WriteLine("Collected resources:");
                foreach (var recurce in colectedResurces)
                {
                    Console.WriteLine(recurce);
                }

            }
        }
    }
}
