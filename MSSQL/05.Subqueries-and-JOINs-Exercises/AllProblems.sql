-- Problem 1
SELECT TOP (5) e.[EmployeeID], e.[JobTitle], a.[AddressID], a.[AddressText] FROM [Employees] AS [e]
	INNER JOIN [Addresses] AS [a]
	ON e.[AddressID] = a.[AddressID]
	ORDER BY e.[AddressID]

-- Problem 2	


SELECT TOP (50) e.[FirstName], e.[LastName], t.[Name], a.[AddressText] AS [Town] FROM [Employees] AS e
INNER JOIN [Addresses] AS a
ON e.[AddressID] = a.[AddressID]
INNER JOIN [Towns] as t
ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName], e.[LastName]

-- Problem 3

SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name] AS [DepartmentName] FROM [Employees] AS e
INNER JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID] AND d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]

-- Problem 4
SELECT TOP (5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name] AS [DepartmentName] FROM [Employees] AS e
INNER JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[Salary] > 15000
ORDER BY  d.[DepartmentID]

SELECT * FROM [Employees]
SELECT * FROM [Addresses]
SELECT * FROM [Towns]
SELECT * FROM [Departments]