using System;

namespace ConsoleAppEmp
{
    internal class Researcher
    {
        public static string OrganizationName;
        public static int ResearcherCount;

        public string ResearcherName;
        public string FieldOfResearch;
        public string TopicOfResearch;
        public int TimeLine;
        public int Budget;

        static Researcher()
        {
            OrganizationName = "Capgemini Lab";
            ResearcherCount = 0;
            Console.WriteLine("Static Constructor Called");
        }

        public Researcher(string researcherName, string fieldOfResearch,
                          string topicOfResearch, int timeLine, int budget)
        {
            ResearcherName = researcherName;
            FieldOfResearch = fieldOfResearch;
            TopicOfResearch = topicOfResearch;
            TimeLine = timeLine;
            Budget = budget;

            ResearcherCount++; 
        }

        public void PrintDetails()
        {
            Console.WriteLine("Researcher Name : " + ResearcherName);
            Console.WriteLine("Field           : " + FieldOfResearch);
            Console.WriteLine("Topic           : " + TopicOfResearch);
            Console.WriteLine("Timeline        : " + TimeLine + " months");
            Console.WriteLine("Budget          : " + Budget);
            Console.WriteLine("Organization    : " + OrganizationName);
        }

        public static void ShowResearcherCount()
        {
            Console.WriteLine("Total Researchers: " + ResearcherCount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Researcher researcher1 = new Researcher(
                "John Doe",
                "Computer Science",
                "Artificial Intelligence",
                18,
                75000
            );

            Researcher researcher2 = new Researcher(
                "Siddharth",
                "Software Development",
                "DotNet C#",
                12,
                60000
            );

            researcher1.PrintDetails();
            Console.WriteLine();

            researcher2.PrintDetails();
            Console.WriteLine();

            Researcher.ShowResearcherCount();

            Console.ReadLine();
        }
    }
}
