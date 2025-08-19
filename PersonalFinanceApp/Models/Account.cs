namespace PersonalFinanceApp.Models
{
    public class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; private set; }
        public List<Transaction> Transactions { get; set; }

        public Account(string name, decimal initialBalance = 0)
        {
            Name = name;
            Balance = initialBalance;
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(decimal amount, string description)
        {
            var transaction = new Transaction(amount, description);
            Transactions.Add(transaction);
            Balance += amount;
        }

        public void DisplayTransactions()
        {
            Console.WriteLine($"Transactions for {Name}:");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"{transaction.Date.ToShortDateString()} - {transaction.Description} - {transaction.Amount:C}");
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"{Name} Balance: {Balance:C}");
        }
    }
}