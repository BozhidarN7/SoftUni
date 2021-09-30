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

-- Problem 5

SELECT TOP (3) e.[EmployeeID], e.[FirstName] FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
ON  e.[EmployeeID] = ep.[EmployeeID]
WHERE ep.[ProjectID] IS NULL
ORDER BY e.[EmployeeID]

-- Problem 6
SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS [DeptName] FROM [Employees] AS e
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[HireDate] > '1.1.1999' AND d.[Name] IN ('Finance', 'Sales')
ORDER BY e.[HireDate]

-- Problem 7
SELECT TOP (5) e.[EmployeeID], e.[FirstName], p.[Name] AS [ProjectName] FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep
ON e.[EmployeeID] = ep.[EmployeeID]
JOIN [Projects] AS p
ON ep.[ProjectID] = p.[ProjectID]
WHERE p.[EndDate] IS NULL AND p.[StartDate] > '08.13.2002'
ORDER BY e.[EmployeeID]

--Problem 8
SELECT e.[EmployeeID], e.[FirstName], 
CASE
	WHEN YEAR(p.[StartDate]) >= 2005 THEN NULL
	ELSE p.[Name]
END AS [ProjectName]
FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
ON e.[EmployeeID] = ep.[EmployeeID]
LEFT JOIN [Projects] AS p
ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24

-- Problem 9
SELECT a.[EmployeeID], a.[FirstName], a.[ManagerID], b.[FirstName] AS [ManagerName]
FROM [Employees] AS a
JOIN [Employees] as b
ON a.[ManagerID] = b.[EmployeeID]
WHERE a.[ManagerID] IN (3, 7)
ORDER BY a.[EmployeeID]

-- Problem 10
SELECT TOP (50) 
e.[EmployeeID]
, CONCAT(e.[FirstName], ' ',e.[LastName]) AS [EmployeeName]
, CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName]
, d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Employees] AS m
ON e.[ManagerID] = m.[EmployeeID]
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]

-- Problem 11
SELECT TOP (1) AVG(e.[Salary]) AS [MinAverageSalary] FROM [Employees] AS e
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
GROUP BY d.[Name]
ORDER BY [MinAverageSalary]

-- Problem 12
SELECT mc.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation] FROM [Peaks] AS p
LEFT JOIN [Mountains] AS m
ON p.[MountainId] = m.[Id]
LEFT JOIN [MountainsCountries] AS mc
ON m.[Id] = mc.[MountainId]
WHERE p.Elevation > 2835 AND mc.[CountryCode] = 'BG'
ORDER BY p.[Elevation] DESC

-- Problem 13

SELECT c.[CountryCode], COUNT(mc.[MountainId]) AS [MountainRanges] FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
WHERE c.[CountryCode] IN ('BG', 'US', 'RU')
GROUP BY c.[CountryCode]

-- Problem 14
SELECT TOP (5) c.[CountryName], r.[RiverName] FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
WHERE c.[ContinentCode] = 'AF'
ORDER BY c.[CountryName]

-- Problem 15
SELECT [ContinentCode], [CurrencyCode], [CurrencyCount] AS [CurrencyUsage]
FROM 
	(SELECT *
		, DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) AS [CurrencyRank]
		FROM
			(SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyCount]
			FROM [Countries]
			GROUP BY [ContinentCode], [CurrencyCode]) AS [CurrencyCountSubQuery]
	WHERE [CurrencyCount] > 1) AS [CurrencyRankingSubQuery]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]

-- Problem 16
SELECT COUNT(c.[CountryCode]) AS [Count] FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
WHERE mc.[MountainId] IS NULL

-- Problem 17
SELECT TOP(5) c.[CountryName], MAX(p.[Elevation]) AS [HighestPeakElevation], MAX(r.[Length]) AS [LongestRiverLength] FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN  [Mountains] AS m
ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p
ON m.[Id] = p.[MountainId]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC,[LongestRiverLength] DESC, c.[CountryName]

-- Problem 18
SELECT TOP (5)	
[CountryName] AS [Country]
,ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name]
,ISNULL([Elevation], 0) AS [Highest Peak Elevation]
,ISNULL([MountainRange], '(no mountain)') AS [Mountain]
FROM 
(
	SELECT c.[CountryName], p.[PeakName], p.[Elevation], m.[MountainRange]  ,DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation]) AS [PeakRank] FROM [Countries] AS c
	LEFT JOIN [CountriesRivers] AS cr
	ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN [Rivers] AS r
	ON cr.[RiverId] = r.[Id]
	LEFT JOIN [MountainsCountries] AS mc
	ON c.[CountryCode] = mc.[CountryCode]
	LEFT JOIN  [Mountains] AS m
	ON mc.[MountainId] = m.[Id]
	LEFT JOIN [Peaks] AS p
	ON m.[Id] = p.[MountainId]
) AS [PeakRankingSubQuery]
WHERE [PeakRank] = 1
ORDER BY [CountryName], [PeakName]

SELECT * FROM [Peaks]
SELECT * FROM [Mountains]
SELECT * FROM [Countries]
SELECT * FROM [MountainsCountries]
SELECT * FROM [Rivers]
SELECT * FROM [Continents]
SELECT * FROM [Currencies]

