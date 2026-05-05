

namespace The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = "";
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] action = command.Split("|");
                string operation = action[0];

                switch (operation)
                {
                    case "Move":
                        input = Move(action[1], input);
                        //Console.WriteLine(input);
                        break;

                    case "Insert":
                        input = input.Insert(int.Parse(action[1]), action[2]);
                        //Console.WriteLine(input);
                        break;
                    case "ChangeAll":
                        input = ChangeAll(action[1], action[2], input);
                        break;

                } 
            }
            Console.WriteLine($"The decrypted message is: {input}");
        }

         static string ChangeAll(string substring, string replacment, string input)
        {
            input = input.Replace(substring, replacment);
            //Console.WriteLine(input);
            return input;

        }

        static string Move(string substring,string message)
        {
            int index = int.Parse(substring);
            if (index >= 0 && index < message.Length)
            {
                string beforeSubstring = message.Substring(0, index);
                string afterSubstring = message.Substring(index);
                message = afterSubstring + beforeSubstring;
                //Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("error");
            }
            return message;
        }
    }
}
/*
owyouh
Move|2
Move|3
Insert|3|are
Insert|9|?
Decode
 */
