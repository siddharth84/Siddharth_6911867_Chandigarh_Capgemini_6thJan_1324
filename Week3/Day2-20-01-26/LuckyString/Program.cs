using System;
class LuckyString
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) return;

        int n = int.Parse(input);
        string s = Console.ReadLine();

        if (n > s.Length)
        {
            Console.WriteLine("Invalid");
            return;
        }

        bool isLucky = false;

        for (int i = 0; i <= s.Length - n; i++)
        {
            string sub = s.Substring(i, n);

            if (IsPsgOnly(sub))
            {
                if (HasConsecutive(sub, n / 2))
                {
                    isLucky = true;
                    break;
                }
            }
        }

        Console.WriteLine(isLucky ? "Yes" : "No");
    }

    static bool IsPsgOnly(string sub)
    {
        foreach (char c in sub)
        {
            if (c != 'P' && c != 'S' && c != 'G') return false;
        }
        return true;
    }

    static bool HasConsecutive(string sub, int threshold)
    {
        if (sub.Length == 0) return false;

        int currentCount = 1;
        for (int i = 1; i < sub.Length; i++)
        {
            if (sub[i] == sub[i - 1])
            {
                currentCount++;
                if (currentCount >= threshold) return true;
            }
            else
            {
                currentCount = 1;
            }
        }
        return currentCount >= threshold;
    }
}
