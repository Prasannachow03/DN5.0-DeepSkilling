namespace DesignPatterns
{
    // Singleton
    public class Logger
    {
        private static Logger? _instance;
        private Logger() { }
        public static Logger Instance => _instance ??= new Logger();
        public void Log(string msg) => Console.WriteLine($"[LOG]: {msg}");
    }

    // Factory
    public abstract class Animal
    {
        public abstract string Speak();
    }
    public class Dog : Animal { public override string Speak() => "Woof!"; }
    public class Cat : Animal { public override string Speak() => "Meow!"; }

    public static class AnimalFactory
    {
        public static Animal Create(string type) => type.ToLower() switch
        {
            "dog" => new Dog(),
            "cat" => new Cat(),
            _ => throw new ArgumentException("Unknown animal")
        };
    }

    // Builder
    public class Pizza
    {
        public string? Size { get; set; }
        public string? Crust { get; set; }
        public List<string> Toppings { get; set; } = new();
        public override string ToString() =>
            $"{Size} pizza, {Crust} crust, toppings: {string.Join(", ", Toppings)}";
    }
    public class PizzaBuilder
    {
        private Pizza _pizza = new();
        public PizzaBuilder SetSize(string size) { _pizza.Size = size; return this; }
        public PizzaBuilder SetCrust(string crust) { _pizza.Crust = crust; return this; }
        public PizzaBuilder AddTopping(string t) { _pizza.Toppings.Add(t); return this; }
        public Pizza Build() => _pizza;
    }
}