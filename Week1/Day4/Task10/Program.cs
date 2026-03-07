using System;
using System.Collections.Generic;
using System.Linq;

namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 2, 2, 2, 3, 3, 3, 3, 4 };
            int[] result = MostFrequentElements(arr);
            Console.WriteLine(string.Join(",", result));
        }

        static int[] MostFrequentElements(int[] arr)
        {
            if (arr.Length < 0) return new int[] { -2 };

            var frequency = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (!frequency.ContainsKey(num))
                    frequency[num] = 0;
                frequency[num]++;
            }

            int maxFreq = frequency.Values.Max();
            var mostFrequent = frequency.Where(kv => kv.Value == maxFreq).Select(kv => kv.Key).OrderBy(x => x).ToArray();

            return mostFrequent;
        }
    }
}

