using System;

public class CarSpeed
{
    public string speed;
}

public class SpeedInvalidException : Exception
{
    public SpeedInvalidException(string message) : base(message)
    {
    }
}

public class CarSpeedImplementation
{
    public string setCarSpeed(CarSpeed sp, int spd)
    {
        try
        {
            if (spd < 30 || spd > 90)
            {
                throw new SpeedInvalidException("Speed must be between 30 and 90.");
            }

            sp.speed = spd.ToString();
            return "Speed set successfully: " + sp.speed;
        }
        catch (SpeedInvalidException ex)
        {
            return "Error: " + ex.Message;
        }
    }
}

class Program
{
    static void Main()
    {
        CarSpeed car = new CarSpeed();
        CarSpeedImplementation impl = new CarSpeedImplementation();

        Console.WriteLine(impl.setCarSpeed(car, 50));  
        Console.WriteLine(impl.setCarSpeed(car, 100)); 
    }
}