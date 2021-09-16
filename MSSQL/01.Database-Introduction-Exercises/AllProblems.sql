CREATE DATABASE [Minions]

CREATE TABLE [Minions]
(
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL,
)

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE [Minions]
ADD [TownId] INT NOT NULL

ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsTownId] FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT NULL

INSERT INTO [Towns] ([Id], [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId]) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

TRUNCATE TABLE [Minions]
DROP TABLE [Minions]
DROP TABLE [Towns]

-- Problem 7
CREATE TABLE [People]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX)
	CHECK (DATALENGTH([Picture]) <= 2000 * 1024),
	[Height] FLOAT(2),
	[Weight] FLOAT(2),
	[Gender] char(2) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)

)

INSERT INTO [People] ([Name], [Gender], [Birthdate]) VALUES
('Person1', 'm', GETDATE()),
('Person2', 'm', GETDATE()),
('Person3', 'f', GETDATE()),
('Person4', 'm', GETDATE()),
('Person5', 'f', GETDATE())

-- Problem 8
CREATE TABLE [Users]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,	
	[ProfilePicture] VARBINARY(MAX)
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)

INSERT INTO [Users] ([Username], [Password]) VALUES
('Ivan', 'Ivan123'),
('Stefan', 'Stefan123'),
('Emil', 'Emil23'),
('Peter', 'Peter123'),
('George', 'George123')

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC073CAEBA49

-- Problem 9

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersIdUsername] PRIMARY KEY ([Id], [Username])

-- Problem 10

ALTER TABLE [Users]
ADD CONSTRAINT [CHK_PasswordLength] CHECK (LEN([Password]) > 5)

INSERT INTO [Users] ([Username], [Password]) VALUES ('Spas', '123')

-- Porblem 11
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO [Users] ([Username], [Password]) VALUES ('Sisi', '123456')

-- Problem 12
ALTER TABLE [Users]
DROP CONSTRAINT PK_UsersIdUsername

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersId] PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [CHK_UsernameLength] CHECK (LEN([Username]) >= 3)

INSERT INTO [Users] ([Username], [Password]) VALUES ('Si', '123456')

SELECT * FROM [Users]

-- Problem 13

CREATE DATABASE [Movies]

CREATE TABLE [Directors]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[CategoryName] NVARCHAR(50) NOT NULL, 
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Movies]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] BIGINT FOREIGN KEY REFERENCEs [Directors]([Id]),
	[CopyrightYear] VARCHAR(30) NOT NULL,
	[Length] VARCHAR(30) NOT NULL,
	[GenreId] BIGINT FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId] BIGINT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating] INT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName]) VALUES
('Ivan'), ('Stamat'), ('Pesho'), ('Gosho'), ('Boris')

INSERT INTO [Genres] ([GenreName]) VALUES
('Fantasy'), ('Historical fiction'), ('Contemporary fiction,'), ('Mystery'), ('Science fiction')

INSERT INTO [Categories] ([CategoryName]) VALUES
('Fantasy'), ('Historical fiction'), ('Contemporary fiction,'), ('Mystery'), ('Science fiction')

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId]) VALUES
('Fast and Furious 1', 1, '2001', '2 hours', 3, 2),
('Fast and Furious 2', 2, '2001', '2 hours', 3, 2),
('Fast and Furious 3', 3, '2001', '2 hours', 3, 2),
('Fast and Furious 4', 1, '2001', '2 hours', 3, 2),
('Fast and Furious 5', 1, '2001', '2 hours', 3, 2)


SELECT * FROM [Movies]

-- Problem 14
CREATE DATABASE [CarRental]

CREATE TABLE [Categories]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] INT,
	[WeeklyRate] INT,
	[MontlyRate] INT,
	[WeekendRate] INT
)

CREATE TABLE [Cars]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[PlateNumber] NVARCHAR(20) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] INT,
	[CategoryId] BIGINT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Doors] INT,
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(100),
	[Available] BIT
)

CREATE TABLE [Employees]
(
	[Id]  BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(40) NOT NULL,
	[LastName] NVARCHAR(40) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[NOTES] NVARCHAR(MAX)
)

CREATE TABLE [Customers]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[DriverLicenceNumber] VARCHAR(30) NOT NULL,
	[FullName] NVARCHAR(60) NOT NULL,
	[Address] NVARCHAR(50),
	[City] NVARCHAR(50),
	[ZipCode] NVARCHAR(30),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RentalOrders]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[EmployeeId] BIGINT FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId] BIGINT FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId] BIGINT FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel] INT,
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[TotalDays] INT,
	[RateApplies] INT,
	[OrderStatus] BIT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories] ([CategoryName]) VALUES
