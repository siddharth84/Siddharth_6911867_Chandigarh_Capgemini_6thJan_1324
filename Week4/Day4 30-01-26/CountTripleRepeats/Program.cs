namespace CountTripleRepeats
{
    class Program
    {
        static int CountTripleRepeats(string input)
        {
            int count = 0;

            for (int i = 0; i <= input.Length - 3; i++)
            {
                if (input[i] == input[i + 1] && input[i] == input[i + 2])
                {
                    count++;
                    i += 2; 
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int res1=CountTripleRepeats("abcdddefggg"); 
            int res2=CountTripleRepeats("ertyyyrere");

            Console.WriteLine( res1 + " " + res2 );

        }
    }
}
