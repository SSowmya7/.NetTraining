CREATE TABLE Cars (
    CarId INT IDENTITY(1,1) PRIMARY KEY,
    Make VARCHAR(50),
    Model VARCHAR(50),
    Year INT,
    Price DECIMAL(10, 2),
    Mileage INT,
    Color VARCHAR(30),
    Vin VARCHAR(17) UNIQUE,
    DealerId INT,
    DateAdded DATETIME DEFAULT GETDATE()
);
INSERT INTO Cars (Make, Model, Year, Price, Mileage, Color, Vin, DealerId) VALUES
('Toyota', 'Corolla', 2020, 20000.00, 15000, 'White', '1HGCM82633A004352', 1),
('Honda', 'Civic', 2019, 18000.00, 20000, 'Black', '1HGCM82633A004353', 2),
('Ford', 'Mustang', 2018, 25000.00, 25000, 'Red', '1HGCM82633A004354', 1),
('Chevrolet', 'Malibu', 2017, 22000.00, 30000, 'Blue', '1HGCM82633A004355', 3),
('Nissan', 'Altima', 2021, 23000.00, 10000, 'Grey', '1HGCM82633A004356', 2),
('BMW', '3 Series', 2022, 40000.00, 5000, 'Black', '1HGCM82633A004357', 3),
('Audi', 'A4', 2020, 38000.00, 15000, 'White', '1HGCM82633A004358', 1),
('Mercedes-Benz', 'C-Class', 2019, 42000.00, 20000, 'Silver', '1HGCM82633A004359', 2),
('Volkswagen', 'Passat', 2018, 21000.00, 25000, 'Blue', '1HGCM82633A004360', 1),
('Hyundai', 'Elantra', 2017, 17000.00, 30000, 'Red', '1HGCM82633A004361', 3),
('Kia', 'Optima', 2021, 19000.00, 10000, 'Grey', '1HGCM82633A004362', 2),
('Subaru', 'Impreza', 2022, 24000.00, 5000, 'White', '1HGCM82633A004363', 1),
('Mazda', '3', 2020, 20000.00, 15000, 'Black', '1HGCM82633A004364', 2),
('Acura', 'TLX', 2019, 35000.00, 20000, 'Silver', '1HGCM82633A004365', 3),
('Lexus', 'IS', 2018, 37000.00, 25000, 'Blue', '1HGCM82633A004366', 1),
('Infiniti', 'Q50', 2017, 36000.00, 30000, 'Red', '1HGCM82633A004367', 2),
('Tesla', 'Model 3', 2021, 45000.00, 10000, 'White', '1HGCM82633A004368', 3),
('Porsche', '911', 2022, 90000.00, 5000, 'Black', '1HGCM82633A004369', 1),
('Jaguar', 'XE', 2020, 50000.00, 15000, 'Blue', '1HGCM82633A004370', 2),
('Cadillac', 'ATS', 2019, 43000.00, 20000, 'Grey', '1HGCM82633A004371', 3),
('Chrysler', '300', 2018, 28000.00, 25000, 'White', '1HGCM82633A004372', 1),
('Dodge', 'Charger', 2017, 29000.00, 30000, 'Red', '1HGCM82633A004373', 2),
('Buick', 'Regal', 2021, 27000.00, 10000, 'Silver', '1HGCM82633A004374', 3),
('Alfa Romeo', 'Giulia', 2022, 50000.00, 5000, 'Black', '1HGCM82633A004375', 1),
('Mitsubishi', 'Lancer', 2020, 15000.00, 15000, 'Blue', '1HGCM82633A004376', 2),
('Volvo', 'S60', 2019, 34000.00, 20000, 'White', '1HGCM82633A004377', 3),
('Genesis', 'G70', 2018, 39000.00, 25000, 'Red', '1HGCM82633A004378', 1);
--====================================================================================
--QUERIES

SELECT * FROM Cars
--1ST QUERY :- AVAREGE PRICE OF CARS BY MAKE AND MODEL
SELECT Make,Model,AVG(price) AS AveragePrice FROM Cars Group By  Make,Model
--2ND QUERY :- LIST EACH CARS PRICE AND THE AVERAGE PRICE OF CARS WITH THE SAME MAKE
SELECT CarId,Make,Model,Price,Avg(Price) over(partition by Make) As AverageMakerPrice From Cars
--3rd QUERY:- TOP5 MOST EXPENSIVE CARS FOR EACH MAKE
WITH RankedCars As(
select CarId,Make,Model,Price,
ROW_NUMBER() OVER (PARTITION BY Make ORDER BY Price DESC) AS Rank
FROM Cars)
SELECT * FROM RankedCars where Rank<=5;
--4th QUERY :- Find the cars with a price higher than the average price of all cars.
WITH AveragePrice As(
Select AVG(Price) As AvgPrice FROM Cars)
select CarId,Make,Model,Price FROM Cars,AveragePrice WHERE Cars.Price > AveragePrice.AvgPrice;
--5thQUERY :- Assuming you have a dealers table, list the details of cars along with their dealer's name.
-- creating dealers table :-
CREATE TABLE Dealers (
    DealerId INT PRIMARY KEY,
    DealerName VARCHAR(100),
    DealerSite VARCHAR(100)
);

