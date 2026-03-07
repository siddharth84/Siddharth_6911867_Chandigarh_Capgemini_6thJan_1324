namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator cal = new Calculator();
            Console.WriteLine(cal.Add(3, 7));
            Console.WriteLine(cal.Subtract(9, 2));
            Console.WriteLine(cal.Multiply(3, 7));
            Console.WriteLine(cal.Divide(25, 5));
        }
    }
}
