using System;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, string category, double price)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
        Price = price;
    }

    public override string ToString() =>
        $"ID: {ProductId} | Name: {ProductName} | Category: {Category} | Price: ${Price}";
}

public class EcommerceSearch
{
    // Linear Search - O(n)
    public static Product LinearSearch(Product[] products, string targetName)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    // Binary Search - O(log n) - array must be sorted by ProductName
    public static Product BinarySearch(Product[] sortedProducts, string targetName)
    {
        int left = 0, right = sortedProducts.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = string.Compare(sortedProducts[mid].ProductName, targetName, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
                return sortedProducts[mid];
            else if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== E-Commerce Platform Search Function ===\n");

        Product[] products = {
            new Product(1, "Laptop", "Electronics", 999.99),
            new Product(2, "Smartphone", "Electronics", 699.99),
            new Product(3, "Headphones", "Accessories", 199.99),
            new Product(4, "Keyboard", "Accessories", 79.99),
            new Product(5, "Monitor", "Electronics", 399.99),
            new Product(6, "Mouse", "Accessories", 49.99),
            new Product(7, "Webcam", "Electronics", 89.99),
        };

        // Linear Search
        Console.WriteLine("--- Linear Search ---");
        string searchTerm = "Monitor";
        var result = EcommerceSearch.LinearSearch(products, searchTerm);
        Console.WriteLine(result != null ? $"Found: {result}" : $"'{searchTerm}' not found.");

        // Binary Search (sort first)
        Console.WriteLine("\n--- Binary Search ---");
        var sortedProducts = products.OrderBy(p => p.ProductName).ToArray();
        searchTerm = "Keyboard";
        result = EcommerceSearch.BinarySearch(sortedProducts, searchTerm);
        Console.WriteLine(result != null ? $"Found: {result}" : $"'{searchTerm}' not found.");

        Console.WriteLine("\n--- Search Complexity ---");
        Console.WriteLine("Linear Search: O(n) - checks each element");
        Console.WriteLine("Binary Search: O(log n) - divides search space in half each time");
        Console.WriteLine("Binary Search is preferred for large sorted datasets.");
    }
}
