namespace IsEligibleToVote
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int age=Convert.ToInt32(Console.ReadLine());
            if (age > 18)
            {
                Console.WriteLine("Is Eligible To Vote");
            }
            else
            {
                Console.WriteLine("Is Not Eligible To Vote");
            }
        }
    }
}
