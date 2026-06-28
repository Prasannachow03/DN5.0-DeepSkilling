using System;

public class FinancialForecasting
{
    // Recursive approach - O(n)
    public static double ForecastRecursive(double currentValue, double growthRate, int years)
    {
        if (years == 0) return currentValue;
        return ForecastRecursive(currentValue * (1 + growthRate), growthRate, years - 1);
    }

    // Iterative approach - O(n) but no stack overflow risk
    public static double ForecastIterative(double currentValue, double growthRate, int years)
    {
        double value = currentValue;
        for (int i = 0; i < years; i++)
        {
            value *= (1 + growthRate);
        }
        return value;
    }

    // Direct formula approach - O(1) - most efficient
    public static double ForecastFormula(double currentValue, double growthRate, int years)
    {
        return currentValue * Math.Pow(1 + growthRate, years);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Financial Forecasting Tool ===\n");

        double initialInvestment = 10000.00;
        double annualGrowthRate = 0.08; // 8%
        int years = 10;

        Console.WriteLine($"Initial Investment: ${initialInvestment:F2}");
        Console.WriteLine($"Annual Growth Rate: {annualGrowthRate * 100}%");
        Console.WriteLine($"Forecast Period: {years} years\n");

        double recursiveResult = FinancialForecasting.ForecastRecursive(initialInvestment, annualGrowthRate, years);
        double iterativeResult = FinancialForecasting.ForecastIterative(initialInvestment, annualGrowthRate, years);
        double formulaResult  = FinancialForecasting.ForecastFormula(initialInvestment, annualGrowthRate, years);

        Console.WriteLine($"Recursive Result:  ${recursiveResult:F2}");
        Console.WriteLine($"Iterative Result:  ${iterativeResult:F2}");
        Console.WriteLine($"Formula Result:    ${formulaResult:F2}");

        Console.WriteLine("\n--- Year-by-Year Forecast ---");
        Console.WriteLine($"{"Year",-6} {"Value",-15}");
        Console.WriteLine(new string('-', 22));
        for (int y = 0; y <= years; y++)
        {
            double val = FinancialForecasting.ForecastFormula(initialInvestment, annualGrowthRate, y);
            Console.WriteLine($"{y,-6} ${val,-14:F2}");
        }

        Console.WriteLine("\n--- Optimization Note ---");
        Console.WriteLine("Recursive: Simple but risks stack overflow for large 'years'.");
        Console.WriteLine("Iterative: Safe for large inputs, O(n) time.");
        Console.WriteLine("Formula (Math.Pow): Best — O(1) time, handles any input size.");
    }
}