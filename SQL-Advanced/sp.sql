CREATE PROCEDURE sp_ExcludeYearModels
    @ExcludeYears VARCHAR(MAX) = NULL,
    @ExcludeYearModels VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Temporary table to store the results
    DECLARE @Results TABLE (
        HomeNetVehicleId INT,
        DealerId INT,
        Type VARCHAR(255),
        VIN VARCHAR(255),
        Year INT,
        Make VARCHAR(255),
        Model VARCHAR(255),
        Body VARCHAR(255),
        Trim VARCHAR(255),
        Transmission VARCHAR(255),
        InteriorColor VARCHAR(255),
        SellingPrice DECIMAL(10, 2)
    );

    -- Initial insertion of all cars into the temporary results table
    INSERT INTO @Results
    SELECT *
    FROM Cars;

    -- Handle ExcludeYears parameter
    IF @ExcludeYears IS NOT NULL AND @ExcludeYears <> ''
    BEGIN
        -- Remove leading/trailing spaces and split by comma
        ;WITH ExcludeYearsCTE AS (
            SELECT TRIM(value) AS Year
            FROM STRING_SPLIT(@ExcludeYears, ',')
        )
        DELETE FROM @Results
        WHERE Year IN (SELECT Year FROM ExcludeYearsCTE);
    END

    -- Handle ExcludeYearModels parameter
    IF @ExcludeYearModels IS NOT NULL AND @ExcludeYearModels <> ''
    BEGIN
        -- Remove leading/trailing spaces and split by comma
        ;WITH YearModelsCTE AS (
            SELECT
                CASE 
                    WHEN CHARINDEX(':', TRIM(value)) > 0 
                    THEN LEFT(TRIM(value), CHARINDEX(':', TRIM(value)) - 1) 
                    ELSE NULL 
                END AS Year,
                CASE 
                    WHEN CHARINDEX(':', TRIM(value)) > 0 
                    THEN RIGHT(TRIM(value), LEN(TRIM(value)) - CHARINDEX(':', TRIM(value))) 
                    ELSE TRIM(value)
            END AS Model
            FROM STRING_SPLIT(@ExcludeYearModels, ',')
        )
        DELETE FROM @Results
        WHERE (Year IN (SELECT Year FROM YearModelsCTE WHERE Year IS NOT NULL) AND Model IN (SELECT Model FROM YearModelsCTE WHERE Year IS NOT NULL))
           OR (Model IN (SELECT Model FROM YearModelsCTE WHERE Year IS NULL));
    END

    -- Return the final result set
    SELECT * FROM @Results;

    SET NOCOUNT OFF;
END
GO




