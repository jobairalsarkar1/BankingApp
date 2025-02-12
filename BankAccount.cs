using System;

class BankAccount
{
    public string AccountNumber { get; }
    public string HolderName { get; }
    private string Password { get; }
    private decimal Balance { get; set; }

    public BankAccount(string accountNumber, string holderName, string password)
    {
        AccountNumber = accountNumber;
        HolderName = holderName;
        Password = password;
        Balance = 0;
    }

    public bool VerifyPassword(string inputPassword) => Password == inputPassword;

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. Remaining Balance: {Balance:C}");
            return true;
        }
        Console.WriteLine("Insufficient funds or invalid amount.");
        return false;
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Account Balance: {Balance:C}");
    }
}
