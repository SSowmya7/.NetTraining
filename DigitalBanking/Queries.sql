--QUERY1:- Get all customers of a bank, bank code, or id is the input
DECLARE @BankId INT = 1;
SELECT C.*
FROM Customer C
JOIN Account a ON c.Id = a.CustomerId
Where a.BankId = @BankId;

--QUERY2:- Get highest balance customer of every bank
SELECT b.Name AS BankName, c.FirstName, c.LastName, a.Balance
FROM Account a
JOIN Bank b ON a.BankId = b.Id
JOIN Customer c ON a.CustomerId = c.Id
WHERE a.Balance = (SELECT MAX(a2.Balance) FROM Account a2 WHERE a2.BankId = a.BankId)
ORDER BY b.Name;
--Query3:- Get second highest balance customer of every bank
SELECT b.Name AS BankName, c.FirstName, c.LastName, a.Balance
FROM Account a
JOIN Bank b ON a.BankId = b.Id
JOIN Customer c ON a.CustomerId = c.Id
WHERE a.Balance = (
    SELECT MAX(a2.Balance)
    FROM Account a2
    WHERE a2.BankId = a.BankId
    AND a2.Balance < (
        SELECT MAX(a3.Balance)
        FROM Account a3
        WHERE a3.BankId = a.BankId
    )
)
ORDER BY b.Name;

--QUERY4:-Get customers who have more than one bank account in the same bank

SELECT c.Id, c.FirstName, c.LastName, a.BankId, COUNT(a.Id) AS AccountCount
FROM Customer C
JOIN Account a ON c.Id = a.CustomerId
GROUP BY c.Id, c.FirstName, c.LastName, a.BankId
HAVING COUNT(a.Id) > 1;

--Query5:- Get customers who have more than three accounts in different banks

SELECT c.Id, c.FirstName, c.LastName, a.BankId, COUNT(DISTINCT a.BankId) AS BankCount
FROM Customer C
JOIN Account a ON c.Id = a.CustomerId
GROUP BY c.Id, c.FirstName, c.LastName, a.BankId
HAVING COUNT(DISTINCT a.BankId) > 3;

--QUERY6:- Get banks which have all customers' balances more than 1000

SELECT b.Name
FROM Account a
JOIN Bank b ON a.BankId = b.Id
JOIN Customer c ON a.CustomerId = c.Id
Where a.Balance >1000



--QUERY7:- Get customers whose name starts with 'Rah'

SELECT * FROM Customer WHERE FirstName LIKE 'Rah%';



--QUERY8 :- Get customers whose middle name is 'kumar'
SELECT * FROM Customer WHERE MiddleName = 'Kumar';

--QUERY9:- Get customers whose name (first name, middle name, or last name) contains 'jay'
SELECT * FROM Customer
WHERE FirstName LIKE '%jay%'
	OR MiddleName LIKE '%jay%'
	OR LastName LIKE '%jay%';
                           
--QUERY10:- Get branches of banks which have more than 10 customers
SELECT bb.*
FROM BankBranch bb 
JOIN Account a ON bb.Id = a.BranchId
GROUP BY bb.Id, bb.Code, bb.Address1, bb.Address2, bb.City, bb.District, bb.State, bb.ZipCode, bb.BankId, bb.CreatedDate, bb.UpdatedDate
HAVING COUNT(DISTINCT a.CustomerId) > 10;

--QUERY11:- Get branches of banks which have no customers

SELECT bb.*
FROM BankBranch bb 
JOIN Account a ON bb.Id = a.BranchId
GROUP BY bb.Id, bb.Code, bb.Address1, bb.Address2, bb.City, bb.District, bb.State, bb.ZipCode, bb.BankId, bb.CreatedDate, bb.UpdatedDate
HAVING COUNT(DISTINCT a.CustomerId) = 0;















