using System;
public class BankAccount
{
    private static int accountCounter = 3196000;
    public int AccountNumber { get; }
    public string AccountHolderName { get; }
    private double Balance { get; set; }

    public BankAccount(string accountHolderName)
    {
        AccountNumber = GenerateAccountNumber();
        AccountHolderName = accountHolderName;
        Balance = 0;
    }
    private static int GenerateAccountNumber()
    {
        return ++accountCounter;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }

        Balance += amount;
    }
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }

        Balance -= amount;
    }
    public double GetBalance()
    {
        return Balance;
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Enter account holder's name: ");
        string accountHolderName = Console.ReadLine();

        BankAccount account = new BankAccount(accountHolderName);

        Console.Write("Enter amount to deposit: ");
        double depositAmount = Convert.ToDouble(Console.ReadLine());

        try
        {
            account.Deposit(depositAmount);
            Console.WriteLine("Account Holder: " + account.AccountHolderName);
            Console.WriteLine("Account Number: " + account.AccountNumber);
            Console.WriteLine("Balance after deposit: $" + account.GetBalance());

            Console.Write("Enter amount to withdraw: $");
            double withdrawalAmount = Convert.ToDouble(Console.ReadLine());

            try
            {
                account.Withdraw(withdrawalAmount);
                Console.WriteLine("Current Balance available after withdrawal: $" + account.GetBalance());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
