using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<int, int> grades = new Dictionary<int, int>
        {
            { 101, 85 },
            { 102, 45 },
            { 103, 72 },
            { 104, 38 }
        };

        Func<Dictionary<int, int>, double> averageGrade =
            g => g.Values.Average();

        Console.WriteLine("Average Grade: " + averageGrade(grades));

        Predicate<int> isAtRisk = grade => grade < 50;

        Console.WriteLine("\nAt-risk students:");
        foreach (var student in grades)
        {
            if (isAtRisk(student.Value))
                Console.WriteLine($"Roll No: {student.Key}, Grade: {student.Value}");
        }

        Console.WriteLine("\nUpdating grade for Roll No 102...");
        grades[102] = 60;

        Console.WriteLine("Re-evaluated At-risk students:");
        foreach (var student in grades)
        {
            if (isAtRisk(student.Value))
                Console.WriteLine($"Roll No: {student.Key}, Grade: {student.Value}");
        }
    }
}

