USE [master]
GO

USE GuildCars;
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name = 'ContactUs')
	DROP TABLE ContactUs
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Special')
	DROP TABLE Special
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Sale')
	DROP TABLE Sale
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name = 'PurchaseType')
	DROP TABLE PurchaseType
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name = 'State')
	DROP TABLE [State]
GO




IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Vehicle')
	DROP TABLE Vehicle
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name = 'InteriorColor')
	DROP TABLE InteriorColor
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name = 'ExteriorColor')
	DROP TABLE ExteriorColor
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name = 'BodyStyle')
	DROP TABLE BodyStyle
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Model')
	DROP TABLE Model
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Make')
	DROP TABLE Make
GO

CREATE TABLE BodyStyle (
	BodyStyleId INT identity(1,1) not null primary key,
	BodyStyleName varchar(20) not null
)


CREATE TABLE ExteriorColor (
	ExteriorColorId INT identity(1,1) not null primary key,
	ExteriorColorName varchar(20) not null
)


CREATE TABLE InteriorColor (
	InteriorColorId INT identity(1,1) not null primary key,
	InteriorColorName varchar(20) not null
)

CREATE TABLE Make (
	MakeId INT identity(1,1) not null primary key,
	MakeName varchar(50) not null,
	UserId varchar(max) not  null,
	DateAdded date not null default(getdate())
)

CREATE TABLE Model (
	ModelId INT identity(1,1) not null primary key,
	MakeId INT not null foreign key references Make(MakeId),
	ModelName varchar(50) not null,
	UserId varchar(max) not null,
	DateAdded date not null default(getdate())
)

CREATE TABLE Vehicle (
	VehicleId INT identity(1,1) not null primary key,
	UserId varchar(max) not null,
	ModelId int foreign key references Model(ModelId),
	InteriorColorId int not null foreign key references InteriorColor(InteriorColorId),
	ExteriorColorId int not null foreign key references ExteriorColor(ExteriorColorId),
	BodyStyleId int not null foreign key references BodyStyle(BodyStyleId),
	IsNew bit not null,
	IsAutoTransmission bit not null,
	Mileage Int not null,
	Vin varchar(20) not null,
	Msrp decimal(10,2) not null,
	VehicleSalePrice decimal(10,2) not null,
	VehicleDescription varchar(1000) not null,
	ModelDate int not null,
	IsFeatured bit not null,
	IsAvailable bit not null,
	ImageLocation varchar(25) null
)



CREATE TABLE [State] (
	StateId INT identity(1,1) not null primary key,
	StateName varchar(2) not null
)

CREATE TABLE PurchaseType (
	PurchaseTypeId INT identity(1,1) not null primary key,
	PurchaseTypeName varchar(20) not null
)


CREATE TABLE Sale (
	SaleId int identity(1,1) not null primary key,
	UserId varchar(max) not null,
	VehicleId int not null foreign key references Vehicle(VehicleId),
	StateId int not null foreign key references State(StateId),
	PurchaseTypeId int not null foreign key references PurchaseType(PurchaseTypeId),
	Price decimal(10,2) not null,
	Email varchar(100) null,
	DateSold date not null default(getdate()),
	CustomerName varchar(100) not null,
	Phone varchar(15) null,
	Street1 varchar(100) not null,
	Street2 varchar(100) null,
	City varchar(100) not null,
	Zip varchar(5) not null,
)

CREATE TABLE Special (
	SpecialId INT identity(1,1) not null primary key,
	SpecialTitle varchar(50) not null,
	SpecialDescription varchar(1000) not null
)


CREATE TABLE ContactUs (
	VehicleInquiryId INT identity(1,1) not null primary key,
	[Name] varchar(50) not null,
	Email varchar(100) null,
	Phone varchar(15) null,
	[Message] varchar(1000) not null
)