INSERT INTO Dealers (DealerId, DealerName, DealerSite) VALUES 
(1, 'Honda Dealer', 'hondasite.com'),
(2, 'Toyota Dealer', 'toyotasite.com'),
(3, 'Ford Dealer', 'fordsite.com');

--QUERYING :-
SELECT 
    C.CarId,
    C.Make,
    C.Model,
    C.Price,
    D.DealerName,
    D.DealerSite
FROM 
    Cars C
JOIN 
    Dealers D ON C.DealerId = D.DealerId;
	

--6THQUERY :- Find the hierarchy of car models based on the year, starting with the oldest model.
SELECT 
    CarId,
    Make,
    Model,
    Year,
    Price
FROM 
    Cars
ORDER BY 
    Year ASC, 
    Make, 
    Model;
--7thQUERY:-Find the difference between each car's price and the average price of cars of the same make and model.
INSERT INTO Cars (Make, Model, Year, Price, Mileage, Color, Vin, DealerId, DateAdded)
VALUES 
('Toyota', 'Corolla', 2019, 18000, 15000, 'Blue', '1HGCM82633A123456', 101, GETDATE()),
('Toyota', 'Corolla', 2019, 20000, 10000, 'Red', '1HGCM82633A123457', 101, GETDATE()),
('Toyota', 'Corolla', 2019, 22000, 5000, 'Green', '1HGCM82633A123458', 101, GETDATE()),
('Honda', 'Civic', 2020, 25000, 8000, 'Black', '1HGCM82633A123459', 102, GETDATE()),
('Honda', 'Civic', 2020, 26000, 7000, 'White', '1HGCM82633A123460', 102, GETDATE()),
('Honda', 'Civic', 2020, 24000, 9000, 'Silver', '1HGCM82633A123461', 102, GETDATE());

SELECT 
    CarId, 
    Make, 
    Model, 
    Price, 
	
    Price - AVG(Price) OVER (PARTITION BY Make, Model) AS PriceDifference
FROM 
    Cars;

SELECT Make,Model,Price,AVG(price) AS AveragePrice FROM Cars Group By  Make,Model,Price
--8thQUERY:- Create a pivot table showing the average price of cars for each make by year.
SELECT 
    Make,
    [2018],
    [2019],
    [2020],
    [2021],
    [2022],
    [2023]
FROM 
    (SELECT 
         Make, 
         Year, 
         AVG(Price) AS AveragePrice
     FROM 
         Cars
     GROUP BY 
         Make, 
         Year) AS SourceTable
PIVOT 
    (AVG(AveragePrice) FOR Year IN ([2018], [2019], [2020], [2021], [2022], [2023])) AS PivotTable;


--9thQUERY:-Calculate the cumulative sum of car prices by make and year
SELECT 
    CarId,
    Make,
    Year,
    Price,
    SUM(Price) OVER (PARTITION BY Make, Year ORDER BY CarId  9) AS CumulativePrice
FROM 
    Cars;

--10THQUERY:-Rank cars by price within each make and model group.
SELECT 
    CarId, 
    Make, 
    Model, 
    Price, 
    RANK() OVER (PARTITION BY Make, Model ORDER BY Price DESC) AS PriceRank
FROM 
    Cars;
--11THQUERY:-Classify cars into price categories (e.g., Budget, Mid-Range, Luxury) based on their prices.
SELECT 
    CarId, 
    Make, 
    Model, 
    Price,
    CASE 
        WHEN Price < 20000 THEN 'Budget'
        WHEN Price BETWEEN 20000 AND 50000 THEN 'Mid-Range'
        ELSE 'Luxury'
    END AS PriceCategory
FROM 
    Cars;
--12THQUERY:-Find cars that are more expensive than the most expensive car from the previous year.
WITH MaxPricePreviousYear AS (
    SELECT 
        Make, 
        MAX(Price) AS MaxPrice, 
        Year + 1 AS Year
    FROM 
        Cars
    GROUP BY 
        Make, 
        Year
)
SELECT 
    C.CarId,
    C.Make,
    C.Model,
    C.Price,
    C.Year
FROM 
    Cars C
JOIN 
    MaxPricePreviousYear MPY ON C.Make = MPY.Make AND C.Year = MPY.Year 
WHERE 
    C.Price > MPY.MaxPrice;

