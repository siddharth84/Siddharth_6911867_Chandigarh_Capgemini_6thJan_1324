namespace Sum_of_Primes
{
    internal class Program
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                int[] input1 = { 1, 2, 3, 4, 5 };
                int input2 = 5;
                int output1 = 0;

                if (input2 < 0) output1 = -2;
                else if (input1.Any(x => x < 0)) output1 = -1;
                else
                {
                    bool foundPrime = false;
                    foreach (int num in input1)
                    {
                        if (IsPrime(num))
                        {
                            output1 += num;
                            foundPrime = true;
                        }
                    }
                    if (!foundPrime) output1 = -3;
                }
                Console.WriteLine("Output1: " + output1);
            }

            static bool IsPrime(int n)
            {
                if (n <= 1) return false;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                    if (n % i == 0) return false;
                return true;
            }
        }
}
