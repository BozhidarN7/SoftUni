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

SELECT * FROM [WizzardDeposits]