CREATE TABLE Employees (
    e_id INT IDENTITY(1,1) PRIMARY KEY,
    e_name VARCHAR(100) NOT NULL,
    e_salary DECIMAL(10, 2) NOT NULL,
    e_age INT NOT NULL,
    e_gender CHAR(1) NOT NULL,
    e_dept VARCHAR(50) NOT NULL,
   
);
INSERT INTO Employees (e_name, e_salary, e_age, e_gender, e_dept)
VALUES
('Alice Smith', 50000.00, 28, 'F', 'Support'),
('Bob Johnson', 60000.00, 32, 'M', 'Engineering'),
('Carol Williams', 55000.00, 34, 'F', 'Support'),
('David Brown', 70000.00, 45, 'M', 'Sales'),
('Eve Davis', 72000.00, 29, 'F', 'Support'),
('Frank Miller', 80000.00, 50, 'M', 'Engineering'),
('Grace Wilson', 82000.00, 33, 'F', 'Support'),
('Henry Moore', 90000.00, 52, 'M', 'Finance'),
('Ivy Taylor', 62000.00, 31, 'F', 'Support'),
('Jack Anderson', 75000.00, 27, 'M', 'Marketing');


CREATE PROCEDURE EMPABOVE30
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE e_age > 30;
END;


CREATE PROCEDURE UpdateEmployeeDetails
    @e_id INT,
    @e_name VARCHAR(100),
    @e_salary DECIMAL(10, 2),
    @e_age INT,
    @e_gender CHAR(1),
    @e_dept VARCHAR(50)
AS
BEGIN
    UPDATE Employees
    SET 
        e_name = @e_name,
        e_salary = @e_salary,
        e_age = @e_age,
        e_gender = @e_gender,
        e_dept = @e_dept
    WHERE e_id = @e_id
      AND e_dept = 'Support';
END;

--EXCECUTING SPS:-
EXEC EmpAbove30;
EXEC UpdateEmployeeDetails 
    @e_id = 1,
    @e_name = 'John Doe',
    @e_salary = 75000.00,
    @e_age = 35,
    @e_gender = 'M',
    @e_dept = 'Support';
