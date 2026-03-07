namespace FirstNon_RepeatingCharacter
{
    internal class Program
    {
        static char Func(string s)
        {
            Dictionary<char,int> dict = new Dictionary<char,int>();
            foreach (char c in s)
            {
                dict[c] = dict.ContainsKey(c) ? dict[c]+1:1;
            }
            foreach(char c in s)
            {
                if (dict[c] == 1)
                {
                    return c;
                }
            }
            return '_';
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string st = Console.ReadLine();
            char c = Func(st);

            Console.WriteLine(c);
        }
    }
}
