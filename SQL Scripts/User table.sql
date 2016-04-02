USE CityTour

go

CREATE TABLE [User]
  (
     Id         INT,
     Username   VARCHAR(40),
     [Password] VARCHAR(20),
     Email      VARCHAR(50),
     CustomerId INT
  ) 
