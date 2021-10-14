CREATE DATABASE [School]

USE [School]

-- Problem 1
CREATE TABLE [Students]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(30) NOT NULL,
	[MiddleName] NVARCHAR(25),
	[LastName] NVARCHAR(30) NOT NULL,
	[Age] INT,
	CHECK ([Age] BETWEEN 5 AND 100),
	[Address] NVARCHAR(50),
	[Phone] NVARCHAR(10),
	CHECK (LEN([Phone]) = 10)
)

CREATE TABLE [Subjects]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	[Lessons] INT NOT NULL,
	CHECK ([Lessons] > 0)
)

CREATE TABLE [StudentsSubjects]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[StudentId] INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL,
	[SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL,
	[Grade] DECIMAL(18, 2) NOT NULL,
	CHECK ([Grade] BETWEEN  2 AND 6)
)

CREATE TABLE [Exams]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Date] DATETIME2,
	[SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentId] INT FOREIGN KEY REFERENCES [Students] ([Id]) NOT NULL,
	[ExamId] INT FOREIGN KEY REFERENCES [Exams] ([Id]) NOT NULL,
	[Grade] DECIMAL(18, 2) NOT NULL,
	CHECK([Grade] BETWEEN 2 AND 6),
	PRIMARY KEY ([StudentId], [ExamId])
)

CREATE TABLE [Teachers]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20),
	[Phone] NVARCHAR(10),
	CHECK(LEN([Phone]) = 10),
	[SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL
)

CREATE TABLE [StudentsTeachers]
(
	[StudentId] INT FOREIGN KEY REFERENCES [Students] ([Id]) NOT NULL,
	[TeacherId] INT FOREIGN KEY REFERENCES [Teachers] ([Id]) NOT NULL,
	PRIMARY KEY ([StudentId], [TeacherId])
)

-- Problem 2

INSERT INTO [Teachers] ([FirstName], [LastName], [Address], [Phone], [SubjectId]) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction','3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza','3324874824', 4),
('Merrile', 'Lambdin', '81 Dahle Plaza','4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle','4409584510', 2)

INSERT INTO [Subjects] ([Name], [Lessons]) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

-- Problem 3
UPDATE [StudentsSubjects]
SET [Grade] = 6.00
WHERE [Grade] >= 5.50 AND [SubjectId] IN (1, 2)

-- Problem 4
DELETE FROM [StudentsTeachers]
WHERE [TeacherId] IN (SELECT [Id] FROM [Teachers] WHERE [Phone] LIKE '%72%')

DELETE FROM [Teachers]
WHERE [Phone] LIKE '%72%'


-- Problem 5
SELECT [FirstName], [LastName], [Age] FROM [Students]
WHERE [Age] >= 12
ORDER BY [FirstName], [LastName]

-- Problem 6
SELECT s.[FirstName], s.[LastName], COUNT(st.[TeacherId]) AS [TeachersCount] FROM [Students] AS s
JOIN [StudentsTeachers] AS st
ON st.[StudentId] = s.[Id]
GROUP BY s.[FirstName], s.[LastName]

-- Problem 7
SELECT CONCAT(s.[FirstName], ' ', s.[LastName]) AS [Full Name] FROM [Students] AS s
LEFT JOIN [StudentsExams] AS sx
ON s.[Id] = sx.[StudentId]
WHERE sx.[ExamId] IS NULL
ORDER BY [Full Name]

-- Problem 8
SELECT TOP(10) s.[FirstName], s.[LastName], CAST(ROUND(AVG(sx.[Grade]), 2) AS DECIMAL(18,2)) AS [Grade] FROM [Students] AS s
LEFT JOIN [StudentsExams] AS sx
ON s.[Id] = sx.[StudentId]
GROUP BY s.[FirstName], s.[LastName]
ORDER BY [Grade] DESC, s.[FirstName], s.[LastName]

-- Problem  9
SELECT REPLACE(CONCAT(s.[FirstName], ' ', ISNULL(s.[MiddleName], ''), ' ', s.[LastName]), '  ', ' ') AS [Full Name] FROM [Students] AS s
LEFT JOIN [StudentsSubjects] AS ss
ON s.[Id] = ss.[StudentId]
WHERE ss.[SubjectId] IS NULL
ORDER BY [Full Name]

-- Problem 10
SELECT su.[Name], AVG(ss.[Grade]) FROM [Students] AS st
JOIN [StudentsSubjects] AS ss
ON st.[Id] = ss.[StudentId]
JOIN [Subjects] AS su
ON ss.[SubjectId] = su.[Id]
GROUP BY su.[Id], su.[Name]
ORDER BY su.[Id]

-- Problem 11
CREATE OR ALTER FUNCTION dbo.udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18,2))
RETURNS NVARCHAR(MAX) 
AS
BEGIN
	IF (@grade > 6.00) RETURN 'Grade cannot be above 6.00!'
	IF (@StudentId NOT IN (SELECT [Id] FROM [Students])) RETURN ('The student with provided id does not exist in the school!')

	DECLARE @studentFirstName NVARCHAR(20) = (SELECT TOP(1) [FirstName] FROM [Students] WHERE [Id] = @studentId);
	DECLARE @biggestGrade DECIMAL(15,2) = @grade + 0.50;
	DECLARE @count INT = (SELECT Count([Grade]) FROM [StudentsExams]
	WHERE [StudentId] = @studentId AND [Grade] >= @grade AND [Grade] <= @biggestGrade)
	RETURN ('You have to update ' + CAST(@count AS nvarchar(10)) + ' grades for the student ' + @studentFirstName)

END

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

-- Problem 12
CREATE PROC dbo.usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF (@StudentId NOT IN (SELECT [Id] FROM [Students]))
	BEGIN 
		THROW 50001, 'This school has no student with the provided id!', 1
	END

	DELETE FROM [StudentsExams]
	WHERE [StudentId] = @StudentId

	DELETE FROM [StudentsTeachers]
	WHERE [StudentId] = @StudentId

	DELETE FROM [StudentsSubjects]
	WHERE [StudentId] = @StudentId

	DELETE FROM [Students]
	WHERE [Id] = @StudentId
END