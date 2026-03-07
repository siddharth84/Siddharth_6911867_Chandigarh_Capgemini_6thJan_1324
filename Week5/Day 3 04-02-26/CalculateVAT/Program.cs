using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter product type (M/V/C/D): ");
        char type = char.ToUpper(Console.ReadLine()[0]);

        Console.Write("Enter price: ");
        double price = double.Parse(Console.ReadLine());

        double vatRate = 0;

        switch (type)
        {
            case 'M': vatRate = 5; break;
            case 'V': vatRate = 12; break;
            case 'C': vatRate = 6.25; break;
            case 'D': vatRate = 6; break;
            default:
                Console.WriteLine("Invalid product type");
                return;
        }

        double vatAmount = price * vatRate / 100;
        double total = price + vatAmount;

        Console.WriteLine("VAT: " + vatAmount);
        Console.WriteLine("Total Price: " + total);
    }
}
