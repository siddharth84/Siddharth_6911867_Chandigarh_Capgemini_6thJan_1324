using System.Globalization;

namespace IsValidTime
{
    class Program
    {
        static bool IsValidTime(string time)
        {
            return DateTime.TryParseExact(
                time,
                "hh:mm tt",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            if(IsValidTime("10:30 am"))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            if (IsValidTime("13:45 pm"))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
