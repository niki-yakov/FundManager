CREATE TABLE [dbo].[StockProperties]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Cost] DECIMAL(18,4) NOT NULL,
	[BondOccurance] INT NOT NULL,
	[EquityOccurance] INT NOT NULL,
	[Tolerance] DECIMAL (18,4) NOT NULL
)
