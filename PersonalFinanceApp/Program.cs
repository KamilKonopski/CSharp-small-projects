namespace PersonalFinanceApp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var financeManager = new FinanceManager();

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Personal Finance App ===");
                Console.WriteLine("1. Create New Account");
                Console.WriteLine("2. Add Transaction");
                Console.WriteLine("3. View Accounts and Balances");
                Console.WriteLine("4. View Transactions for an Account");
                Console.WriteLine("5. Exit");
                Console.Write("Please choose an option (1-5): ");

                string? choice = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Invalid option, please try again.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        CreateAccount(financeManager);
                        break;
                    case "2":
                        AddTransaction(financeManager);
                        break;
                    case "3":
                        ViewAccounts(financeManager);
                        break;
                    case "4":
                        ViewTransactions(financeManager);
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("Exiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        static void CreateAccount(FinanceManager financeManager)
        {
            Console.Clear();
            Console.Write("Enter the account name: ");
            string? accountName = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(accountName))
            {
                Console.WriteLine("Account name cannot be empty. Please try again.");
                return;
            }

            decimal initialBalance;
            Console.Write("Enter the initial balance: ");
            while (!decimal.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.Write("Invalid input. Please enter a valid number for the initial balance: ");
            }

            financeManager.AddAccount(accountName, initialBalance);
            Console.WriteLine($"Account '{accountName}' created with {initialBalance:C} balance.");
        }

        static void AddTransaction(FinanceManager financeManager)
        {
            Console.Clear();
            Console.Write("Enter the account name: ");
            string? accountName = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(accountName))
            {
                Console.WriteLine("Account name cannot be empty. Please try again.");
                return;
            }

            decimal amount;
            Console.Write("Enter the transaction amount (use negative values for withdrawals): ");
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Invalid input. Please enter a valid amount: ");
            }

            Console.Write("Enter a description for the transaction: ");
            string? description = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description cannot be empty. Please try again.");
                return;
            }

            financeManager.AddTransactionToAccount(accountName, amount, description);
        }

        static void ViewAccounts(FinanceManager financeManager)
        {
            Console.Clear();
            financeManager.DisplayAccounts();
        }

        static void ViewTransactions(FinanceManager financeManager)
        {
            Console.Clear();
            Console.Write("Enter the account name to view transactions: ");
            string? accountName = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(accountName))
            {
                Console.WriteLine("Account name cannot be empty. Please try again.");
                return;
            }

            var account = financeManager.GetAccountByName(accountName);
            if (account != null)
            {
                account.DisplayTransactions();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}