namespace BankAccountApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount(1000m);

            account.Deposit(500m);
            account.Withdraw(200m);

            Console.WriteLine($"Current Balance: {account.Balance}");
        }
    }
}
