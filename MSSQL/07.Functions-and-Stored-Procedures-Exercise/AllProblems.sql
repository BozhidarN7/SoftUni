-- Problem 1
CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000 
AS
	SELECT [FirstName], [LastName] FROM [Employees]
	WHERE [Salary] > 35000

EXEC dbo.usp_GetEmployeesSalaryAbove35000 

-- Problem 2
CREATE PROC dbo.usp_GetEmployeesSalaryAboveNumber(@input DECIMAL(18, 4))
AS 
	SELECT [FirstName], [LastName] FROM [Employees]
	WHERE [Salary] >= @input

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

-- Problem 3
CREATE PROC dbo.usp_GetTownsStartingWith(@townName NVARCHAR(50))
AS 
	SELECT [Name] AS [Town] FROM [Towns]
	WHERE [Name] LIKE @townName + '%'

EXEC dbo.usp_GetTownsStartingWith 'b'


-- Problem 4
CREATE PROC dbo.usp_GetEmployeesFromTown(@townName NVARCHAR(50))
AS 
	SELECT * FROM [Employees] AS e
	LEFT JOIN [Addresses] AS a
	ON e.[AddressID] = a.[AddressID]
	LEFT JOIN [Towns] AS t
	ON a.[AddressID] = t.[TownID]
	WHERE LOWER(t.[Name]) = LOWER(@townName)

EXEC dbo.usp_GetEmployeesFromTown 'sofia'

DROP PROC dbo.usp_GetEmployeesFromTown 



SELECT * FROM [Employees] 
SELECT * FROM [Towns]