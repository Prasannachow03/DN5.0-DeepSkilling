public interface IBankRepository
{
    decimal GetBalance(int accountId);
    bool Deposit(int accountId, decimal amount);
    bool Withdraw(int accountId, decimal amount);
}