using System.Text;

namespace CompressString
{
    internal class Program
    {
        static string CompressString(string s)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;

            for (int i = 1; i <= s.Length; i++)
            {
                if (i < s.Length && s[i] == s[i - 1])
                    count++;
                else
                {
                    sb.Append(s[i - 1]).Append(count);
                    count = 1;
                }
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string st = Console.ReadLine();

            int res = CompressString(st);
            Console.WriteLine(res);
        }
    }
}
