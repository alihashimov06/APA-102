--database create
CREATE DATABASE CompanyMM;

USE CompanyMM;


--table create


-- Employees

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    BirthDate DATE CHECK (BirthDate < GETDATE()),
    Email NVARCHAR(100) UNIQUE
);

-- Projects

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY,
    ProjectName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    CONSTRAINT CHK_ProjectDates CHECK (EndDate > StartDate)
);


-- Many-to-many junction

CREATE TABLE EmployeeProjects (
    EmployeeID INT,
    ProjectID INT,
    AssignedDate DATE DEFAULT GETDATE(),
    PRIMARY KEY(EmployeeID, ProjectID),
    FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
);

--create employee

INSERT INTO Employees (FirstName, LastName, BirthDate, Email)
VALUES
('Ali', 'Hashimov', '2000-05-12', 'ali@gmail.com'),
('Nurlan', 'Mammadov', '1999-09-20', 'nurlan@gmail.com'),
('Aysel', 'Aliyeva', '2001-01-01', 'aysel@gmail.com'),
('Elvin', 'Quliyev', '1998-07-15', 'elvin@gmail.com'),
('Ramil', 'Sadiqov', '1997-11-30', 'ramil@gmail.com');

--create projects

INSERT INTO Projects (ProjectName, StartDate, EndDate)
VALUES
('CRM System', '2023-01-01', '2023-12-31'),
('E-Commerce Platform', '2023-03-01', '2024-01-31'),
('Mobile Banking', '2023-06-01', '2024-06-01');

-- Relation insert

INSERT INTO EmployeeProjects (EmployeeID, ProjectID)
VALUES
(1,1),
(1,2),
(2,1),
(2,3),
(3,1),
(3,2),
(3,3),
(4,2),
(5,3);


--1 Bütün employees

SELECT * FROM Employees;

--2 Bütün projects

SELECT * FROM Projects;

--3 H?r employee-nin hans? project(l?r)-d? i?l?diyini göst?r?n sor?u (JOIN il?).


SELECT e.EmployeeID, e.FirstName, e.LastName, p.ProjectName, ep.AssignedDate
FROM Employees AS e
JOIN EmployeeProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID;

--4 H?r project-? assign edilmi? employee say? (GROUP BY il?).

SELECT p.ProjectName, COUNT(ep.EmployeeID) AS EmployeeCount
FROM Projects p
LEFT JOIN EmployeeProjects ep ON p.ProjectID = ep.ProjectID
GROUP BY p.ProjectName;

--5 2-d?n çox project-d? i?l?y?n employee-l?ri tap?n (HAVING istifad? edin).

SELECT e.EmployeeID, e.FirstName, e.LastName, COUNT(ep.ProjectID) AS ProjectCount
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
GROUP BY e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) > 2;

--6 EmployeeProjectView adl? VIEW yarad?n: h?r s?trd? EmployeeID, FullName, ProjectID, ProjectName, AssignedDate olsun.

CREATE VIEW EmployeeProjectView AS
SELECT
    e.EmployeeID,
    CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
    p.ProjectID,
    p.ProjectName,
    ep.AssignedDate
FROM Employees AS e
JOIN EmployeeProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID;

--7 View-dan istifad? ed?r?k bir employee üçün (m?s?l?n EmployeeID = 1) bütün project-l?ri göst?rin.

SELECT * FROM EmployeeProjectView WHERE EmployeeID = 1;


--8 Stored procedure yaz?n: sp_AssignEmployeeToProject(IN empId INT, IN projId INT) — ?g?r t?yinat yoxdursa, EmployeeProjects-? INSERT etsin; varsa heç n? etm?sin.

CREATE PROCEDURE sp_AssignEmployeeToProject
    @empId INT,
    @projId INT
AS

    SELECT * FROM EmployeeProjects
    WHERE EmployeeID = @empId AND ProjectID = @projId
    INSERT INTO EmployeeProjects (EmployeeID, ProjectID)
    VALUES (@empId, @projId);


--9 Function yaz?n: fn_GetProjectCount(empId INT) RETURNS INT — veril?n employee üçün project say?n? döndürsün. Function-u ça??r?b n?tic?ni göst?rin (SELECT il?).

CREATE FUNCTION fn_GetProjectCount(@empId INT)
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    SELECT @count = COUNT(ProjectID)
    FROM EmployeeProjects
    WHERE EmployeeID = @empId;
    RETURN @count;
END;

SELECT dbo.fn_GetProjectCount(1) AS ProjectCountForEmployee1;

--10 sp_AssignEmployeeToProject istifad? ed?r?k yeni t?yinat ?lav? edin v? n?tic?ni yoxlay?n.

EXEC sp_AssignEmployeeToProject 4, 1;
SELECT * FROM EmployeeProjectView WHERE EmployeeID = 4;

--11 Bir employee-nin bütün project-l?rind?n ç?xar?n (DELETE FROM EmployeeProjects WHERE EmployeeID = X) 

DELETE FROM EmployeeProjects WHERE EmployeeID = 3;
SELECT * FROM EmployeeProjectView WHERE EmployeeID = 3;
