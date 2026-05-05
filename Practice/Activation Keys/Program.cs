



namespace Activation_Keys
{
    internal class Program
    {
        public static string ActivationKey { get; set; }
        static void Main(string[] args)
        {
             ActivationKey = Console.ReadLine();


            string command;
            while ((command=Console.ReadLine())!= "Generate")
            {
                string[] arguments = command.Split(">>>");
                string operation = arguments[0];


                switch (operation)
                {
                    case "Contains":
                        Contains(arguments[1]);

                        break;

                    case "Flip":
                        if (arguments[1]=="Upper")
                        {
                            FlipUpper(int.Parse(arguments[2]), int.Parse(arguments[3]));
                        }
                        else if (arguments[1]=="Lower")
                        {
                            FlipLower(int.Parse(arguments[2]), int.Parse(arguments[3]));
                        }
                        break;

                    case "Slice":
                        Slice(int.Parse(arguments[1]), int.Parse(arguments[2]));
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {ActivationKey}");
        }

        private static void Slice(int startIndex, int endIndex)
        {
            //string firstPart = ActivationKey.Substring(0, startIndex);
            //string secondPart = ActivationKey.Substring(endIndex);
            //ActivationKey = firstPart + secondPart;
            ActivationKey = ActivationKey.Remove(startIndex, endIndex - startIndex);
            Console.WriteLine(ActivationKey);
        }

        private static void FlipLower(int startIndex, int endIndex)
        {

            string prefix = ActivationKey.Substring(0, startIndex);
            string middle = ActivationKey.Substring(startIndex, endIndex - startIndex).ToLower();
            string suffix = ActivationKey.Substring(endIndex);

            ActivationKey = prefix + middle + suffix;
            Console.WriteLine(ActivationKey);
        }

        private static void FlipUpper(int startIndex, int endIndex)
        {
            string prefix = ActivationKey.Substring(0, startIndex);
            string middle = ActivationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
            string suffix = ActivationKey.Substring(endIndex);

            ActivationKey = prefix + middle + suffix;
            Console.WriteLine(ActivationKey);
        }

        static void Contains(string substring)
        {
            if (ActivationKey.Contains(substring))
            {
                Console.WriteLine($"{ActivationKey} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }
    }
}
/*
abcdefghijklmnopqrstuvwxyz
Slice>>>2>>>6
Flip>>>Upper>>>3>>>14
Flip>>>Lower>>>5>>>7
Contains>>>def
Contains>>>deF
Generate
 */