namespace DesignPatterns
{
    // Adapter
    public interface INewPrinter
    {
        void PrintDocument(string content);
    }
    public class OldPrinter
    {
        public void OldPrint(string text) =>
            Console.WriteLine($"[Old Printer]: {text}");
    }
    public class PrinterAdapter : INewPrinter
    {
        private readonly OldPrinter _oldPrinter;
        public PrinterAdapter(OldPrinter oldPrinter) => _oldPrinter = oldPrinter;
        public void PrintDocument(string content) => _oldPrinter.OldPrint(content);
    }

    // Decorator
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 30.0;
    }
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;
        public CoffeeDecorator(ICoffee coffee) => _coffee = coffee;
        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual double GetCost() => _coffee.GetCost();
    }
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => _coffee.GetDescription() + " + Milk";
        public override double GetCost() => _coffee.GetCost() + 10.0;
    }
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => _coffee.GetDescription() + " + Sugar";
        public override double GetCost() => _coffee.GetCost() + 5.0;
    }

    // Proxy
    public interface IDatabase
    {
        void Query(string sql);
    }
    public class RealDatabase : IDatabase
    {
        public void Query(string sql) =>
            Console.WriteLine($"[Database] Executing: {sql}");
    }
    public class DatabaseProxy : IDatabase
    {
        private readonly RealDatabase _realDb;
        private readonly string _userRole;
        public DatabaseProxy(string userRole)
        {
            _realDb = new RealDatabase();
            _userRole = userRole;
        }
        public void Query(string sql)
        {
            if (_userRole == "Admin")
            {
                Console.WriteLine("[Proxy] Access granted.");
                _realDb.Query(sql);
            }
            else
            {
                Console.WriteLine($"[Proxy] Access DENIED for role: {_userRole}");
            }
        }
    }
}