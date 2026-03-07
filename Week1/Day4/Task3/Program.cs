namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any Number");
            int number = Convert.ToInt32(Console.ReadLine());
            int output1 = 0;
            if(number < 0)
            {
                output1 = -1;
            }
            else
            {
                output1 = number.ToString().Length;
            }
            Console.WriteLine(output1);
        }
    }
}
