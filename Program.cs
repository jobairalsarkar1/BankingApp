// See https://aka.ms/new-console-template for more information

Bank bank = new();

while (true)
{
    Console.WriteLine("\n--- Banking System ---");
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine()!;

    if (choice == "1")
    {
        bank.CreateAccount();
    }
    else if (choice == "2")
    {
        BankAccount? account = bank.Login();
        if (account != null)
        {
            while (true)
            {
                Console.WriteLine("\n--- Account Menu ---");
                Console.WriteLine("1. Deposit Money");
                Console.WriteLine("2. Withdraw Money");
                Console.WriteLine("3. Check Balance");
                if (account is SavingsAccount) Console.WriteLine("4. Apply Interest");
                Console.WriteLine("5. Logout");
                Console.Write("Choose an option: ");

                string accountChoice = Console.ReadLine()!;

                if (accountChoice == "1")
                {
                    Console.Write("Enter deposit amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        account.Deposit(amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                }
                else if (accountChoice == "2")
                {
                    Console.Write("Enter withdrawal amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        account.Withdraw(amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                }
                else if (accountChoice == "3")
                {
                    account.DisplayBalance();
                }
                else if (accountChoice == "4" && account is SavingsAccount savingsAccount)
                {
                    savingsAccount.ApplyInterest();
                }
                else if (accountChoice == "5")
                {
                    Console.WriteLine("Logging out...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
    else if (choice == "3")
    {
        Console.WriteLine("Exiting... Thank you for using the Banking System.");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }
}
