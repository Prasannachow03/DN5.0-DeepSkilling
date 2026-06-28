public class BankService
{
    private readonly IBankRepository _repository;

    public BankService(IBankRepository repository)
    {
        _repository = repository;
    }

    public decimal GetBalance(int accountId) => _repository.GetBalance(accountId);

    public string Deposit(int accountId, decimal amount)
    {
        if (amount <= 0) return "Invalid deposit amount.";
        bool success = _repository.Deposit(accountId, amount);
        return success ? $"Deposited ${amount} successfully." : "Deposit failed.";
    }

    public string Withdraw(int accountId, decimal amount)
    {
        if (amount <= 0) return "Invalid withdrawal amount.";
        decimal balance = _repository.GetBalance(accountId);
        if (balance < amount) return "Insufficient funds.";
        bool success = _repository.Withdraw(accountId, amount);
        return success ? $"Withdrew ${amount} successfully." : "Withdrawal failed.";
    }
}