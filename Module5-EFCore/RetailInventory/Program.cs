using RetailInventory.Data;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("=== EF Core 8.0 - Retail Inventory System ===\n");
using var context = new RetailDbContext();

// Lab 4: Insert
context.Products.AddRange(
    new Product { Name = "Laptop",     Category = "Electronics", Price = 999.99m, StockQuantity = 50 },
    new Product { Name = "Smartphone", Category = "Electronics", Price = 699.99m, StockQuantity = 100 },
    new Product { Name = "Headphones", Category = "Accessories", Price = 199.99m, StockQuantity = 75 },
    new Product { Name = "Keyboard",   Category = "Accessories", Price = 79.99m,  StockQuantity = 120 },
    new Product { Name = "Monitor",    Category = "Electronics", Price = 399.99m, StockQuantity = 30 }
);
context.SaveChanges();
Console.WriteLine("Lab 4: Data inserted.\n");

// Lab 5: Retrieve
Console.WriteLine("Lab 5: All Products:");
foreach (var p in context.Products.ToList())
    Console.WriteLine($"  [{p.ProductId}] {p.Name} | {p.Category} | ${p.Price} | Stock: {p.StockQuantity}");

// Lab 6: Update
var laptop = context.Products.FirstOrDefault(p => p.Name == "Laptop");
if (laptop != null) { laptop.Price = 949.99m; context.SaveChanges(); }
Console.WriteLine($"\nLab 6: Laptop price updated to ${laptop.Price}");

// Lab 7: LINQ
Console.WriteLine("\nLab 7: Electronics under $800:");
foreach (var p in context.Products.Where(p => p.Category == "Electronics" && p.Price < 800).OrderBy(p => p.Price).ToList())
    Console.WriteLine($"  {p.Name} - ${p.Price}");
