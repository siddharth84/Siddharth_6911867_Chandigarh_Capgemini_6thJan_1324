using NUnit.Framework;
using CalculatorApp;
namespace TestProject1
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator Calc;

        [SetUp]
        public void SetUp()
        {
            Calc = new Calculator();
        }
        [Test]
        public void Add_TwoNumber_ReturnSum()
        {
            int a=5,b=6;
            int Result= Calc.Add(a,b);
            Assert.That(Result, Is.EqualTo(11));
        }
        [Test]
        public void Subteact_TwoNumber_ReturnDifference()
        {
            int a = 6, b = 2;
            int Result = Calc.Subtract(a, b);
            Assert.That(Result, Is.EqualTo(4));
        }
        [Test]
        public void Multiply_TwoNumber_ReturnMultiplication()
        {
            int a = 6, b = 2;
            int Result = Calc.Multiply(a, b);
            Assert.That(Result, Is.EqualTo(12));
        }
        [Test]
        public void Divide_TwoNumber_ReturnDivision()
        {
            int a = 6, b = 2;
            double Result = Calc.Divide(a, b);
            Assert.That(Result, Is.EqualTo(3));
        }
    }


    //public class Tests
    //{
    //    [SetUp]
    //    public void Setup()
    //    {
    //    }

    //    [Test]
    //    public void Test1()
    //    {
    //        Assert.Pass();
    //    }
    //}
}
