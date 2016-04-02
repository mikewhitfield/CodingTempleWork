USE CityTour

go

CREATE TABLE Product
  (
     Id        INT,
     ImageUrl  VARCHAR(50),
     Summary   VARCHAR(2500),
     Latitude  INT,
     Longitude INT,
     Category  VARCHAR(50),
     Price     MONEY,
     Marker    VARCHAR(100),
     Name      VARCHAR(50)
  ) 
