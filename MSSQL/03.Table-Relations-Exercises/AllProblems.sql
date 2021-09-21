CREATE DATABASE [Test]

USE [Test]

-- Problem 1

CREATE TABLE [Passports]
(
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[PassportNumber] NVARCHAR(50) NOT NULL
)

CREATE TABLE Persons
(
	[PersonID] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[Salary] FLOAT(2) NOT NULL,
	[PassportID] INT NOT NULL UNIQUE
)


ALTER TABLE [Persons]
ADD CONSTRAINT [FK_PersonsPassportsID] FOREIGN KEY ([PassportID]) REFERENCES [Passports]([PassportID])

INSERT INTO [Passports] VALUES
('N34FG21B'), ('K65LO4R7'), ('ZE657QP2')

INSERT INTO [Persons] VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)


SELECT * FROM [Persons]
DROP TABLE [Persons]

-- Problem 2

CREATE TABLE [Manufacturers]
(
	[ManufacturerID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[EstablishedON] DATETIME2 NOT NULL
)


CREATE TABLE [Models]
(
	[ModelID] INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO [Manufacturers] VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO [Models] VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)


-- Problem 3

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Exams]
(
	[ExamID] INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL
)

ALTER TABLE [StudentsExams]
ADD CONSTRAINT [PK_StudentsExams] PRIMARY KEY ([StudentID], [ExamID])

INSERT INTO [Students] VALUES
('Mila'), ('Toni'), ('Ron')

INSERT INTO [Exams] VALUES
('SpringMVC') , ('Neo4j'), ('Oracle 11g')

INSERT INTO [StudentsExams] VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)


-- Problem 4

CREATE TABLE [Teachers]
(
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers] ([Name], [ManagerID]) VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

-- Problem 5

CREATE DATABASE [Test]
USE [Test]

CREATE TABLE [Cities]
(
	[CityID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE [Customers]
(
	[CustomerID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)

CREATE TABLE [ItemTypes]
(
	[ItemTypeID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)


CREATE TABLE [Items]
(
	[ItemID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [Orders]
(
	[OrderID] INT PRIMARY KEY IDENTITY NOT NULL,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

 CREATE TABLE [OrderItems]
 (
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL,
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]) NOT NULL
 )

 ALTER TABLE [OrderItems]
 ADD CONSTRAINT [PK_OrderItems] PRIMARY KEY ([OrderID], [ItemID])