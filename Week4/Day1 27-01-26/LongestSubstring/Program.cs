namespace LongestSubstring
{
    internal class Program
    {
        static int longestSeq(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int maxLen = 0, left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                if (map.ContainsKey(s[right]))
                    left = Math.Max(left, map[s[right]] + 1);

                map[s[right]] = right;
                maxLen = Math.Max(maxLen, right - left + 1);
            }
            return maxLen;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string st = Console.ReadLine();

            int res = longestSeq(st);
            Console.WriteLine(res);
        }
    }
}
