using System;

namespace ResearchProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Researcher r1 = new ProjectResearcher(
                "John Doe",
                "Computer Science",
                "Artificial Intelligence",
                18,
                75000
            );

            Researcher r2 = new ProjectResearcher(
                "Siddharth",
                "Software Development",
                "DotNet C#",
                12,
                60000
            );

            IResearch i1 = (IResearch)r1;
            i1.PrintDetails();
            Console.WriteLine();

            r2.PrintDetails();
            Console.WriteLine();

            Console.WriteLine("Total Researchers: " + Researcher.ResearcherCount);

            Console.ReadLine();
        }
    }
}
