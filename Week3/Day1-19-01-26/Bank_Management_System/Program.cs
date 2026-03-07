using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BankManagementSystem
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string AccountHolder { get; set; }
        protected decimal Balance { get; set; }

        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Successfully deposited ${amount}. New Balance: ${Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew ${amount}. Remaining Balance: ${Balance}");
            }
        }

        public abstract void DisplaySummary();
    }

    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; private set; }

        public SavingsAccount(string accNo, string holder, decimal balance, decimal rate)
            : base(accNo, holder, balance)
        {
            InterestRate = rate;
        }

        public void ApplyInterest()
        {
            decimal interest = Balance * (InterestRate / 100);
            Balance += interest;
            Console.WriteLine($"Interest of ${interest} applied at {InterestRate}%. New Balance: ${Balance}");
        }

        public override void DisplaySummary()
        {
            Console.WriteLine($"[Savings] Holder: {AccountHolder} | ID: {AccountNumber} | Balance: ${Balance} | Rate: {InterestRate}%");
        }
    }

    public class CheckingAccount : BankAccount
    {
        private const decimal TransactionFee = 1.50m;

        public CheckingAccount(string accNo, string holder, decimal balance)
            : base(accNo, holder, balance) { }

        public override void Withdraw(decimal amount)
        {
            decimal totalAmount = amount + TransactionFee;
            if (totalAmount > Balance)
            {
                Console.WriteLine("Insufficient funds to cover withdrawal and fee ($1.50).");
            }
            else
            {
                Balance -= totalAmount;
                Console.WriteLine($"Withdrew ${amount} (Fee: ${TransactionFee}). Balance: ${Balance}");
            }
        }

        public override void DisplaySummary()
        {
            Console.WriteLine($"[Checking] Holder: {AccountHolder} | ID: {AccountNumber} | Balance: ${Balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            SavingsAccount savings = new SavingsAccount("S101", "Alice Johnson", 1000.00m, 3.5m);
            CheckingAccount checking = new CheckingAccount("C202", "Bob Smith", 500.00m);


            Console.WriteLine("--- Bank Management System ---");

            savings.Deposit(500);
            savings.ApplyInterest();

            checking.Withdraw(100);

            Console.WriteLine("\n--- Account Summaries ---");
            
            savings.DisplaySummary();
            checking.DisplaySummary();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
