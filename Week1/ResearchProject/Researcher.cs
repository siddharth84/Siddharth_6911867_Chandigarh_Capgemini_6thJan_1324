using System;

namespace ResearchProject
{
    interface IResearch
    {
        void PrintDetails();
    }

    internal abstract class Researcher
    {
        public static string OrganizationName = "Capgemini Lab";
        public static int ResearcherCount = 0;

        public string Name;
        public string Field;
        public int TimeLine;
        public int Budget;

        //public abstract void PrintDetails();
    }

    internal class ProjectResearcher : Researcher, IResearch
    {
        public string Topic;

        public ProjectResearcher(string name, string field, string topic, int timeline, int budget)
        {
            Name = name;
            Field = field;
            Topic = topic;
            TimeLine = timeline;
            Budget = budget;
            ResearcherCount++;
        }

        public void PrintDetails()
        {
            Console.WriteLine("Researcher Name : " + Name);
            Console.WriteLine("Field           : " + Field);
            Console.WriteLine("Topic           : " + Topic);
            Console.WriteLine("Timeline        : " + TimeLine + " months");
            Console.WriteLine("Budget          : " + Budget);
            Console.WriteLine("Organization    : " + OrganizationName);
        }
    }
}
