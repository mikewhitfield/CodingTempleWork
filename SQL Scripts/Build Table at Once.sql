use CityTour2
go

create table Product (
Id int,
Summary varChar(1000),
latitude int,
longitude int,
CategoryId int,
Price money,
Marker varChar(50),
Name varChar(100)
)

create table category (
Id int,
Name varChar(100)
)

create table cartItem(
Id int,
productId int,
Total int,
Quantity int
)

create table customer (
Id int,
Name varChar(100),
AddressId int,
Phone int,
email varChar(100),
)

create table [User] (
Id int,
username varChar (50),
[password] varChar(50),
email varChar(100),
CustomerId int
)

create table [Address](
Id int,
street varChar(90),
city varChar(50),
[state]varChar(50)
)


create table Cart (
Id int,
CustomerId int
)

create table ProductImage(
Id int,
URL varChar(100),
ProductId int
)