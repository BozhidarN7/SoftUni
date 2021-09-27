Use [SoftUni]

-- Problem 1

SELECT [FirstName], [LastName] FROM [Employees]
WHERE SUBSTRING([FirstName],1,2) = 'Sa'

-- Problem 2

SELECT [FirstName], [LastName] FROM [Employees]
WHERE CHARINDEX('ei',[LastName]) > 0

-- Problem 3

SELECT [FirstName] FROM [Employees]
WHERE ([DepartmentID] = 3 OR [DepartmentID] = 10) AND DATEPART(YEAR, [HireDate]) BETWEEN 1995 AND 2005

SELECT * FROM [Employees]

-- Problem 4

SELECT [FirstName], [LastName] FROM [Employees]
WHERE [JobTitle] NOT LIKE  ('%engineer%')

-- Problem 5

SELECT [Name] FROM [Towns]
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

-- Problem 6

SELECT [TownId], [Name] FROM [Towns]
WHERE [Name] LIKE ('[MKBE]%')
ORDER BY [Name]

-- Problem 7
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [TownID], [Name] FROM [Towns]
WHERE [Name] NOT LIKE ('[RBD]%')

SELECT * FROM V_EmployeesHiredAfter2000
ORDER BY [Name]

-- Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName] FROM [Employees]
WHERE DATEPART(YEAR, [HireDate]) > 2000

-- Problem 9 
SELECT[FirstName], [LastName] FROM [Employees]
WHERE LEN([LastName]) = 5

-- Problem 10
SELECT 
	  [EmployeeID]
	, [FirstName]
	, [LastName]
	, [Salary] 
	, DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM [Employees] 
	WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY [Salary] DESC

-- Problem 11
SELECT * FROM 
(SELECT 
	  [EmployeeID]
	, [FirstName]
	, [LastName]
	, [Salary] 
	, DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM [Employees] 
	WHERE [Salary] BETWEEN 10000 AND 50000)
AS [RankingTable]
WHERE Rank = 2
ORDER BY [Salary] DESC	


-- Problem 12

SELECT [CountryName] AS 'Country Name', [IsoCode] AS 'ISO Code' FROM [Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

-- Problem 13
SELECT [p].[PeakName], [r].[RiverName], LOWER(CONCAT(LEFT([p].[PeakName], LEN([p].[PeakName]) - 1),[r].[RiverName])) AS [Mix] FROM [Peaks] AS p, [Rivers] as r
WHERE RIGHT([p].[PeakName], 1) = LEFT([r].[RiverName], 1)
ORDER BY [Mix]

-- Problem 14

SELECT TOP (50) [Name], FORMAT(CAST([Start] AS DATE), 'yyyy-MM-dd') AS [Start] FROM [Games]
WHERE DATEPART(YEAR, [Start]) = 2011 OR DATEPART(YEAR, [Start]) = 2012
ORDER BY [Start] ,[Name]

-- Problem 15

SELECT [Username], RIGHT([Email],LEN([Email]) - CHARINDEX('@', [Email])) AS [Email Provider] FROM [Users]
ORDER BY [Email Provider], [Username]

-- Problem 16
SELECT [Username], [IpAddress] AS [IP Address] FROM [Users]
WHERE [IpAddress] LIKE '___.1%%.___'
ORDER BY [Username]

-- Problem 17

SELECT 
	[Name] AS [Game]
	, CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	  END AS [Part of the Day]
	, CASE
		WHEN [Duration] <=3 THEN 'Extra Short'
		WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	  END AS [Duration]
FROM [Games]
ORDER BY [Name], [Duration], [Part of the Day]

-- Problem 18

SELECT [ProductName], [OrderDate], DATEADD("d", 3, [OrderDate]) AS [Pay Due], DATEADD("m", 1, [OrderDate]) AS [Deliver Due] FROM [Orders]

-- Problem 19

CREATE TABLE [People]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[BirthDate] DATETIME2 NOT NULL
)


INSERT INTO [People] VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '1910-09-19 00:00:00.000')

SELECT 
	  [Name]
	, DATEDIFF(YEAR, [BirthDate], GETDATE()) AS [Age in Years]
	, DATEDIFF(MONTH, [BirthDate], GETDATE()) AS [Age in Months]
	, DATEDIFF(Day, [BirthDate], GETDATE()) AS [Age in Days]
	, DATEDIFF(MINUTE, [BirthDate], GETDATE()) AS [Age in Minutes]
FROM [People]

SELECT * FROM [People]