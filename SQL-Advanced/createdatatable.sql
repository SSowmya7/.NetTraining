CREATE TABLE Cars (
    HomeNetVehicleId INT PRIMARY KEY,
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

INSERT INTO Cars (HomeNetVehicleId, DealerId, Type, VIN, Year, Make, Model, Body, Trim, Transmission, InteriorColor, SellingPrice) VALUES
(1, 1, 'Sedan', '1HGCM82633A004352', 2020, 'Honda', 'Civic', 'Coupe', 'EX', 'Automatic', 'Black', 22000.00),
(2, 2, 'SUV', '2HGCM82633A004353', 2019, 'Kia', 'Sorento', 'SUV', 'SX', 'Automatic', 'Red', 30000.00),
(3, 3, 'Truck', '3HGCM82633A004354', 2021, 'Ford', 'F-150', 'Pickup', 'Lariat', 'Automatic', 'Blue', 45000.00),
(4, 1, 'SUV', '5NPEB4AC9DH590701', 2022, 'Hyundai', 'Santa Fe', 'SUV', 'Limited', 'Automatic', 'Gray', 27000.00),
(5, 2, 'Sedan', '1FAFP404X2F215468', 2023, 'Ford', 'Fusion', 'Sedan', 'SE', 'Automatic', 'White', 18000.00);
