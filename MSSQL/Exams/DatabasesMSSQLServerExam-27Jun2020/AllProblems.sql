CREATE DATABASE [WMS]

-- Problem 1
CREATE TABLE [Clients]
(
	[ClientId] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Phone] VARCHAR(50) NOT NULL,
	CHECK (LEN([Phone]) = 12)
)

CREATE TABLE [Mechanics]
(
	[MechanicId] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Models]
(
	[ModelId] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Jobs]
(
	[JobId] INT PRIMARY KEY IDENTITY NOT NULL,
	[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId]) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' NOT NULL,
	CHECK ([Status] IN ('Pending', 'In Progress', 'Finished')),
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]) NOT NULL,
	[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]) NOT NULL,
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE

)

CREATE TABLE [Orders]
(
	[OrderId] INT PRIMARY KEY IDENTITY NOT NULL,
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[IssueDate] DATE,
	[Delivered] BIT DEFAULT 0
)

CREATE TABLE [Vendors]
(
	[VendorId] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Parts]
(	
	[PartId] INT PRIMARY KEY IDENTITY NOT NULL,
	[SerialNumber] VARCHAR(50) NOT NULL UNIQUE,
	[Description] VARCHAR(255),
	[Price] DECIMAL(6, 2) NOT NULL,
	CHECK ([Price] > 0),
	[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) NOT NULL,
	[StockQty] INT DEFAULT 0,
	CHECK ([StockQty] >= 0)
)

CREATE TABLE [OrderParts]
(
	[OrderId] INT FOREIGN KEY REFERENCES [Orders]([OrderId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	[Quantity] INT DEFAULT 1,
	CHECK ([Quantity] > 0),
	PRIMARY KEY ([OrderId], [PartId])
)

CREATE TABLE [PartsNeeded]
(
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	[Quantity] INT DEFAULT 1,
	CHECK ([Quantity] > 0),
	PRIMARY KEY ([JobId], [PartId])
)

-- Problem 2
INSERT INTO [Clients] ([FirstName], [LastName], [Phone]) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO [Parts] ([SerialNumber], [Description], [Price], [VendorId]) VALUES 
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive ', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)


-- Problem 3

UPDATE [Jobs]
SET [MechanicId] = 3
WHERE [Status] = 'Pending'

UPDATE [Jobs]
SET [Status] = 'In Progress'
WHERE [Status] = 'Pending'

SELECT * FROM [Vendors]