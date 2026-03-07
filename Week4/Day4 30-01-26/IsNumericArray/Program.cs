namespace IsNumericArray
{
    class Program
    {
        static int IsNumericArray(string[] arr)
        {
            foreach (string s in arr)
            {
                if (!double.TryParse(s, out _))
                    return -1;
            }
            return 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int res1=IsNumericArray(new string[] { "23", "24.5" });
            Console.WriteLine(res1);
            int res2 = IsNumericArray(new string[] { "23", "one" }); 
            Console.WriteLine(res2);

        }
    }
}
