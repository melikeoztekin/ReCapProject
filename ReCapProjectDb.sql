CREATE TABLE Cars(
	Id int primary key identity(1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	Descriptions varchar(50)
)

CREATE TABLE Colors(
	ColorId int primary key identity(1,1),
	ColorName nvarchar(50)
)

CREATE TABLE Brands(
	BrandId int primary key identity(1,1),
	BrandName nvarchar(50)
)

INSERT INTO Cars(BrandId, ColorId, ModelYear, DailyPrice, Descriptions)
VALUES
	(123, 124554, 2019, 650, 'BMW M2 COMPETITION'),
	(234, 172355, 2016, 500,'AUDI A3 SEDAN'),
	(345, 542367, 2017, 1000, 'ALFA ROMEO GIULIETTA'),
	(123, 127535, 2016, 750, 'BMW M4 SPECIFICATIONS'),
	(234, 254962, 2020, 900, 'AUDI S4');

INSERT INTO Brands(BrandName)
VALUES
	('BMW'),
	('AUDI'),
	('ALFA ROMEO'),
	('BMW'),
	('AUDI');

INSERT INTO Colors(ColorName)
VALUES
	('Black'),
	('Red'),
	('Gray'),
	('Gold'),
	('Silver');
CREATE TABLE Users(
	UserId int primary key identity(1,1),
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Email nvarchar(30) not null,
	Password int not null
)
CREATE TABLE Customers(
	UserId int primary key identity(1,1),
	CompanyName nvarchar(25) not null
)
CREATE TABLE Rentals(
	RentalId int primary key identity(1,1),
	CarId int not null,
	CustomerId int not null,
	RentDate datetime not null,
	ReturnDate datetime,
)
SELECT * FROM Cars;
SELECT * FROM Brands;
SELECT * FROM Colors;
