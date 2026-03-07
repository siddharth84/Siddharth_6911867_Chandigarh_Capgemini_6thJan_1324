using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class UserProgramCode
{
    public static string[] getEmployee(string[] input1, string input2)
    {
        Regex regex = new Regex("^[a-zA-Z ]+$");

        if (!regex.IsMatch(input2))
        {
            Console.WriteLine("Invalid Input");
            return null;
        }

        foreach (string s in input1)
        {
            if (!regex.IsMatch(s))
            {
                Console.WriteLine("Invalid Input");
                return null;
            }
        }

        List<string> employees = new List<string>();
        HashSet<string> designations = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (int i = 0; i < input1.Length - 1; i += 2)
        {
            string employee = input1[i];
            string designation = input1[i + 1];

            designations.Add(designation);

            if (designation.Equals(input2, StringComparison.OrdinalIgnoreCase))
            {
                employees.Add(employee);
            }
        }

        if (employees.Count == 0)
        {
            Console.WriteLine($"No employee for {input2} designation");
            return null;
        }

        if (designations.Count == 1)
        {
            Console.WriteLine($"All employees belong to same {input2} designation");
            return null;
        }

        return employees.ToArray();
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input1 = new string[n];

        for (int i = 0; i < n; i++)
        {
            input1[i] = Console.ReadLine();
        }

        string input2 = Console.ReadLine();

        string[] result = UserProgramCode.getEmployee(input1, input2);

        if (result != null)
        {
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

