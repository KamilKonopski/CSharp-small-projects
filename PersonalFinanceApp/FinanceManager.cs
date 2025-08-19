namespace PersonalFinanceApp
{
    using PersonalFinanceApp.Models;

    public class FinanceManager
    {
        private List<Account> Accounts { get; set; }

        public FinanceManager()
        {
            Accounts = new List<Account>();
        }

        // Zwraca wyjątek, jeśli konto nie istnieje
        public Account GetAccountByName(string name)
        {
            var account = Accounts.FirstOrDefault(a => a.Name == name);
            if (account == null)
            {
                throw new ArgumentException($"Account with name '{name}' not found.");
            }
            return account;
        }

        public void AddAccount(string name, decimal initialBalance = 0)
        {
            var account = new Account(name, initialBalance);
            Accounts.Add(account);
            Console.WriteLine($"Account {name} created with {initialBalance:C} balance.");
        }

        public void AddTransactionToAccount(string accountName, decimal amount, string description)
        {
            try
            {
                var account = GetAccountByName(accountName);
                account.AddTransaction(amount, description);
                Console.WriteLine($"Transaction of {amount:C} added to {accountName}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);  // Wyświetlanie komunikatu o błędzie
            }
        }

        public void DisplayAccounts()
        {
            foreach (var account in Accounts)
            {
                account.DisplayBalance();
            }
        }
    }
}