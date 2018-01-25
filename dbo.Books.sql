CREATE TABLE [dbo].[Books] (
    [ISBN] VARCHAR(20)           NOT NULL,
    [Title]  VARCHAR (MAX) NOT NULL,
    [Author]  VARCHAR(50)    NOT NULL, 
    [BasePrice] FLOAT NOT NULL, 
    [TotalSales] FLOAT NOT NULL, 
    [TotalQuantityRented] INT NOT NULL, 
    [TotalQuantitySold] INT NOT NULL
);

