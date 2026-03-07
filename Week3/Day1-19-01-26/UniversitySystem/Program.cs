using System;
using System.Collections.Generic;

namespace UniversitySystem
{
    public abstract class Person
    {
        public string ID { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Person(string id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
        }

        public abstract void DisplayProfile();
    }

    public class Student : Person
    {
        public List<Course> EnrolledCourses { get; private set; } = new List<Course>();

        public Student(string id, string name, string email) : base(id, name, email) { }

        public void Enroll(Course course)
        {
            EnrolledCourses.Add(course);
            Console.WriteLine($"{Name} successfully enrolled in {course.CourseName}");
        }

        public override void DisplayProfile()
        {
            Console.WriteLine($"[Student] {Name} (ID: {ID}) | Email: {Email}");
            Console.WriteLine("Schedules: " + (EnrolledCourses.Count > 0
                ? string.Join(", ", EnrolledCourses.ConvertAll(c => c.CourseName))
                : "No courses enrolled"));
        }
    }

    public class Professor : Person
    {
        public string Department { get; set; }
        public List<Course> TaughtCourses { get; private set; } = new List<Course>();

        public Professor(string id, string name, string email, string dept) : base(id, name, email)
        {
            Department = dept;
        }

        public void AssignCourse(Course course)
        {
            TaughtCourses.Add(course);
            Console.WriteLine($"Prof. {Name} is now teaching {course.CourseName}");
        }

        public override void DisplayProfile()
        {
            Console.WriteLine($"[Professor] {Name} | Dept: {Department} | Email: {Email}");
        }
    }

    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public Course(string code, string name)
        {
            CourseCode = code;
            CourseName = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Course cs101 = new Course("CS101", "Introduction to Programming");
            Course math202 = new Course("MATH202", "Calculus II");

            Professor prof = new Professor("P99", "Dr. Alan Turing", "turing@uni.edu", "Computer Science");
            Student student = new Student("S123", "Grace Hopper", "grace@student.edu");

            prof.AssignCourse(cs101);
            student.Enroll(cs101);
            student.Enroll(math202);

            Console.WriteLine("\n--- University Profiles ---");
            prof.DisplayProfile();
            Console.WriteLine("---------------------------");
            student.DisplayProfile();

            Console.ReadKey();
        }
    }
}
