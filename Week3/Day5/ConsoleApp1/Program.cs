using System;
using System.Collections.Generic;
using System.Linq;
class Dog
{
    public string Name { get; set; }
    public int Age { get; set; }
}
class demo
{
    static void Main()
    {
        List<Dog> dogs = new List<Dog>() {
         new Dog { Name = "Rex", Age = 4 },
         new Dog { Name = "Sean", Age = 0 },
         new Dog { Name = "Stacy", Age = 3 }
      };
        var newDogsList = dogs.Select(x => new { Age = x.Age, FirstLetter = x.Name[0] });
        foreach (var item in newDogsList)
        {
            Console.WriteLine(item);
        }
        Console.Read();
    }
}

