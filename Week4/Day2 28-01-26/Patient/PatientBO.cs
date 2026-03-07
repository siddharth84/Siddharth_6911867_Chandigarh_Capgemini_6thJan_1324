using System.Collections.Generic;
using System;
using System.Linq;

class PatientBO
{
    public void DisplayPatientDetails(List<Patient> patientList, string name)
    {
        List<Patient> p1 = (from p in patientList
                             where p.Name == name
                             select p).ToList();
        int le = p1.Count;

        if (le < 0)
        {
            Console.Write("Patient named {0} not found", name); ;
        }
        else
        {

            Console.WriteLine("Name                 Age   IllNess          City");
            foreach (Patient x1 in p1)
            {
                Console.WriteLine(x1.ToString());
            }

        }

    }

    public void DisplayYoungestPatientDetails(List<Patient> patientList)
    {
        int age = (from p in patientList
                   select p.Age).Min();
        var x = from p in patientList
                where p.Age == age
                select p;

        Console.WriteLine("Name                 Age   IllNess          City");
        foreach (var x1 in x)
        {
            Console.WriteLine(x1.ToString());
        }

    }

    public void displayPatientFromCity(List<Patient> patientList, string cName)
    {

        List<Patient> p1 = (from p in patientList
                             where p.City == cName
                             select p).ToList();
        int le = p1.Count;

        if (le < 0)
        {
            Console.Write("Patient named {0} not found", cName); ;
        }
        else
        {

            Console.WriteLine("Name                 Age   Designation          City");
            foreach (Patient x1 in p1)
            {
                Console.WriteLine(x1.ToString());
            }

        }

    }
}
