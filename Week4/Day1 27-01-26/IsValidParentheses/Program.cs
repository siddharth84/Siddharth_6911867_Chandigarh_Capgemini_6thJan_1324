namespace IsValidParentheses
{
    internal class Program
    {
        static bool IsValidParentheses(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>
    {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' }
    };

            foreach (char c in s)
            {
                if (pairs.ContainsValue(c))
                    stack.Push(c);
                else if (pairs.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[c])
                        return false;
                }
            }
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string st=Console.ReadLine();

            if (IsValidParentheses(st))
            {
                Console.WriteLine("is valid");
            }
            else
            {
                Console.WriteLine("is invalid");
            }
        }
    }
}
