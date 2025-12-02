CREATE DATABASE Company;
USE Company;

CREATE TABLE Employees (
    EmployeeID INT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    HireDate DATE,
    JobTitle VARCHAR(50),
    Salary DECIMAL(10,2),
    Department VARCHAR(50)
);

INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, PhoneNumber, HireDate, JobTitle, Salary, Department) VALUES
(1, 'Ali', 'Hashimov', 'ali@company.az', '0501234567', '2019-05-10', 'IT Specialist', 2500, 'IT'),
(2, 'Leyla', 'Hasanova', 'leyla@company.az', '0517654321', '2021-08-20', 'HR Assistant', 1800, 'HR'),
(3, 'Senan', 'Meherremov', 'senan@company.az', '0705556677', '2020-01-15', 'Accountant', 1200, 'Finance'),
(4, 'Aysel', 'Aliyeva', 'aysel@company.az', '0559876543', '2022-03-01', 'Software Engineer', 3000, 'IT'),
(5, 'Rauf', 'Huseynov', 'rauf@company.az', '0508889999', '2018-07-11', 'Sales Manager', 1300, 'Sales');

--select query

SELECT * FROM Employees;

SELECT * FROM Employees WHERE Salary > 2000;

SELECT * FROM Employees WHERE Department = 'IT';

SELECT * FROM Employees ORDER BY Salary DESC;

SELECT FirstName, Salary FROM Employees;

SELECT * FROM Employees WHERE HireDate > '2020-01-01';

SELECT * FROM Employees WHERE Email LIKE '%company.az%';

--Aggregate Functions

--en yuksek mmas
SELECT MAX(Salary) FROM Employees;
--en kicik maas
SELECT MIN(Salary) FROM Employees;
--ortalama maas
SELECT AVG(Salary) FROM Employees;
--iscilerin umumi sayi
SELECT COUNT(*) FROM Employees;
--mass cem
SELECT SUM(Salary) FROM Employees;

--GROUP BY Query

--departmana gore iscilerin sayi
SELECT Department, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY Department;
--depatman uzre ortalama maas
SELECT Department, AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY Department;
--departman uzre en yksek maas
SELECT Department, MAX(Salary) as MaxSalary
FROM Employees
Group BY Department;

--UPDATE query

--id=1 mass 2800
UPDATE Employees SET Salary = 2800 WHERE EmployeeID = 1;
--it isci maas 10 % artirmaq
UPDATE Employees SET Salary = Salary * 1.10 WHERE Department = 'IT';
--hr manager -> leyla hasanov
UPDATE Employees SET JobTitle = 'HR Manager'
WHERE FirstName = 'Leyla' AND LastName = 'Hasanova';
--id 5 sil
DELETE FROM Employees WHERE EmployeeID = 5;
--maas<1500 sil
DELETE FROM Employees WHERE Salary < 1500;

--elave query

--adinda a olan isci
SELECT * FROM Employees WHERE FirstName LIKE '%a%';
--maas 2000 2500 arasi
SELECT * FROM Employees WHERE Salary BETWEEN 2000 AND 2500;
--maliye ve it calisanlari
SELECT * FROM Employees WHERE Department IN ('Finance', 'IT');



