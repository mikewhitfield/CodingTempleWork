use Drivers
go

create table [Address](
City varChar(50),
Street varChar(100),
Id int,
)

create table [State](
Id int,
[State] varChar(30)
)

create table VehicleRegistration(
Id int,
Name varChar(50),
AddressId Int
)

create table Insurance_Vehicle(
Id int,
VehicleId int,
InsuranceId int
)

create table Insurance(
Id int,
Policy varChar(50),
Drivingrecord varChar(50)
)

create table Insurance_Driver(
Id int,
DriverId int,
InsuranceVehicleId int
)

create table Driver(
Id int,
Name varChar(50)
)

create table Vehicle_Driver(
Id int,
VehicleId int,
DriverId int
)

create table Vehicle(
Id int,
VehicleRegistrationId int,
class varChar(50)
)