using System;

class UserProgramCode
{
    public static int GetCount(int size, string[] input1, char input2)
    {
        int count = 0;
        input2 = Char.ToLower(input2);

        foreach (string str in input1)
        {
            foreach (char ch in str)
            {
                if (!Char.IsLetter(ch))
                    return -2;
            }

            if (Char.ToLower(str[0]) == input2)
                count++;
        }

        if (count == 0)
            return -1;

        return count;
    }
}

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string[] arr = new string[size];

        for (int i = 0; i < size; i++)
        {
            arr[i] = Console.ReadLine();
        }

        char ch = Console.ReadLine()[0];

        int result = UserProgramCode.GetCount(size, arr, ch);

        if (result == -1)
            Console.WriteLine("No elements Found");
        else if (result == -2)
            Console.WriteLine("Only alphabets should be given");
        else
            Console.WriteLine(result);
    }
}
