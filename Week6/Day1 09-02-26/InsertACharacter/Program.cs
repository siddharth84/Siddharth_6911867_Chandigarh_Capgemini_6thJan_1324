using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string text = Console.ReadLine();

        Console.Write("Enter character to insert: ");
        char ch = Console.ReadLine()[0];

        Console.Write("Enter position (0-based index): ");
        int pos = int.Parse(Console.ReadLine());

        if (pos < 0 || pos > text.Length)
        {
            Console.WriteLine("Invalid position");
            return;
        }

        string result = text.Insert(pos, ch.ToString());

        Console.WriteLine("Result: " + result);
    }
}
