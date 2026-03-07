namespace AreAnagrams
{
    internal class Program
    {
        static bool AreAnagrams(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            char[] a1 = s1.ToCharArray();
            char[] a2 = s2.ToCharArray();

            Array.Sort(a1);
            Array.Sort(a2);

            return new string(a1) == new string(a2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string st1 = Console.ReadLine();
            string st2 = Console.ReadLine();

            if (AreAnagrams(st1, st2))
            {
                Console.Write("AreAnagram");
            }
            else
            {
                Console.WriteLine("Not Anagram");
            }

        }
    }
}