--13THQUERY:-
ALTER TABLE Cars
ADD Attributes NVARCHAR(MAX);
-- Insert the sample data with JSON attributes stored as NVARCHAR(MAX)
INSERT INTO Cars (Make, Model, Year, Price, Mileage, Color, Vin, DealerId, Attributes) VALUES
('Toyota', 'Corolla', 2020, 20000.00, 15000, 'White', '2HGCM82633A004352', 1, N'{"Feature1": "Sunroof", "Feature2": "Leather Seats"}'),
('Honda', 'Civic', 2019, 18000.00, 20000, 'Black', '2HGCM82633A004354', 2, N'{"Feature1": "Navigation System", "Feature2": "Bluetooth"}'),
('Ford', 'Mustang', 2018, 25000.00, 25000, 'Red', '2HGCM82633A004355', 1, N'{"Feature1": "Backup Camera", "Feature2": "Heated Seats"}'),
('Chevrolet', 'Malibu', 2017, 22000.00, 30000, 'Blue', '2HGCM82633A004356', 3, N'{"Feature1": "Remote Start", "Feature2": "Blind Spot Monitoring"}'),
('Nissan', 'Altima', 2021, 23000.00, 10000, 'Grey', '2HGCM82633A004357', 2, N'{"Feature1": "Keyless Entry", "Feature2": "Lane Departure Warning"}');



--14THQUERY:-Full-text search using JSON_VALUE
SELECT *
FROM Cars
WHERE JSON_VALUE(Attributes, '$.Feature1') = 'Sunroof' OR JSON_VALUE(Attributes, '$.Feature2') = 'Leather Seats';

--15THQUERY:- Materialized View Summarizing the Average Price and Total Count of Cars by Make and Model.
-- Create a materialized view (indexed view) to summarize the average price and total count
CREATE VIEW CarSummary
WITH SCHEMABINDING
AS
SELECT
    Make,
    Model,
    AVG(Price) AS AveragePrice,
    COUNT_BIG(*) AS TotalCount
FROM dbo.Cars
GROUP BY Make, Model;


-- Create an indexed view to materialize it
CREATE UNIQUE CLUSTERED INDEX IX_CarSummary ON CarSummary (Make, Model); --ERROR--SHOULD ASK


--16THQUERY:-Partitioning the Cars Table by Year

-- Create partition function and scheme
CREATE PARTITION FUNCTION CarsYearRangePF (INT)
AS RANGE LEFT FOR VALUES (2017, 2018, 2019, 2020, 2021, 2022);

CREATE PARTITION SCHEME CarsYearRangePS
AS PARTITION CarsYearRangePF
ALL TO ([PRIMARY]);


CREATE TABLE CarsByYears (
    Make VARCHAR(255),
    Model VARCHAR(255),
    Year INT,
    Price DECIMAL(10, 2),
    Mileage INT,
    Color VARCHAR(255),
    Vin VARCHAR(255),
    DealerId INT,
    Attributes NVARCHAR(MAX)
)
ON CarsYearRangePS (Year);

-- Insert data  from the Cars table
INSERT INTO CarsByYears (Make, Model, Year, Price, Mileage, Color, Vin, DealerId, Attributes)
SELECT Make, Model, Year, Price, Mileage, Color, Vin, DealerId, Attributes FROM Cars;

SELECT * FROM CarsByYears;


--17THQUERY:- Lateral Join to Find the Closest Car by Price for Each Car
-- Closest car by price using CROSS APPLY
SELECT 
    C1.Make AS CurrentCarMake,
    C1.Model AS CurrentCarModel,
    C1.Price AS CurrentCarPrice,
    C2.Make AS ClosestCarMake,
    C2.Model AS ClosestCarModel,
    C2.Price AS ClosestCarPrice
FROM Cars C1
CROSS APPLY (
    SELECT TOP 1 *
    FROM Cars C2
    WHERE C2.Vin <> C1.Vin
    ORDER BY ABS(C1.Price - C2.Price)
) C2;


--18THQUERY:- Rolling Average Price of Cars, Partitioned by Make and Ordered by Year

-- Rolling average price
SELECT 
    Make,
    Model,
    Year,
    Price,
    AVG(Price) OVER (PARTITION BY Make ORDER BY Year ROWS BETWEEN 2 PRECEDING AND CURRENT ROW) AS RollingAvgPrice
FROM Cars;







--19THQUERY:-Perform a join between the cars table and a service_records table to find cars with their latest service record.

-- Create service_records table
CREATE TABLE ServiceRecords (
    ServiceId INT PRIMARY KEY,
    Vin VARCHAR(255),
    ServiceDate DATE,
    ServiceDescription VARCHAR(255)
);

-- Insert sample data
INSERT INTO ServiceRecords (ServiceId, Vin, ServiceDate, ServiceDescription) VALUES
(1, '1HGCM82633A004352', '2022-01-15', 'Oil Change'),
(2, '1HGCM82633A004353', '2022-02-20', 'Tire Rotation'),
(3, '1HGCM82633A004354', '2022-03-25', 'Brake Inspection');

-- Join to find latest service record
SELECT 
    C.Make,
    C.Model,
    C.Vin,
    SR.ServiceDate,
    SR.ServiceDescription
FROM Cars C
JOIN (
    SELECT Vin, MAX(ServiceDate) AS LatestServiceDate
    FROM ServiceRecords
    GROUP BY Vin
) LSR ON C.Vin = LSR.Vin
JOIN ServiceRecords SR ON LSR.Vin = SR.Vin AND LSR.LatestServiceDate = SR.ServiceDate;
