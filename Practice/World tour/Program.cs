
namespace World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = "";
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] action = command.Split(":");

                switch (action[0])
                {
                    case "Add Stop":
                        int index = int.Parse(action[1]);
                        string newString = action[2];
                        if (index >= 0 && index <= input.Length)
                        {
                            input = input.Insert(index, newString);
                        }
                        Console.WriteLine(input);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(action[1]);
                        int endIndex = int.Parse(action[2]);
                        if (startIndex >= 0 && endIndex < input.Length && startIndex <= input.Length)
                        {
                            input = input.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        Console.WriteLine(input);
                        break;
                    case "Switch":
                        string oldString = action[1];
                        string newstring = action[2];
                        if (oldString != newstring)
                        {
                            input = input.Replace(oldString, newstring);
                        }
                        Console.WriteLine(input);
                        break;
                }

            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");

        }
    }
        


}

/*
Hawai::Cyprys-Greece
Add Stop:7:Rome
Remove Stop:11:16
Switch:Hawai:Bulgaria
Travel
*/

/*
Albania:Bulgaria:Cyprus:Deuchland
Add Stop:3:Nigeria
Remove Stop:4:8
Switch:Albania: Azərbaycan
Travel
 */
