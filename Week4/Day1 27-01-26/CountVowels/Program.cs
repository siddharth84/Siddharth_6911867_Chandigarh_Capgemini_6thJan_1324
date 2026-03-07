namespace CountVowels
{
    internal class Program
    {
        static int CountVowels(string s)
        {
            int cnt = 0;
            foreach (char c in s.ToLower())
            {
                if ("aeiou".Contains(c))
                    cnt++;
            }
            return cnt;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter String");
            string st = Console.ReadLine();
            int cnt = CountVowels(st);
            Console.WriteLine(cnt);
        }
    }
}
