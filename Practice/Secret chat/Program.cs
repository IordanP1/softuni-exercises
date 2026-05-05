namespace Secret_Chat;

internal class Program
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();

        string command = "";
        while ((command = Console.ReadLine()) != "Reveal")
        {
            string[] tokens = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];
            switch (action)
            {
                case "InsertSpace":
                    message = InstertSpace(int.Parse(tokens[1]),message);
                    break;
                case "Reverse":
                    message = Reverse(tokens[1],message);
                    break;
                case "ChangeAll":
                    message = ChangeAll(tokens[1], tokens[2],message);
                    break;
            }
        }
        Console.WriteLine($"You have a new text message: {message}");
    }

    private static string ChangeAll(string substrig,string replacment,string message)
    {
      message = message.Replace(substrig, replacment);
        Console.WriteLine(message);

        return message;
    }

    static string Reverse(string substring,string message)
    {
        int index = message.IndexOf(substring);
        if (index != -1) 
        {
            string beforeSubstring = message.Substring(0, index);
            string afterSubstring = message.Substring(index+ substring.Length);
            string reversedSubstring = new string(substring.Reverse().ToArray());

           message = beforeSubstring + reversedSubstring + afterSubstring;
            Console.WriteLine(message);

        }
        else
        {
            
            Console.WriteLine("error");
            
        }
        return message;
    }

    static string InstertSpace(int index,string message)
    {
        message = message.Insert(index, " ");
        Console.WriteLine(message);

        return message;
    }
}
/*
heVVodar!gniV
ChangeAll:|:V:|:l
Reverse:|:!gnil
InsertSpace:|:5
Reveal
 */