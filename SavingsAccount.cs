using System;

class SavingsAccount : BankAccount
{
    private decimal InterestRate; // Interest rate for savings accounts

    public SavingsAccount(string accountNumber, string holderName, string password, decimal interestRate)
        : base(accountNumber, holderName, password)
    {
        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate / 100;
        Balance += interest;
        Console.WriteLine($"Interest of {interest:C} applied. New Balance: {Balance:C}");
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C} from savings. Remaining Balance: {Balance:C}");
            CreateVoucher(amount);
            return true;
        }
        Console.WriteLine("Insufficient funds or invalid amount.");
        return false;
    }
}
