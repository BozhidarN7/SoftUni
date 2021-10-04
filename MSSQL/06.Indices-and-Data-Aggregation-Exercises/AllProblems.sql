-- Prolbem 1

SELECT COUNT(*) AS [Count] FROM [WizzardDeposits]

-- Problem 2
SELECT TOP(1) [MagicWandSize] AS [LongestMagicWand] FROM [WizzardDeposits]
GROUP BY [MagicWandSize]
ORDER BY [MagicWandSize] DESC

-- Problem 3
SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand] FROM [WizzardDeposits]
GROUP BY [DepositGroup]

-- Problem 4
SELECT TOP(2) [DepositGroup] FROM
	(SELECT [DepositGroup], AVG([MagicWandSize]) AS [AvgMagicWand] FROM [WizzardDeposits]
	GROUP BY [DepositGroup]) AS [AvgWandSize]
ORDER BY [AvgMagicWand] 

-- Problem 5
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [WizzardDeposits]
GROUP BY [DepositGroup]

-- Problem 6 
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

-- Problem 7

SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS [MinDepositCharge] FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

-- Problem 9
SELECT [AgeGroup], COUNT(*) AS [WizzardCount] FROM (SELECT
	CASE
		WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS [AgeGroup]
FROM [WizzardDeposits]) AS [subquery]
GROUP BY [AgeGroup]

-- Problem 10
SELECT * FROM (SELECT LEFT([FirstName],1) AS [FirstLetter] FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest') AS [subquery]
GROUP BY [FirstLetter]

-- Problem 11
SELECT [DepositGroup], [IsDepositExpired], AVG([DepositInterest]) AS [AverageInterest] FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

-- Problem 12
SELECT SUM([Difference]) AS [SumDifference] FROM 
	(SELECT 
	[FirstName] AS [Host Wizard]
	, [DepositAmount] AS [Host Wizard Deposit]
	, LEAD([FirstName]) OVER (ORDER BY [Id]) AS [Guest Wizard]
	, LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizard Deposit]
	, [DepositAmount] - LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Difference]
	FROM [WizzardDeposits]) AS [Subquery]

-- Problem 13
SELECT [DepartmentId], SUM([Salary]) AS [TotalSalary] FROM [Employees]
GROUP BY [DepartmentId]
ORDER BY [DepartmentId]

-- Problem 14
SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary] FROM [Employees]
WHERE [HireDate] > '01.01.2000' AND [DepartmentID] IN (2, 5, 7)
GROUP BY [DepartmentID]

-- Problem 15
SELECT * INTO [EmployeesAverageSalaries] FROM [Employees]
WHERE [Salary] > 30000

DELETE FROM [EmployeesAverageSalaries]
WHERE [ManagerID] = 42

UPDATE [EmployeesAverageSalaries]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary] FROM [EmployeesAverageSalaries]
GROUP BY [DepartmentID]

-- Problem 16
SELECT [DepartmentID], MAX([Salary]) AS [MaxSalary] FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) < 30000 OR MAX([Salary]) > 70000

-- Problem 17
SELECT COUNT(*) AS [Count] FROM [Employees]
WHERE [ManagerID] IS NULL

-- Problem 18
SELECT [DepartmentID], MAX([Salary]) AS [ThirdHighestSalary] FROM 
	(SELECT *, 
	DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank] 
	FROM [Employees]) AS [Subquery]
WHERE [Rank] = 3
GROUP BY [DepartmentID]

-- Problem 19
SELECT TOP(10) [FirstName], [LastName], [DepartmentID] FROM [Employees] AS outsub
WHERE [Salary] > (
				SELECT AVG([Salary]) AS [AvgSalary] FROM [Employees] AS insub
				WHERE outsub.[DepartmentID] = insub.[DepartmentID]
				GROUP BY [DepartmentID]) 
ORDER BY[DepartmentID]
	


SELECT * FROM [WizzardDeposits]