GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Conference')

BEGIN
    CREATE DATABASE Conference;
END
GO 
-- switch to database conference 
USE Conference;
GO
--create atendees table
CREATE TABLE Attendees
(
    AttendeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,

);
GO
--create sessions table
CREATE TABLE Sessions(
    SessionID INT PRIMARY KEY IDENTITY(101,1),
    SessionTitle VARCHAR(100) NOT NULL,
    SessionDateTime DATETIME NOT NULL,
    Speaker Varchar(100)

GO

--Create registration table
CREATE TABLE Registration(
    RegistrationID INT PRIMARY KEY IDENTITY(1,1),
    AttendeeID INT NOT NULL,
    SessionID INT NOT NULL,
    RegistrationDate DATE NOT NULL,
    FOREIGN KEY (AttendeeID) REFERENCES Attendees(AttendeeID),
    FOREIGN KEY (SessionID) REFERENCES Sessions(SessionID)
);
GO

--Insert sample data into Attendees table
INSERT INTO Attendees (FirstName, LastName, Email)
VALUES
('John', 'Doe', 'john.doe@example.com'),
('Jane', 'Smith', 'jane.smith@example.com'),
('Alice', 'Johnson', 'alice.johnson@example.com'),
('Bob', 'Brown', 'bob.brown@example.com');
GO

--Insert sample data into Sessions table
INSERT INTO Sessions (SessionTitle, SessionDateTime, Speaker)
VALUES
('Introduction to SQL', '2023-10-01 09:00:00', 'Dr. Smith'),
('Advanced SQL Techniques', '2023-10-01 11:00:00', 'Prof. Johnson'),
('Database Design Best Practices', '2023-10-02 09:00:00', 'Mr. Brown'),
('Data Analysis with SQL', '2023-10-02 11:00:00', 'Ms. Davis');
GO

--Insert sample data into Registration table
INSERT INTO Registration (AttendeeID, SessionID, RegistrationDate)
VALUES
(1, 101, '2023-09-15'),
(2, 102, '2023-09-16'),
(3, 103, '2023-09-17'),
(4, 104, '2023-09-18');
GO
