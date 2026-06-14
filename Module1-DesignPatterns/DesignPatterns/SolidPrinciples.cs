namespace DesignPatterns
{
    // S - Single Responsibility
    public class Order
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public double Amount { get; set; }
    }

    public class OrderRepository
    {
        public void Save(Order order) =>
            Console.WriteLine($"Order {order.OrderId} saved to database.");
    }

    public class OrderPrinter
    {
        public void Print(Order order) =>
            Console.WriteLine($"Order: {order.CustomerName} - Rs.{order.Amount}");
    }

    // O - Open/Closed
    public abstract class Discount
    {
        public abstract double Calculate(double price);
    }
    public class SeasonalDiscount : Discount
    {
        public override double Calculate(double price) => price * 0.9;
    }
    public class LoyaltyDiscount : Discount
    {
        public override double Calculate(double price) => price * 0.85;
    }

    // D - Dependency Inversion
    public interface IMessageSender
    {
        void Send(string message);
    }
    public class EmailSender : IMessageSender
    {
        public void Send(string message) =>
            Console.WriteLine($"Email sent: {message}");
    }
    public class SmsSender : IMessageSender
    {
        public void Send(string message) =>
            Console.WriteLine($"SMS sent: {message}");
    }
    public class NotificationService
    {
        private readonly IMessageSender _sender;
        public NotificationService(IMessageSender sender) => _sender = sender;
        public void Notify(string message) => _sender.Send(message);
    }
}