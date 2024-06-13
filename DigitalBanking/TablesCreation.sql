-- Use DigitalBank database
USE DigitalBanking;

-- Create Bank table
CREATE TABLE Bank (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name VARCHAR(500) NOT NULL,
    Code VARCHAR(500) NOT NULL UNIQUE,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NOT NULL
);

-- Create BankBranch table
CREATE TABLE BankBranch (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Code VARCHAR(500) NOT NULL UNIQUE,
    Address1 VARCHAR(1000) NOT NULL,
    Address2 VARCHAR(1000),
    City VARCHAR(500) NOT NULL,
    District VARCHAR(500) NOT NULL,
    State VARCHAR(500) NOT NULL,
    ZipCode VARCHAR(10) NOT NULL,
    BankId INT NOT NULL FOREIGN KEY REFERENCES Bank(Id),
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NOT NULL
);

-- Create Customer table
CREATE TABLE Customer (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName VARCHAR(1000) NOT NULL,
    MiddleName VARCHAR(1000),
    LastName VARCHAR(1000) NOT NULL,
    Address1 VARCHAR(1000) NOT NULL,
    Address2 VARCHAR(1000),
    City VARCHAR(500) NOT NULL,
    District VARCHAR(500) NOT NULL,
    State VARCHAR(500) NOT NULL,
    ZipCode VARCHAR(10) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NOT NULL
);

-- Create Account table
CREATE TABLE Account (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customer(Id),
    BankId INT NOT NULL FOREIGN KEY REFERENCES Bank(Id),
    BranchId INT NOT NULL FOREIGN KEY REFERENCES BankBranch(Id),
    AccountType VARCHAR(500) NOT NULL,
    IsActive BIT NOT NULL,
    Balance MONEY NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NOT NULL
);

-- Create Transactions table
CREATE TABLE Transactions (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AccountId INT NOT NULL FOREIGN KEY REFERENCES Account(Id),
    TransactionType VARCHAR(500) NOT NULL,
    Amount MONEY NOT NULL,
    TransactionTime DATETIME NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NOT NULL
);

-- Insert sample data into Bank
INSERT INTO Bank (Name, Code, CreatedDate, UpdatedDate)
VALUES ('Bank A', 'BANKA', GETDATE(), GETDATE()),
       ('Bank B', 'BANKB', GETDATE(), GETDATE());

-- Insert sample data into BankBranch
INSERT INTO BankBranch (Code, Address1, Address2, City, District, State, ZipCode, BankId, CreatedDate, UpdatedDate)
VALUES ('BRANCH1', '123 Main St', 'Suite 101', 'CityA', 'DistrictA', 'StateA', '12345', 1, GETDATE(), GETDATE()),
       ('BRANCH2', '456 Elm St', '', 'CityB', 'DistrictB', 'StateB', '67890', 2, GETDATE(), GETDATE());

-- Insert sample data into Customer
INSERT INTO Customer (FirstName, MiddleName, LastName, Address1, Address2, City, District, State, ZipCode, CreatedDate, UpdatedDate)
VALUES ('John', 'M', 'Doe', '789 Oak St', 'Apt 1', 'CityC', 'DistrictC', 'StateC', '13579', GETDATE(), GETDATE()),
       ('Jane', '', 'Smith', '101 Pine St', '', 'CityD', 'DistrictD', 'StateD', '24680', GETDATE(), GETDATE());

-- Insert sample data into Account
INSERT INTO Account (CustomerId, BankId, BranchId, AccountType, IsActive, Balance, CreatedDate, UpdatedDate)
VALUES (1, 1, 1, 'Savings', 1, 1000.00, GETDATE(), GETDATE()),
       (2, 2, 2, 'Checking', 1, 2000.00, GETDATE(), GETDATE());

-- Insert sample data into Transactions
INSERT INTO Transactions (AccountId, TransactionType, Amount, TransactionTime, CreatedDate, UpdatedDate)
VALUES (1, 'Deposit', 500.00, GETDATE(), GETDATE(), GETDATE()),
       (2, 'Withdrawal', 300.00, GETDATE(), GETDATE(), GETDATE());

	   SELECT * FROM Bank
	   SELECT * FROM BankBranch
	   SELECT * FROM Customer
	   SELECT * FROM Transactions