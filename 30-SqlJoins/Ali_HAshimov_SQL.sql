CREATE DATABASE Company 
USE Company

CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(30) NOT NULL
);

CREATE TABLE Cities (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(30) NOT NULL,
    CountryId INT FOREIGN KEY REFERENCES Countries(Id)
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(30),
    Surname NVARCHAR(30),
    Age INT,
    Salary DECIMAL(10,2),
    Position NVARCHAR(30),
    IsDeleted BIT,
    CityId INT FOREIGN KEY REFERENCES Cities(Id)
);
INSERT INTO Countries(Name) VALUES ('Azerbaijan'), ('Turkey'), ('USA');

INSERT INTO Cities(Name, CountryId)
VALUES ('Baku', 1), ('Ganja', 1), ('Istanbul', 2), ('New York', 3);

INSERT INTO Employees(Name, Surname, Age, Salary, Position, IsDeleted, CityId)
VALUES 
('Ali','Hashimov',25,2500,'Reception',0,1),
('Aynur','Huseynova',30,1500,'Manager',0,2),
('Vugar','Memmedov',40,3000,'Developer',1,1),
('John','Smith',28,4500,'Reception',0,4);

--shcilerin ozlerini, yashadiqi sheherlerini ve olkelerini gosterin.

SELECT e.Name, e.Surname, c.Name, co.Name
FROM Employees AS e
JOIN Cities AS c ON e.CityId = c.Id
JOIN Countries AS co ON c.CountryId = co.Id;

--Maashi 2000-den yuxari olan ishcilerin adlari ve yashadiqi olkeleri gosterin.

SELECT e.Name, co.Name 
FROM Employees AS e
JOIN Cities AS c ON e.CityId = c.Id
JOIN Countries AS co ON c.CountryId = co.Id
WHERE e.Salary > 2000;

 --Hansi sheherin hansi olkeye aid olduqunu gosterin.

SELECT c.Name, co.Name
FROM Cities AS c
JOIN Countries AS co ON c.CountryId = co.Id;

--Positioni "Reseption" olan ishcilerin table-larin id-leri daxil olmamaq 
--sherti ile daxil olmamaq sherti ile butun melumatlarini gostermek.

SELECT e.Name, e.Surname, e.Age, e.Salary, e.Position, e.IsDeleted, c.Name 
FROM Employees AS e
JOIN Cities AS c ON e.CityId = c.Id
WHERE e.Position = 'Reception';

 --ishden cixan ishcilerin yashadiqi sheher ve olkeleri, hemcinin
 --ishcilerin oz ad ve soyadlarini gosteren query yazin.

SELECT e.Name, e.Surname, c.Name, co.Name
FROM Employees AS e
JOIN Cities AS c ON e.CityId = c.Id
JOIN Countries AS co ON c.CountryId = co.Id
WHERE e.IsDeleted = 1;

