namespace ReverseString
{
    internal class Program
    {
        static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string st = Console.ReadLine();
            st=ReverseString(st);
            Console.WriteLine(st);
        }
    }
}
