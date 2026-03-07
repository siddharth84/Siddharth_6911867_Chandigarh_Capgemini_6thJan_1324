namespace PalindromeCheck
{
    internal class Program
    {
        static bool isPalindrom(string s)
        {
            int l = 0, r = s.Length-1;
            while (l < r)
            {
                if(s[l] != s[r])
                {
                    return false;
                }
                l++;
                r--;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter String");
            string st=Console.ReadLine();
            if (isPalindrom(st))
            {
                Console.Write("isPalindrom");
            }
            else
            {
                Console.WriteLine("Not Palindrom");
            }
        }
    }
}
