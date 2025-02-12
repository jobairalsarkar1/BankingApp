using System;
using System.Collections.Generic;

class Bank
{
    private Dictionary<string, BankAccount> accounts = new();

    public void CreateAccount()
    {
        Console.Write("Enter Account Holder Name: ");
        string holderName = Console.ReadLine()!;
        Console.Write("Create Account Number: ");
        string accountNumber = Console.ReadLine()!;
        Console.Write("Set a Password: ");
        string password = Console.ReadLine()!;

        if (accounts.ContainsKey(accountNumber))
        {
            Console.WriteLine("Account number already exists!");
            return;
        }

        BankAccount newAccount = new(accountNumber, holderName, password);
        accounts[accountNumber] = newAccount;
        Console.WriteLine("Account successfully created!");
    }

    public BankAccount? Login()
    {
        Console.Write("Enter Account Number: ");
        string accountNumber = Console.ReadLine()!;
        Console.Write("Enter Password: ");
        string password = Console.ReadLine()!;

        if (accounts.TryGetValue(accountNumber, out BankAccount? account))
        {
            if (account.VerifyPassword(password))
            {
                Console.WriteLine("Login successful!");
                return account;
            }
            Console.WriteLine("Incorrect password.");
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
        return null;
    }
}
