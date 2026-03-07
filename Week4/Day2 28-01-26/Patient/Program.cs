using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        List<Patient> PatientList = new List<Patient>();
        int noOfPatient, i;
        string name, city, illness;
        int age;

        Console.WriteLine("Enter the number of Patient");
        noOfPatient = int.Parse(Console.ReadLine());
        Patient patient = new Patient();
        for (i = 0; i < noOfPatient; i++)
        {
            Console.WriteLine("Enter Patient " + (i + 1) + " details:");
            Console.WriteLine("Enter the name");
            name = Console.ReadLine();
            Console.WriteLine("Enter the age");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the illness");
            illness = Console.ReadLine();
            Console.WriteLine("Enter the city");
            city = Console.ReadLine();
            patient = new Patient(name, age, illness, city);
            PatientList.Add(patient);
        }
        int choice;
        PatientBO employeeBO = new PatientBO();
        string opt;
        do
        {
            Console.WriteLine("Enter your choice:\n1)Display Employee Details\n2)Display Youngest Employee Details");
            Console.WriteLine("3)Display Employees from City");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter employee name:");
                    name = Console.ReadLine();
                    employeeBO.DisplayPatientDetails(PatientList, name);
                    break;

                case 2:
                    employeeBO.DisplayYoungestPatientDetails(PatientList);
                    break;

                case 3:
                    Console.WriteLine("Enter city");
                    city = Console.ReadLine();
                    employeeBO.displayPatientFromCity(PatientList, city);
                    break;

                default:
                    break;

            }
            Console.WriteLine("Do you want to continue(Yes/No)?");
            opt = Console.ReadLine();
        } while (opt.Equals("Yes"));
    }
}

