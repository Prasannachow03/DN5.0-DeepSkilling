using DesignPatterns;

Console.WriteLine("========== MODULE 1: Design Patterns ==========\n");

// ===== SOLID =====
Console.WriteLine("--- SOLID: Dependency Inversion ---");
var emailService = new NotificationService(new EmailSender());
emailService.Notify("Welcome to Cognizant DN 5.0!");
var smsService = new NotificationService(new SmsSender());
smsService.Notify("Your OTP is 1234");

Console.WriteLine("\n--- SOLID: Single Responsibility ---");
var order = new Order { OrderId = 1, CustomerName = "Prasa", Amount = 5000 };
new OrderRepository().Save(order);
new OrderPrinter().Print(order);

// ===== CREATIONAL =====
Console.WriteLine("\n========== CREATIONAL PATTERNS ==========\n");

Console.WriteLine("--- Singleton Pattern ---");
Logger.Instance.Log("App started");
Logger.Instance.Log("Same logger instance always");

Console.WriteLine("\n--- Factory Pattern ---");
var dog = AnimalFactory.Create("dog");
var cat = AnimalFactory.Create("cat");
Console.WriteLine($"Dog says: {dog.Speak()}, Cat says: {cat.Speak()}");

Console.WriteLine("\n--- Builder Pattern ---");
var pizza = new PizzaBuilder()
    .SetSize("Large")
    .SetCrust("Thin")
    .AddTopping("Cheese")
    .AddTopping("Mushrooms")
    .Build();
Console.WriteLine(pizza);

// ===== STRUCTURAL =====
Console.WriteLine("\n========== STRUCTURAL PATTERNS ==========\n");

Console.WriteLine("--- Adapter Pattern ---");
OldPrinter oldPrinter = new OldPrinter();
INewPrinter adapter = new PrinterAdapter(oldPrinter);
adapter.PrintDocument("Cognizant DN 5.0 Report");

Console.WriteLine("\n--- Decorator Pattern ---");
ICoffee coffee = new SimpleCoffee();
Console.WriteLine($"{coffee.GetDescription()} = Rs.{coffee.GetCost()}");
coffee = new MilkDecorator(coffee);
Console.WriteLine($"{coffee.GetDescription()} = Rs.{coffee.GetCost()}");
coffee = new SugarDecorator(coffee);
Console.WriteLine($"{coffee.GetDescription()} = Rs.{coffee.GetCost()}");

Console.WriteLine("\n--- Proxy Pattern ---");
IDatabase adminDb = new DatabaseProxy("Admin");
adminDb.Query("SELECT * FROM Employees");
IDatabase guestDb = new DatabaseProxy("Guest");
guestDb.Query("DROP TABLE Employees");

// ===== BEHAVIORAL =====
Console.WriteLine("\n========== BEHAVIORAL PATTERNS ==========\n");

Console.WriteLine("--- Observer Pattern ---");
var events = new EventManager();
events.Subscribe(new EmailNotifier());
events.Notify("New order placed!");

Console.WriteLine("\n--- Strategy Pattern ---");
var sorter = new Sorter(new BubbleSort());
sorter.Sort(new[] { 5, 2, 8, 1, 9 });
