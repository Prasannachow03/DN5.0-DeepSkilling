-- Exercise 1: Ranking and Window Functions

-- Create and use database
CREATE DATABASE IF NOT EXISTS ECommerceDB;
USE ECommerceDB;

-- Create Orders table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY AUTO_INCREMENT,
    CustomerId INT,
    CustomerName VARCHAR(100),
    ProductName VARCHAR(100),
    Amount DECIMAL(10,2),
    OrderDate DATE
);

-- Insert sample data
INSERT INTO Orders (CustomerId, CustomerName, ProductName, Amount, OrderDate) VALUES
(1, 'Alice',   'Laptop',      1200.00, '2024-01-15'),
(2, 'Bob',     'Smartphone',   800.00, '2024-01-20'),
(3, 'Charlie', 'Tablet',       600.00, '2024-02-10'),
(1, 'Alice',   'Headphones',   200.00, '2024-02-15'),
(2, 'Bob',     'Monitor',      500.00, '2024-03-01'),
(4, 'Diana',   'Keyboard',     150.00, '2024-03-05'),
(3, 'Charlie', 'Mouse',         80.00, '2024-03-10'),
(4, 'Diana',   'Webcam',       120.00, '2024-03-15'),
(5, 'Eve',     'Printer',      350.00, '2024-04-01'),
(5, 'Eve',     'Scanner',      250.00, '2024-04-10');

-- 1. RANK(): Ranks orders by amount (gaps in rank for ties)
SELECT 
    OrderId,
    CustomerName,
    ProductName,
    Amount,
    RANK() OVER (ORDER BY Amount DESC) AS SalesRank
FROM Orders;

-- 2. DENSE_RANK(): Ranks without gaps
SELECT 
    OrderId,
    CustomerName,
    ProductName,
    Amount,
    DENSE_RANK() OVER (ORDER BY Amount DESC) AS DenseRank
FROM Orders;

-- 3. ROW_NUMBER(): Unique row number per partition (per customer)
SELECT 
    OrderId,
    CustomerName,
    ProductName,
    Amount,
    ROW_NUMBER() OVER (PARTITION BY CustomerName ORDER BY Amount DESC) AS RowNum
FROM Orders;

-- 4. SUM() as Running Total
SELECT 
    OrderId,
    CustomerName,
    Amount,
    SUM(Amount) OVER (ORDER BY OrderDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS RunningTotal
FROM Orders;

-- 5. Top order per customer using window function
SELECT * FROM (
    SELECT 
        CustomerName,
        ProductName,
        Amount,
        ROW_NUMBER() OVER (PARTITION BY CustomerName ORDER BY Amount DESC) AS rn
    FROM Orders
) ranked
WHERE rn = 1;