-- Stored Procedure Exercises

CREATE DATABASE IF NOT EXISTS EmployeeDB;
USE EmployeeDB;

CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10,2),
    JoiningDate DATE
);

INSERT INTO Employees (Name, Department, Salary, JoiningDate) VALUES
('Alice Johnson', 'IT',        75000.00, '2020-03-15'),
('Bob Smith',     'Finance',   65000.00, '2019-07-01'),
('Charlie Brown', 'IT',        80000.00, '2021-01-10'),
('Diana Prince',  'HR',        60000.00, '2018-11-20'),
('Eve Wilson',    'Finance',   70000.00, '2022-05-05');

-- Exercise 1: Create a Stored Procedure
DELIMITER //
CREATE PROCEDURE GetAllEmployees()
BEGIN
    SELECT * FROM Employees;
END //
DELIMITER ;

-- Call it:
CALL GetAllEmployees();

-- Exercise 5: Return Data from a Stored Procedure
DELIMITER //
CREATE PROCEDURE GetEmployeesByDepartment(IN deptName VARCHAR(50))
BEGIN
    SELECT 
        EmployeeId,
        Name,
        Department,
        Salary,
        JoiningDate
    FROM Employees
    WHERE Department = deptName
    ORDER BY Salary DESC;
END //
DELIMITER ;

-- Call it:
CALL GetEmployeesByDepartment('IT');
CALL GetEmployeesByDepartment('Finance');