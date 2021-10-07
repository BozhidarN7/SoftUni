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
	SELECT e.[FirstName], e.[LastName] FROM [Employees] AS e
	LEFT JOIN [Addresses] AS a
	ON e.[AddressID] = a.[AddressID]
	LEFT JOIN [Towns] AS t
	ON a.[TownID] = t.[TownID]
	WHERE t.[Name] = @townName

EXEC dbo.usp_GetEmployeesFromTown 'sofia'

DROP PROC dbo.usp_GetEmployeesFromTown 

-- Problem 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(50)
AS 
BEGIN
	IF (@salary < 30000)
	BEGIN
		RETURN 'Low'
	END
	IF (@salary BETWEEN 30000 AND 50000)
	BEGIN 
		RETURN 'Average'
	END

	RETURN 'High'
END

SELECT [Salary], dbo.ufn_GetSalaryLevel([Salary]) AS [Salary Level] FROM [Employees] 

-- Problem 6
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(50))
AS 
	SELECT [FirstName], [LastName] FROM [Employees]
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @salaryLevel

EXEC  dbo.usp_EmployeesBySalaryLevel 'high'

-- Problem 7
CREATE FUNCTION dbo.ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE	@index INT = 0
	WHILE (@index < LEN(@word))
		BEGIN 
			IF (@word NOT LIKE '%' + SUBSTRING(@setOfLetters, @index, 1) + '%')
				BEGIN 
					RETURN 0
				END
			@index += 1
		END
	RETURN 1
END

SELECT * FROM [Employees] 
SELECT * FROM [Towns]