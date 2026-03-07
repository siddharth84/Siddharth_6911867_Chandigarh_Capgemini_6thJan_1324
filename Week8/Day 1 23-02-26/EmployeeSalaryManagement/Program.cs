using System;
using System.Collections.Generic;

class Salary
{
    Dictionary<string, int> empList = new Dictionary<string, int>();

    public Salary()
    {
        empList.Add("Manager", 50000);
        empList.Add("Developer", 40000);
        empList.Add("Tester", 30000);
        empList.Add("HR", 25000);
    }

    public int totalSalary()
    {
        int total = 0;
        foreach (var emp in empList)
        {
            total += emp.Value;
        }
        return total;
    }

    public string getSalary(string designation)
    {
        if (empList.ContainsKey(designation))
        {
            return $"Salary of {designation} is {empList[designation]}";
        }
        else
        {
            return "Designation not found.";
        }
    }

    public void updateSalary(string designation, int newSalary)
    {
        if (empList.ContainsKey(designation))
        {
            empList[designation] = newSalary;
            Console.WriteLine("Salary updated successfully.");
        }
        else
        {
            Console.WriteLine("Designation not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Salary s = new Salary();

        Console.WriteLine("Total Salary: " + s.totalSalary());
        Console.WriteLine(s.getSalary("Developer"));

        s.updateSalary("Developer", 45000);
        Console.WriteLine(s.getSalary("Developer"));
    }
}