public class BankAccount
{
    public string AccountNumber { get; private set; }
    public double Balance { get; private set; }

    public BankAccount(string accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0.0;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}
