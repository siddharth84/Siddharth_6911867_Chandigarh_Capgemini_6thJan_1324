using System;
using System.Collections.Generic;
using System.Linq;

namespace CashFlowMinimizer
{
    // 1. Enum for Payment Modes (Optional, but using string for flexibility like your C++ code)
    public enum PaymentStatus { Pending, Completed, Failed }

    public class CashFlowException : Exception
    {
        public CashFlowException(string message) : base(message) { }
    }

    public abstract class Participant
    {
        public string Name { get; set; }
        public HashSet<string> PaymentModes { get; set; } = new HashSet<string>();
        public decimal NetAmount { get; set; }

        protected Participant(string name) => Name = name;
    }

    public class Bank : Participant
    {
        public Bank(string name) : base(name) { }
    }

    public class Transaction<T> where T : Participant
    {
        public T Debtor { get; set; }
        public T Creditor { get; set; }
        public decimal Amount { get; set; }
        public string Mode { get; set; }
    }

    public interface ISettlementStrategy
    {
        IEnumerable<Transaction<Bank>> Settle(List<Bank> banks);
    }

    public delegate void TransactionLoggedHandler(string message);

    public class CashFlowEngine
    {
        private readonly ISettlementStrategy _strategy;
        public event TransactionLoggedHandler OnTransactionFound;

        public CashFlowEngine(ISettlementStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Run(List<Bank> banks)
        {
            try
            {
                if (banks == null || !banks.Any())
                    throw new CashFlowException("No banks found in the system.");

                var results = _strategy.Settle(banks);

                Console.WriteLine("\n--- Optimized Transactions ---");
                foreach (var tx in results)
                {
                    string msg = $"{tx.Debtor.Name} pays {tx.Amount} to {tx.Creditor.Name} via {tx.Mode}";
                    OnTransactionFound?.Invoke(msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CRITICAL ERROR]: {ex.Message}");
            }
        }
    }

    public class GreedySettlementStrategy : ISettlementStrategy
    {
        public IEnumerable<Transaction<Bank>> Settle(List<Bank> banks)
        {
            var transactions = new List<Transaction<Bank>>();

            while (true)
            {
                // Find max debtor and max creditor
                var minBank = banks.OrderBy(b => b.NetAmount).FirstOrDefault(b => b.NetAmount < 0);
                var maxBank = banks.OrderByDescending(b => b.NetAmount).FirstOrDefault(b => b.NetAmount > 0);

                if (minBank == null || maxBank == null) break;

                // Logic for common payment mode (matching your C++ Intersection logic)
                var commonModes = minBank.PaymentModes.Intersect(maxBank.PaymentModes).ToList();
                string selectedMode;
                Bank actualCreditor = maxBank;

                if (!commonModes.Any())
                {
                    // If no common mode, use the "World Bank" (Assumed to be index 0)
                    var worldBank = banks[0];
                    selectedMode = worldBank.PaymentModes.First();
                    // In a real scenario, you'd split this into two transactions: 
                    // Debtor -> WorldBank, then WorldBank -> Creditor
                }
                else
                {
                    selectedMode = commonModes.First();
                }

                decimal amount = Math.Min(Math.Abs(minBank.NetAmount), maxBank.NetAmount);

                transactions.Add(new Transaction<Bank>
                {
                    Debtor = minBank,
                    Creditor = actualCreditor,
                    Amount = amount,
                    Mode = selectedMode
                });

                minBank.NetAmount += amount;
                maxBank.NetAmount -= amount;
            }

            return transactions;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Setup
                var banks = new List<Bank>
                {
                    new Bank("World_Bank") { PaymentModes = { "GooglePay", "PayTM" } },
                    new Bank("Bank_B") { PaymentModes = { "GooglePay" }, NetAmount = -300 },
                    new Bank("Bank_C") { PaymentModes = { "GooglePay" }, NetAmount = -700 },
                    new Bank("Bank_D") { PaymentModes = { "PayTM" }, NetAmount = 500 },
                    new Bank("Bank_E") { PaymentModes = { "PayTM" }, NetAmount = 500 }
                };

                var engine = new CashFlowEngine(new GreedySettlementStrategy());

                engine.OnTransactionFound += (msg) => Console.WriteLine($"[LOG]: {msg}");

                engine.Run(banks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in Main: {ex.Message}");
            }
        }
    }
}
