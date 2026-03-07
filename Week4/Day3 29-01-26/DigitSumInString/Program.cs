using System.Text.RegularExpressions;

namespace DigitSumInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string input=Console.ReadLine();

            string st = Regex.Replace(input, @"\D", "");
            int count = 0;
            foreach(char c in st)
            {
                count += (c - '0');
            }
            Console.WriteLine( count);
        }
    }
}
