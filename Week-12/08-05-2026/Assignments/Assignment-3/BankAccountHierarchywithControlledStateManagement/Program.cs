using System;

class BankAccount
{
    public string accountNumber { get; }
    private double balance;

    public BankAccount(string accNo, double initialBalance)
    {
        accountNumber = accNo;
        balance = initialBalance;
    }

    public virtual bool Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            return true;
        }
        return false;
    }

    public virtual bool Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }

    public double GetBalance()
    {
        return balance;
    }

    protected void SetBalance(double amount)
    {
        balance = amount;
    }
}

class SavingsAccount : BankAccount
{
    public double interestRate;
    public double minimumBalance = 1000;

    public SavingsAccount(string accNo, double balance)
        : base(accNo, balance)
    {
    }

    public override bool Withdraw(double amount)
    {
        if (GetBalance() - amount >= minimumBalance)
        {
            SetBalance(GetBalance() - amount);
            Console.WriteLine("Withdrawal Successful");
            return true;
        }

        Console.WriteLine("Withdrawal Failed: Minimum balance requirement 1000");
        return false;
    }

    public void ApplyInterest(double rate)
    {
        interestRate = rate;

        double newBalance = GetBalance() + (GetBalance() * rate / 100);

        SetBalance(newBalance);

        Console.WriteLine($"Interest Applied,Rate:{interestRate},New Balance:{GetBalance()}");
    }
}

class CurrentAccount : BankAccount
{
    public double overdraftLimit = 2000;
    public double transactionFee = 100;

    public CurrentAccount(string accNo, double balance)
        : base(accNo, balance)
    {
    }

    public override bool Withdraw(double amount)
    {
        if (GetBalance() + overdraftLimit >= amount)
        {
            SetBalance(GetBalance() - amount);
            Console.WriteLine("Withdrawal Successful");
            return true;
        }

        Console.WriteLine("Withdrawal Failed");
        return false;
    }

    public void DeductTransactionFee()
    {
        SetBalance(GetBalance() - transactionFee);

        Console.WriteLine($"Fee Deducted,Amount:{transactionFee},Remaining:{GetBalance()}");
    }
}

class Program
{
    static void Main()
    {
        string accountType = Console.ReadLine();

        string accNo = Console.ReadLine();

        double initialDeposit = double.Parse(Console.ReadLine());

        string operation1 = Console.ReadLine();

        string operation2 = Console.ReadLine();

        if (accountType == "Savings")
        {
            SavingsAccount acc = new SavingsAccount(accNo, initialDeposit);

            string[] op1 = operation1.Split(' ');

            if (op1[0] == "Withdraw")
            {
                double amount = double.Parse(op1[1]);
                acc.Withdraw(amount);
            }

            if (operation2 == "GetBalance")
            {
                Console.WriteLine($"Current Balance: {acc.GetBalance()}");
            }

            string operation3 = Console.ReadLine();

            string[] op3 = operation3.Split(' ');

            if (op3[0] == "ApplyInterest")
            {
                double rate = double.Parse(op3[1]);
                acc.ApplyInterest(rate);
            }
        }
        else
        {
            CurrentAccount acc = new CurrentAccount(accNo, initialDeposit);

            string[] op1 = operation1.Split(' ');

            if (op1[0] == "Withdraw")
            {
                double amount = double.Parse(op1[1]);
                acc.Withdraw(amount);
            }

            if (operation2 == "GetBalance")
            {
                Console.WriteLine($"Current Balance: {acc.GetBalance()}");
            }

            acc.DeductTransactionFee();
        }
    }
}