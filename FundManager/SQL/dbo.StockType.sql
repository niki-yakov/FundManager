CREATE TABLE [dbo].[StockType] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Type]       INT           NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Occurence] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

