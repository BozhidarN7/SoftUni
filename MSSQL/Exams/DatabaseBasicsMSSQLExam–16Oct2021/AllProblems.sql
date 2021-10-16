CREATE DATABASE [CigarShop]

USE [CigarShop]

-- Problem 1

CREATE TABLE [Sizes]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Length] INT NOT NULL,
	CHECK ([Length] BETWEEN 10 AND 25),
	[RingRange] DECIMAL(18, 2) NOT NULL,
	CHECK ([RingRange] BETWEEN 1.5 AND 7.5)
)

CREATE TABLE [Tastes]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[TasteType] VARCHAR(20) NOT NULL,
	[TasteStrength] VARCHAR(15) NOT NULL,
	[ImageUrl] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Brands]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[BrandName] VARCHAR(30) UNIQUE NOT NULL,
	[BrandDescription] VARCHAR(MAX)
)

CREATE TABLE [Cigars]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[CigarName] VARCHAR(80) NOT NULL,
	[BrandId] INT FOREIGN KEY REFERENCES [Brands]([Id]),
	[TastId] INT FOREIGN KEY REFERENCES [Tastes]([Id]) NOT NULL,
	[SizeId] INT FOREIGN KEY REFERENCES [Sizes]([Id]) NOT NULL,
	[PriceForSingleCigar] DECIMAL(18, 2) NOT NULL,
	[ImageUrl] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Town] VARCHAR(30) NOT NULL,
	[Country] NVARCHAR(30) NOT NULL,
	[Streat] NVARCHAR(100) NOT NULL,
	[ZIP] VARCHAR(20) NOT NULL
)

CREATE TABLE [Clients]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [ClientsCigars]
(
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([Id]) NOT NULL,
	[CigarId] INT FOREIGN KEY REFERENCES [Cigars]([Id]) NOT NULL,
	PRIMARY KEY ([ClientId], [CigarId])
)


-- Problem 2
INSERT INTO [Cigars] ([CigarName], [BrandId], [TastId], [SizeId], [PriceForSingleCigar], [ImageUrl]) VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO [Addresses] ([Town], [Country], [Streat], [ZIP]) VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

-- Problem 3
UPDATE [Cigars]
SET [PriceForSingleCigar] += [PriceForSingleCigar] * 0.2
WHERE [TastId] = 1

UPDATE [Brands]
SET [BrandDescription] = 'New description'
WHERE [BrandDescription] IS NULL

-- Problem 4
DELETE FROM [Clients]
WHERE [AddressId] IN (SELECT [Id] FROM [Addresses] WHERE LEFT([Country], 1) = 'C')

DELETE FROM [Addresses]
WHERE LEFT([Country], 1) = 'C'

-- Problem 5
SELECT [CigarName], [PriceForSingleCigar], [ImageUrl] FROM [Cigars]
ORDER BY [PriceForSingleCigar], [CigarName] DESC

-- Problem 6
SELECT c.[Id], c.[CigarName], c.[PriceForSingleCigar], t.[TasteType], t.[TasteStrength] FROM [Cigars] AS c
JOIN [Tastes] AS t
ON c.[TastId] = t.[Id]
WHERE t.[TasteType] = 'Earthy' OR t.[TasteType] = 'Woody'
ORDER BY c.[PriceForSingleCigar] DESC

-- Problem 7

SELECT c.[Id], CONCAT(c.[FirstName], ' ', c.[LastName]) AS [ClientName], c.[Email] FROM [Clients] AS c
LEFT JOIN [ClientsCigars] AS cc
ON c.[Id] = cc.[ClientId]
WHERE cc.[ClientId] IS NULL
ORDER BY [ClientName]

-- Problem 8
SELECT TOP(5) * FROM [Cigars] AS c
JOIN [Sizes] AS s
ON c.[SizeId] = s.[Id]
WHERE c.[CigarName] LIKE '%ci%' AND s.[Length] >= 12
ORDER BY c.[CigarName] ASC, c.[PriceForSingleCigar] DESC

SELECT TOP(5) * FROM [Cigars] AS c
JOIN [Sizes] AS s
ON c.[SizeId] = s.[Id]
WHERE c.[PriceForSingleCigar] > 50 AND s.[RingRange] > 2.55
ORDER BY c.[CigarName] ASC, c.[PriceForSingleCigar] DESC

SELECT TOP(5) c.[CigarName], c.[PriceForSingleCigar], c.[ImageUrl] FROM [Cigars] AS c
JOIN [Sizes] AS s
ON c.[SizeId] = s.[Id]
WHERE (c.[CigarName] LIKE '%ci%' AND s.[Length] >= 12 OR c.[PriceForSingleCigar] > 50 AND s.[RingRange] > 2.55) AND c.[BrandId] NOT IN (6, 15)
ORDER BY c.[CigarName] ASC, c.[PriceForSingleCigar] DESC

SELECT * FROM [Brands]
where [Id] = 6

-- Problem 9
SELECT CONCAT(c.[FirstName], ' ' ,c.[LastName]) AS [FullName], a.[Country], a.[ZIP], CONCAT('$', (MAX(ci.[PriceForSingleCigar]))) AS [CigarPrice] FROM [Clients] AS c
JOIN [Addresses] AS a
ON c.[AddressId] = a.[Id]
LEFT JOIN [ClientsCigars] AS cs
ON cs.[ClientId] = c.[Id]
LEFT JOIN [Cigars] AS ci
ON cs.[CigarId] = ci.[Id]
WHERE a.[ZIP] NOT LIKE '%[^0-9]%'
GROUP BY c.[FirstName], c.[LastName], a.[Country], a.[ZIP]
ORDER BY [FullName]

-- Problem 10
SELECT c.[LastName], AVG(s.[Length]) AS [CiagrLength], CEILING((AVG(s.[RingRange]))) AS[CiagrRingRange] FROM [Clients] AS c
LEFT JOIN [ClientsCigars] AS cs
ON cs.[ClientId] = c.[Id]
LEFT JOIN [Cigars] AS ci
LEFT JOIN [Sizes] AS s
ON ci.[SizeId] = s.[Id]
ON cs.[CigarId] = ci.[Id]
WHERE cs.[CigarId] IS NOT NULL
GROUP BY C.[LastName]
ORDER BY [CiagrLength] DESC

-- Problem 11
CREATE FUNCTION dbo.udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) FROM [Clients] AS c
	LEFT JOIN [ClientsCigars] AS cc
	ON cc.[ClientId] = c.[Id]
	WHERE c.[FirstName] = @name)
END

SELECT  dbo.udf_ClientWithCigars('Betty')

-- Problem 12
CREATE PROC dbo.usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT c.[CigarName]
	, CONCAT('$',c.[PriceForSingleCigar]) AS [Price]
	, t.[TasteType]
	, b.[BrandName]
	, CONCAT(s.[Length],' cm') AS [CigarLength]
	, CONCAT(s.[RingRange],' cm') AS [CigarRingRange]
	FROM [Cigars] AS c
	LEFT JOIN [Tastes] AS t
	ON c.[TastId] = t.[Id]
	LEFT JOIN [Sizes] AS s
	ON c.[SizeId] = s.[Id]
	LEFT JOIN [Brands] AS b
	ON c.[BrandId] = b.[Id]
	WHERE t.[TasteType] = @taste
	ORDER BY [CigarLength], [CigarRingRange] DESC

EXEC dbo.usp_SearchByTaste 'Woody'




SELECT * FROM [Cigars]
SELECT * FROM [Addresses]
SELECT * FROM [Tastes]

