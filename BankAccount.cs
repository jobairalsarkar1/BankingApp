using System;
using System.IO;

class BankAccount
{
    public string AccountNumber { get; }
    public string HolderName { get; }
    private string Password { get; }
    protected decimal Balance { get; set; }

    public BankAccount(string accountNumber, string holderName, string password)
    {
        AccountNumber = accountNumber;
        HolderName = holderName;
        Password = password;
        Balance = 0;
    }

    public bool VerifyPassword(string inputPassword) => Password == inputPassword;

    public virtual void Deposit(decimal amount)
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

    public virtual bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. Remaining Balance: {Balance:C}");
            CreateVoucher(amount); // Generate a voucher for the withdrawal
            return true;
        }
        Console.WriteLine("Insufficient funds or invalid amount.");
        return false;
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Account Balance: {Balance:C}");
    }

    protected void CreateVoucher(decimal amount)
    {
        string fileName = $"Voucher_{AccountNumber}_{DateTime.Now:yyyyMMddHHmmss}.txt";
        using StreamWriter writer = new StreamWriter(fileName);
        writer.WriteLine("----- Withdrawal Voucher -----");
        writer.WriteLine($"Account Holder: {HolderName}");
        writer.WriteLine($"Account Number: {AccountNumber}");
        writer.WriteLine($"Withdrawn Amount: {amount:C}");
        writer.WriteLine($"Date & Time: {DateTime.Now}");
        writer.WriteLine("-----------------------------");
    }
}
