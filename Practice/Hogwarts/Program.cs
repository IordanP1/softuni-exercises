namespace Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string word = Console.ReadLine();
            string command = "";
            while ((command=Console.ReadLine())!= "Abracadabra")
            {
                string[] action = command.Split();

                switch (action[0])
                {
                    case "Abjuration":
                        word = word.ToUpper();
                        Console.WriteLine(word);
                        break;
                    case "Necromancy":
                        word = word.ToLower();
                        Console.WriteLine(word);
                        break;
                    case "Illusion":
                        int index = int.Parse(action[1]);
                        char letter = char.Parse(action[2]);
                        if (index >= 0 && index < word.Length) 
                        {
                            word = word.Substring(0, index)+letter +word.Substring(index+1);
                            Console.WriteLine("Done!");
                        }
                        else
                        {
                            
                            Console.WriteLine("The spell was too weak.");
                        }
                        break;
                    case "Divination":
                        string firstSubstring = action[1];
                        string secondsubstring = action[2];
                        if (firstSubstring!=secondsubstring)
                        {
                            word = word.Replace(firstSubstring, secondsubstring);
                            Console.WriteLine(word);
                        }
                        else
                        {

                        }
                        
                        break;
                    case "Alteration":
                        string substringtoRemove = action[1];
                        if (word.Contains(substringtoRemove))
                        {
                            word =word.Replace(substringtoRemove,"");
                            Console.WriteLine(word);
                        }
                        else
                        {

                        }
                            break;
                    default:
                        Console.WriteLine("The spell did not work!");
                        break;
                }
               
            }
            //Console.WriteLine(word);
        }
    }
}
