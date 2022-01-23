USE [master];
GO

if exists (select * from sys.databases where name = N'HotelDB')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'HotelDB';
	ALTER DATABASE HotelDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE HotelDB;
end

CREATE DATABASE HotelDB;
GO

USE HotelDB;
GO

CREATE TABLE [State] (
	stateID int identity(1,1) primary key,
	stateName varchar(2) not null
)

CREATE TABLE Guest (
	guestID int identity(1,1) primary key,
	firstName varchar(50) not null,
	lastName varchar(50) not null,
	[address] varchar(256) not null,
	city varchar(100) not null,
	stateId int foreign key references State(stateId) not null,
	zip varchar(10) not null,
	phone varchar(10) not null
)

CREATE TABLE Reservation (
	reservationId int identity(1,1) primary key,
	guestId int foreign key references Guest(guestId) not null,
	adults int not null,
	children int not null,
	startDate date not null,
	endDate date not null,
	totalCost decimal(12,4) not null
)

CREATE TABLE RoomCategory (
	roomCategoryId int identity(1,1) primary key,
	roomCategoryName varchar(50) not null
)

CREATE TABLE RoomType (
	roomTypeId int identity(1,1) primary key,
	roomCategoryId int foreign key references RoomCategory(roomCategoryId) not null,
	occupancyMin int not null,
	occupancyMax int not null,
	basePrice decimal(12,4) not null,
	extraGuestFee decimal(12,4) null
)

CREATE TABLE Room (
	roomId int primary key,
	roomTypeId int foreign key references RoomType(roomTypeId) not null,
	hasADA bit not null
)

CREATE TABLE RoomReservation (
	reservationId int not null,
	roomId int not null,
	CONSTRAINT pk_RoomReservation primary key (reservationId, roomId),
	CONSTRAINT fk_RoomReservation_Reservation foreign key (reservationId) 
		references reservation(reservationId),
	CONSTRAINT fk_RoomReservation_Room foreign key (roomId)
		references room(roomId)
)

CREATE TABLE Amenity (
	amenityId int identity(1,1) primary key,
	amenityDescription varchar(200) not null,
	amenityFee decimal(12,4) null
)

CREATE TABLE RoomAmenity (
	roomId int not null,
	amenityId int not null,
	CONSTRAINT pk_RoomAmenity primary key (roomId, amenityId),
	CONSTRAINT fk_RoomAmenity_Room foreign key (roomId)
		references Room(roomId),
	CONSTRAINT fk_RoomAmenity_Amenity foreign key (amenityId)
		references Amenity(amenityId)
)
