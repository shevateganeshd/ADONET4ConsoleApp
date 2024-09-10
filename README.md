Database

Table

CREATE TABLE Employee (
    Id INT AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(100) NOT NULL,
    PhoneNo VARCHAR(10) NOT NULL,
    BirthDate DATE NOT NULL,
    IsActive BIT,
    PRIMARY KEY(Id)
);