('Sedan'), ('hatchback'), ('Minivan')

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model]) VALUES 
('2423', 'Tesla', 'Model S'), ('2423', 'Tesla', 'Model X'), ('2423', 'Tesla', 'Model Y')

INSERT INTO [Employees] ([FirstName], [LastName], [Title]) VALUES
('Ivan', 'Ivanov','PM'), ('George', 'Georgiev','Programmer'), ('Stoqn', 'Stoqnov','CEO')

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName]) VALUES
('234234', 'Ivanov'), ('234234234', 'Georgiev'), ('43241324', 'Stoqnov')

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId]) VALUES
(1, 2, 3), (2, 1, 2),(3, 1, 2)

SELECT * FROM [RentalOrders]


-- Problem 15

CREATE DATABASE [Hotel]

CREATE TABLE [Employees]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName]  NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers]
(
	[AccountNumber] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[EmergencyName] VARCHAR(20),
	[EmergencyNumber] VARCHAR(20),
	[Notes] NVARCHAR(MAX)

)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] BIT NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomTypes]
(
	[RoomType] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [BedTypes]
(
	[BedType] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(MAX)
)


CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY NOT NULL,
	[RoomType] NVARCHAR(20),
	[BedType] NVARCHAR(20),
	[Rate] INT,
	[RoomStatus] BIT,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Payments]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[EmployeeId] BIGINT FOREIGN KEY REFERENCES [Employees]([Id]),
	[PaymentDate] DATETIME2,
	[AccountNumber] BIGINT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[FirstDateOccupied] DATETIME2 NOT NULL,
	[LastDateOccupied] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] DECIMAL NOT NULL,
	[TaxRate] DECIMAL NOT NULL,
	[TaxAmount] DECIMAL NOT NULL,
	[PaymentTotal] DECIMAL NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Occupancies]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[EmployeeId] BIGINT FOREIGN KEY REFERENCES [Employees]([Id]),
	[DateOccupied] DATETIME2 NOT NULL,
	[AccountNumber] BIGINT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
	[RateApplied] VARCHAR(20),
	[PhoneCharge] BIT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title]) VALUES
('Ivan', 'Ivano', 'PM'), ('Ivan', 'Ivano', 'PM'), ('Ivan', 'Ivano', 'PM')

INSERT INTO [Customers] ([FirstName], [LastName], [PhoneNumber]) VALUES
('Ivan', 'Ivano', '234234'), ('Ivan', 'Ivano', '2342342'), ('Ivan', 'Ivano', '424234')

INSERT INTO [RoomStatus] ([RoomStatus]) VALUES
(1), (1), (1)

INSERT INTO [RoomTypes] ([RoomType]) VALUES
('single'), ('double'), ('single')

INSERT INTO [BedTypes] ([BedType]) VALUES
('single'), ('double'), ('single')

INSERT INTO [Payments] VALUES 
(1,GETDATE(),1,GETDATE(),GETDATE(),3,3,3,3,3,'32'),
(1,GETDATE(),1,GETDATE(),GETDATE(),3,3,3,3,3,'32'),
(1,GETDATE(),1,GETDATE(),GETDATE(),3,3,3,3,3,'32')

INSERT INTO [Occupancies] ([EmployeeId], [DateOccupied]) VALUES
(1, GETDATE()), (1, GETDATE()), (1, GETDATE())

-- Problem 16

CREATE DATABASE [SoftUni]

CREATE TABLE [Towns]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[AddressText] NVARCHAR(50) NOT NULL,
	[TownId] BIGINT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [Departments]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Employees]
(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[JobTitle] NVARCHAR(50) NOT NULL,
	[DepartmentId] BIGINT FOREIGN KEY REFERENCES [Departments]([Id]),
	[HireDate] DATETIME2 NOT NULL,
	[Salary] INT,
	[AdressId] BIGINT FOREIGN KEY REFERENCES [Addresses]([Id])
)

DROP DATABASE SoftUni

INSERT INTO [Towns] ([Name]) VALUES ('Sofia'), ('Plovdiv'), ('Burgas')
INSERT INTO [Departments] ([Name]) VALUES ('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

INSERT INTO [Employees] ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary]) VALUES
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '28/08/2016', 522.25),
('Petar', 'Pan', 'Pan', 'Intern', 3, '28/08/2016', 599.88)

SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

SELECT * FROM [Towns] ORDER BY [Name] ASC
SELECT * FROM [Departments] ORDER BY [Name] ASC
SELECT * FROM [Employees] ORDER BY [Salary] DESC

SELECT [Name] FROM [Towns] ORDER BY [Name] ASC
SELECT [Name] FROM [Departments] ORDER BY [Name] ASC
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY [Salary] DESC
