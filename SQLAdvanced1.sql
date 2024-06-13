CREATE DATABASE sales;

USE sales;

-- Create Region table
CREATE TABLE Region (
    regionid INT PRIMARY KEY,
    regionname VARCHAR(255),
    superregionid INT
);

-- Create Product table
CREATE TABLE Product (
    productid INT PRIMARY KEY,
    productname VARCHAR(255)
);

-- Create Sales_Totals table
CREATE TABLE Sales_Totals (
    productid INT,
    regionid INT,
    year INT,
    month INT,
    sales DECIMAL(10, 2)
);

-- Insert sample data into Region table
INSERT INTO Region (regionid, regionname, superregionid) VALUES
(1, 'North America', NULL),
(2, 'South America', NULL),
(3, 'Asia', NULL),
(4, 'Europe', NULL);

-- Insert sample data into Product table
INSERT INTO Product (productid, productname) VALUES
(7684, 'Sprocket'),
(3245, 'Gear - Large'),
(3246, 'Gear - Small'),
(5289, 'Widget');

-- Insert sample data into Sales_Totals table
INSERT INTO Sales_Totals (productid, regionid, year, month, sales) VALUES
(7684, 1, 2020, 1, 1000.00),
(7684, 1, 2020, 2, 1500.00),
(7684, 1, 2020, 3, 1200.00),
(7684, 1, 2020, 4, 1100.00),
(7684, 1, 2020, 5, 900.00),
(7684, 1, 2020, 6, 800.00),
(7684, 1, 2020, 7, 950.00),
(7684, 1, 2020, 8, 1000.00),
(7684, 1, 2020, 9, 1300.00),
(7684, 1, 2020, 10, 1200.00),
(7684, 1, 2020, 11, 1100.00),
(7684, 1, 2020, 12, 1150.00),
(3245, 1, 2020, 1, 500.00),
(3246, 1, 2020, 1, 400.00),
(5289, 1, 2020, 1, 800.00);


--1stQuery:- SELECT statement with CASE expression for quarters
SELECT month,
CASE 
	WHEN month IN(1,2,3) THEN 1
	WHEN month IN(4,5,6) THEN 2
	WHEN month IN(7,8,9) THEN 3
	WHEN month IN(10,11,12) THEN 4
END AS quarter
FROM Sales_Totals;

--2NDQUERY:- Pivot Sales_Totals data
SELECT 
    productid,
    SUM(CASE WHEN productid = 7684 THEN sales ELSE 0 END) AS Sprocket,
    SUM(CASE WHEN productid = 3245 THEN sales ELSE 0 END) AS 'Gear - Large',
    SUM(CASE WHEN productid = 3246 THEN sales ELSE 0 END) AS 'Gear - Small',
    SUM(CASE WHEN productid = 5289 THEN sales ELSE 0 END) AS Widget
FROM Sales_Totals
GROUP BY productid;
--3RDQUERY:-Ranking rows based on Sales column in descending order
SELECT *,RANK() OVER( ORDER BY sales DESC) AS product_sales_rank FROM Sales_Totals;
--4THQUERY:-Ranking rows by Sales column with a separate set of rankings for each product
SELECT *,RANK() OVER(PARTITION BY productid ORDER BY sales DESC) AS product_sales_rank FROM Sales_Totals;
--5THQUERY:-Only those rows with a product_sales_rank of 1 or 2
-- Using a CTE to calculate ranks and then filter on product_sales_rank
WITH RankedSales AS (
    SELECT 
        *,
        RANK() OVER (PARTITION BY productid ORDER BY sales DESC) AS product_sales_rank
    FROM Sales_Totals
)
SELECT *
FROM RankedSales
WHERE product_sales_rank <= 2;

-- Using a subquery to calculate ranks and then filter on product_sales_rank
SELECT *
FROM (
    SELECT 
        *,
        RANK() OVER (PARTITION BY productid ORDER BY sales DESC) AS product_sales_rank
    FROM Sales_Totals
) AS RankedSales
WHERE product_sales_rank <= 2;

--6thQUERY:-Add a row to the Region table and Sales_Total table in a single unit of work
BEGIN TRANSACTION;

INSERT INTO Region (regionid, regionname, superregionid) VALUES (5, 'Europe', NULL);

INSERT INTO Sales_Totals (productid, regionid, year, month, sales) VALUES (7684, 5, 2020, 10, 1500.00);

COMMIT TRANSACTION;

--7THQUERY:-CREATE VIEW

CREATE VIEW Product_Sales_Totals
AS
SELECT 
    productid,
    year,
    SUM(sales) AS product_sales,
    SUM(CASE WHEN productid IN (3245, 3246) THEN sales ELSE 0 END) AS gear_sales
FROM Sales_Totals
GROUP BY productid, year;


--8THQUERY:-PERCENTAGES OF SALES FOR THEYEAR 2020
SELECT 
    productid,
    regionid,
    month,
    sales,
    (sales / SUM(sales) OVER (PARTITION BY productid, regionid, month)) * 100 AS pct_product_sales
FROM Sales_Totals
WHERE year = 2020;
--9THQUERY:-Year, month, and sales with prior month sales
SELECT 
    year,
    month,
    sales,
    LAG(sales) OVER (ORDER BY month) AS prior_month_sales
FROM Sales_Totals
WHERE year = 2020;



--10THQUERY:-Retrieve name and type of each column in the Product table


SELECT 
    COLUMN_NAME, 
    DATA_TYPE
FROM 
    INFORMATION_SCHEMA.COLUMNS
WHERE 
    TABLE_NAME = 'Product' AND TABLE_SCHEMA = 'DBO';


	
	--OTHERWAY TO GET DETAILS--
EXEC sp_help 'Product';
EXEC sp_columns @table_name = 'Product', @table_owner = 'DBO';

--ANOTHER WAY--

SELECT name 
FROM sys.schemas
WHERE name = 'DBO';
SELECT name 
FROM sys.schemas;
SELECT 
    c.name AS COLUMN_NAME, 
    ty.name AS DATA_TYPE
FROM 
    sys.columns AS c
INNER JOIN 
    sys.tables AS t ON c.object_id = t.object_id
INNER JOIN 
    sys.schemas AS s ON t.schema_id = s.schema_id
INNER JOIN 
    sys.types AS ty ON c.user_type_id = ty.user_type_id
WHERE 
    t.name = 'Product' AND s.name = 'dbo';
