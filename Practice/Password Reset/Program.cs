using System.Text.RegularExpressions;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count  = int.Parse(Console.ReadLine());
            string pattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
            for (int i = 0; i < count; i++)
            {
                string barcode = Console.ReadLine();
                if (Regex.IsMatch(barcode, pattern))
                {
                    char[] digits = barcode.Where(c => char.IsDigit(c)).ToArray();
                    string product = digits.Length > 0
                        ? new(digits)
                        : "00";

                    Console.WriteLine($"Product group: {product}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
            }
        }
    }
}
/*
6
@###Val1d1teM@###
@#ValidIteM@#
##InvaliDiteM##
@InvalidIteM@
@#Invalid_IteM@#
@#ValiditeM@#
 */