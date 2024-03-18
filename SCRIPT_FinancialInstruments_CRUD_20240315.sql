IF NOT EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME='FinancialInstruments')
CREATE TABLE FinancialInstruments (
    ID INT PRIMARY KEY IDENTITY,
    MarketValue FLOAT,
    Type VARCHAR(50)
)

GO


IF  EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME='FinancialInstruments')
DROP PROCEDURE InsertFinancialInstrument
GO 

CREATE PROCEDURE InsertFinancialInstrument
    @MarketValue FLOAT,
    @Type VARCHAR(50)
AS
BEGIN
    INSERT INTO FinancialInstruments (MarketValue, Type)
    VALUES (@MarketValue, @Type)
END

GO

IF  EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME='UpdateFinancialInstrument')
DROP PROCEDURE UpdateFinancialInstrument
GO 

CREATE PROCEDURE UpdateFinancialInstrument
    @ID INT,
    @MarketValue FLOAT,
    @Type VARCHAR(50)
AS
BEGIN
    UPDATE FinancialInstruments
    SET MarketValue = @MarketValue,
        Type = @Type
    WHERE ID = @ID
END

GO

IF  EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME='DeleteFinancialInstrument')
DROP PROCEDURE DeleteFinancialInstrument
GO 

CREATE PROCEDURE DeleteFinancialInstrument
    @ID INT
AS
BEGIN
    DELETE FROM FinancialInstruments
    WHERE ID = @ID
END

GO

IF  EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME='SelectFinancialInstruments')
DROP PROCEDURE SelectFinancialInstruments
GO 

CREATE PROCEDURE SelectFinancialInstruments
AS
BEGIN
    SELECT * FROM FinancialInstruments
END

GO
