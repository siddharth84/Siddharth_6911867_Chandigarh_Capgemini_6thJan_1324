namespace RemoveDuplicates
{
    class Program
    {
        static string RemoveDuplicates(string input)
        {
            string result = "";

            foreach (char c in input)
            {
                if (c == ' ')
                {
                    result += " ";
                }
                if (!result.Contains(c))
                    result += c;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string res = RemoveDuplicates("hi this is my book");
            Console.WriteLine( res);
        }
    }
}
