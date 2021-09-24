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


-- Problem 12
SELECT * FROM [Countries]
