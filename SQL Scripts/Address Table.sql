USE CityTour

go

CREATE TABLE [Address]
  (
     Id      INT,
     Address1  VARCHAR(50),
	 Address2 VARCHAR(50),
     City    VARCHAR(50),
     [State] VARCHAR(30),
	 Zipcode VARCHAR (12),
	 Country Varchar(50)
  ) 
