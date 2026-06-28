using System;

// Singleton Pattern - Thread-safe implementation
public class Logger
{
    // Step 1: Private static instance
    private static Logger _instance = null;
    private static readonly object _lock = new object();
    private int _logCount = 0;

    // Step 2: Private constructor - prevents direct instantiation
    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }

    // Step 3: Public static method to get the single instance
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    public void Log(string message)
    {
        _logCount++;
        Console.WriteLine($"[Log #{_logCount}] {message}");
    }

    public int GetLogCount() => _logCount;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Singleton Pattern Demo ===\n");

        // Both variables point to the SAME instance
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("Application started.");
        logger2.Log("User logged in.");
        logger1.Log("Data fetched from database.");

        Console.WriteLine($"\nAre both instances the same? {object.ReferenceEquals(logger1, logger2)}");
        Console.WriteLine($"Total logs recorded: {logger1.GetLogCount()}");
    }
}