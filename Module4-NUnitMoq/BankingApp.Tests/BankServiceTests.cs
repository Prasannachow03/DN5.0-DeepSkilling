using NUnit.Framework;
using Moq;

[TestFixture]
public class BankServiceTests
{
    private Mock<IBankRepository> _mockRepo;
    private BankService _bankService;

    [SetUp]
    public void SetUp()
    {
        _mockRepo = new Mock<IBankRepository>();
        _bankService = new BankService(_mockRepo.Object);
    }

    [Test]
    public void Deposit_ValidAmount_ReturnsSuccessMessage()
    {
        _mockRepo.Setup(r => r.Deposit(1, 500)).Returns(true);
        string result = _bankService.Deposit(1, 500);
        Assert.That(result, Is.EqualTo("Deposited $500 successfully."));
    }

    [Test]
    public void Deposit_NegativeAmount_ReturnsInvalidMessage()
    {
        string result = _bankService.Deposit(1, -100);
        Assert.That(result, Is.EqualTo("Invalid deposit amount."));
    }

    [Test]
    public void Withdraw_SufficientBalance_ReturnsSuccessMessage()
    {
        _mockRepo.Setup(r => r.GetBalance(1)).Returns(1000);
        _mockRepo.Setup(r => r.Withdraw(1, 300)).Returns(true);
        string result = _bankService.Withdraw(1, 300);
        Assert.That(result, Is.EqualTo("Withdrew $300 successfully."));
    }

    [Test]
    public void Withdraw_InsufficientBalance_ReturnsInsufficientFundsMessage()
    {
        _mockRepo.Setup(r => r.GetBalance(1)).Returns(100);
        string result = _bankService.Withdraw(1, 500);
        Assert.That(result, Is.EqualTo("Insufficient funds."));
    }

    [Test]
    public void Deposit_CallsRepositoryOnce()
    {
        _mockRepo.Setup(r => r.Deposit(1, 200)).Returns(true);
        _bankService.Deposit(1, 200);
        _mockRepo.Verify(r => r.Deposit(1, 200), Times.Once);
    }

    [Test]
    public void GetBalance_ReturnsCorrectAmount()
    {
        _mockRepo.Setup(r => r.GetBalance(1)).Returns(750);
        decimal balance = _bankService.GetBalance(1);
        Assert.That(balance, Is.EqualTo(750));
    }
}