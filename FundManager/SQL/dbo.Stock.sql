CREATE TABLE [dbo].[Stock]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Type] INT NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] DECIMAL(18,4) NOT NULL,
	[Occurance] INT NOT NULL,
	[Tolerance] DECIMAL (18,4) NOT NULL,
	[Cost] DECIMAL (18,4) NOT NULL
)
