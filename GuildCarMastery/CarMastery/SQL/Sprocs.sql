USE [master]
GO

USE GuildCars;
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StatesSelectAll')
		DROP PROCEDURE StatesSelectAll	
GO

CREATE PROCEDURE StatesSelectAll
AS

BEGIN
	SELECT StateId, StateName
	FROM [State]
END

GO 

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStyleSelectAll')
		DROP PROCEDURE BodyStyleSelectAll	
GO

CREATE PROCEDURE BodyStyleSelectAll
AS

BEGIN
	SELECT BodyStyleId, BodyStyleName
	FROM BodyStyle
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypeSelectAll')
		DROP PROCEDURE PurchaseTypeSelectAll	
GO

CREATE PROCEDURE PurchaseTypeSelectAll
AS

BEGIN
	SELECT PurchaseTypeId, PurchaseTypeName
	FROM PurchaseType
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorSelectAll')
		DROP PROCEDURE InteriorColorSelectAll	
GO

CREATE PROCEDURE InteriorColorSelectAll
AS

BEGIN
	SELECT InteriorColorId, InteriorColorName
	FROM InteriorColor
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ExteriorColorSelectAll')
		DROP PROCEDURE ExteriorColorSelectAll	
GO

CREATE PROCEDURE ExteriorColorSelectAll
AS

BEGIN
	SELECT ExteriorColorId, ExteriorColorName
	FROM ExteriorColor
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeSelectAll')
		DROP PROCEDURE MakeSelectAll	
GO

CREATE PROCEDURE MakeSelectAll
AS

BEGIN
	SELECT UserId, dbo.AspNetUsers.Email, MakeId, MakeName, DateAdded
	FROM Make
	JOIN AspNetUsers ON Make.UserId = AspNetUsers.Id;
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeAdd')
		DROP PROCEDURE MakeAdd	
GO

CREATE PROCEDURE MakeAdd(
	@MakeName varchar(50),
	@UserId varchar(max))
AS

BEGIN
INSERT INTO Make
	(MakeName, 
	UserId)
VALUES
	(@MakeName,
	@UserId)
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelectAll')
		DROP PROCEDURE ModelSelectAll	
GO

CREATE PROCEDURE ModelSelectAll
AS

BEGIN
	SELECT Model.UserId, AspNetUsers.Email, ModelId, MakeName, ModelName, Model.DateAdded
	FROM Model
	JOIN AspNetUsers ON Model.UserId = AspNetUsers.Id
	JOIN Make ON Model.MakeId = Make.MakeId
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelAdd')
		DROP PROCEDURE ModelAdd	
GO

CREATE PROCEDURE ModelAdd(
	@ModelName varchar(50),
	@MakeId int,
	@UserId varchar(max))
AS

BEGIN
INSERT INTO Model
	(ModelName, 
	MakeId,
	UserId)
VALUES
	(@ModelName,
	@MakeId,
	@UserId)
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialSelectAll')
		DROP PROCEDURE SpecialSelectAll	
GO

CREATE PROCEDURE SpecialSelectAll
AS

BEGIN
	SELECT SpecialId, SpecialTitle, SpecialDescription
	FROM Special
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialAdd')
		DROP PROCEDURE SpecialAdd	
GO

CREATE PROCEDURE SpecialAdd(
	@SpecialTitle varchar(50),
	@SpecialDescription varchar(1000))
AS

BEGIN
INSERT INTO Special
	(SpecialTitle, 
	SpecialDescription)
VALUES
	(@SpecialTitle,
	@SpecialDescription)
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialDelete')
		DROP PROCEDURE SpecialDelete
GO


CREATE PROCEDURE SpecialDelete(
	@SpecialId int
)

AS

DELETE FROM Special
WHERE SpecialId = @SpecialId;

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactUsSelectAll')
		DROP PROCEDURE ContactUsSelectAll	
GO

CREATE PROCEDURE ContactUsSelectAll
AS

BEGIN
	SELECT VehicleInquiryId, Phone, [Name], Email, [Message]
	FROM ContactUs
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactUsAdd')
		DROP PROCEDURE ContactUsAdd	
GO

CREATE PROCEDURE ContactUsAdd(
	@Phone varchar(15) null,
	@Name varchar(50),
	@Email varchar(100) null,
	@Message varchar(1000))
AS

BEGIN
INSERT INTO ContactUs
	(Phone, [Name], Email, [Message])
VALUES
	(@Phone, @Name, @Email, @Message)
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectAll')
		DROP PROCEDURE VehicleSelectAll	
GO
-- encompass all availability. see VehicleListingSelect for only isAvailable = 1
CREATE PROCEDURE VehicleSelectAll
AS

BEGIN
	SELECT VehicleId, UserId, ModelId, InteriorColorId, ExteriorColorId, BodyStyleId, IsNew, IsAutoTransmission,
	Mileage, Vin, Msrp, VehicleSalePrice, VehicleDescription, ModelDate, IsFeatured, IsAvailable, ImageLocation
	FROM Vehicle
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleAdd')
		DROP PROCEDURE VehicleAdd	
GO

CREATE PROCEDURE VehicleAdd(
	@VehicleId int output,
	@UserId varchar(max),
	@ModelId int,
	@InteriorColorId int,
	@ExteriorColorId int,
	@BodyStyleId int,
	@IsNew bit,
	@IsAutoTransmission bit,
	@Mileage int,
	@Vin varchar(20),
	@Msrp decimal(10,2),
	@VehicleSalePrice decimal(10,2),
	@VehicleDescription varchar(1000),
	@ModelDate int,
	@IsFeatured bit,
	@IsAvailable bit,
	@ImageLocation varchar(25))
AS

BEGIN
INSERT INTO Vehicle
	(UserId, ModelId, InteriorColorId, ExteriorColorId, BodyStyleId, IsNew, IsAutoTransmission, Mileage, Vin,
	Msrp, VehicleSalePrice, VehicleDescription, ModelDate, IsFeatured, IsAvailable, ImageLocation)
VALUES
	(@UserId, @ModelId, @InteriorColorId, @ExteriorColorId, @BodyStyleId, @IsNew, @IsAutoTransmission, @Mileage, 
	@Vin, @Msrp, @VehicleSalePrice, @VehicleDescription, @ModelDate, @IsFeatured, @IsAvailable, @ImageLocation)

SET @VehicleId = SCOPE_IDENTITY();
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleEdit')
		DROP PROCEDURE VehicleEdit	
GO

CREATE PROCEDURE VehicleEdit(
	@VehicleId int,
	@UserId varchar(max),
	@ModelId int,
	@InteriorColorId int,
	@ExteriorColorId int,
	@BodyStyleId int,
	@IsNew bit,
	@IsAutoTransmission bit,
	@Mileage int,
	@Vin varchar(20),
	@Msrp decimal(10,2),
	@VehicleSalePrice decimal(10,2),
	@VehicleDescription varchar(1000),
	@ModelDate int,
	@IsFeatured bit,
	@IsAvailable bit,
	@ImageLocation varchar(25))
AS

BEGIN
IF @ModelId = 0
-- id is 0 if dropdown was not refreshed
UPDATE Vehicle
SET
	UserId = @UserId, 
	--ModelId = @ModelId
	InteriorColorId = @InteriorColorId,
	ExteriorColorId = @ExteriorColorId, 
	BodyStyleId = @BodyStyleId, 
	IsNew = @IsNew, 
	IsAutoTransmission = @IsAutoTransmission, 
	Mileage = @Mileage, 
	Vin = @Vin, 
	Msrp = @Msrp, 
	VehicleSalePrice = @VehicleSalePrice, 
	VehicleDescription = @VehicleDescription, 
	ModelDate = @ModelDate, 
	IsFeatured = @IsFeatured, 
	IsAvailable = @IsAvailable,
	ImageLocation = ISNULL(@ImageLocation, ImageLocation)
	WHERE Vehicle.VehicleId = @VehicleId;

ELSE
UPDATE Vehicle
SET
	UserId = @UserId, 
	ModelId = @ModelId, 
	InteriorColorId = @InteriorColorId,
	ExteriorColorId = @ExteriorColorId, 
	BodyStyleId = @BodyStyleId, 
	IsNew = @IsNew, 
	IsAutoTransmission = @IsAutoTransmission, 
	Mileage = @Mileage, 
	Vin = @Vin, 
	Msrp = @Msrp, 
	VehicleSalePrice = @VehicleSalePrice, 
	VehicleDescription = @VehicleDescription, 
	ModelDate = @ModelDate, 
	IsFeatured = @IsFeatured, 
	IsAvailable = @IsAvailable, 
	ImageLocation = ISNULL(@ImageLocation, ImageLocation)
	WHERE Vehicle.VehicleId = @VehicleId

END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SaleAdd')
		DROP PROCEDURE SaleAdd	
GO

CREATE PROCEDURE SaleAdd(
	@UserId varchar(max),
	@VehicleId int,
	@StateId int,
	@PurchaseTypeId int,
	@Price decimal(10,2),
	@DateSold date,
	@CustomerName varchar(100),
	@Phone varchar(15),
	@Email varchar(100),
	@Street1 varchar(100),
	@Street2 varchar(100),
	@City varchar(100),
	@Zip varchar(5))
AS

BEGIN
INSERT INTO Sale
	(UserId, VehicleId, StateId, PurchaseTypeId, Price, DateSold, CustomerName, Phone, Email, Street1, Street2, City, Zip)
VALUES
	(@UserId, @VehicleId, @StateId, @PurchaseTypeId, @Price, @DateSold, @CustomerName, @Phone, @Email, @Street1, @Street2, @City, @Zip)

UPDATE Vehicle
SET
IsAvailable = 0
WHERE Vehicle.VehicleId = @VehicleId;
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SaleSelectAll')
		DROP PROCEDURE SaleSelectAll	
GO

CREATE PROCEDURE SaleSelectAll
AS

BEGIN
	SELECT SaleId, UserId, VehicleId, StateId, PurchaseTypeId, Price, DateSold, CustomerName, Email, Phone, Street1, Street2, City, Zip
	FROM Sale
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'NewVehicleListingSelect')
		DROP PROCEDURE NewVehicleListingSelect	
GO

CREATE PROCEDURE NewVehicleListingSelect
	@Input varchar(max),
	@PriceMin decimal(10,2),
	@PriceMax decimal(10,2),
	@YearMin int,
	@YearMax int
AS

BEGIN
	IF @Input = ''
	
		SELECT TOP 20 VehicleId, Vehicle.UserId, ModelDate, Make.MakeName, Model.ModelName, 
		BodyStyleName, IsAutoTransmission, InteriorColorName, ExteriorColorName, IsNew, 
		Mileage, Vin, VehicleSalePrice, Msrp, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Vehicle.ModelId = Model.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId
		JOIN BodyStyle ON Vehicle.BodyStyleId = BodyStyle.BodyStyleId
		JOIN InteriorColor ON Vehicle.InteriorColorId = InteriorColor.InteriorColorId
		JOIN ExteriorColor ON Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId

		WHERE IsNew = 1 AND IsAvailable = 1 AND VehicleSalePrice >= @PriceMin AND VehicleSalePrice <= @PriceMax
		AND Vehicle.ModelDate >= @YearMin AND Vehicle.ModelDate <= @YearMax 
		
		ORDER BY Msrp DESC

	ELSE

		SELECT TOP 20 VehicleId, Vehicle.UserId, ModelDate, Make.MakeName, Model.ModelName, 
		BodyStyleName, IsAutoTransmission, InteriorColorName, ExteriorColorName, IsNew, 
		Mileage, Vin, VehicleSalePrice, Msrp, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Vehicle.ModelId = Model.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId
		JOIN BodyStyle ON Vehicle.BodyStyleId = BodyStyle.BodyStyleId
		JOIN InteriorColor ON Vehicle.InteriorColorId = InteriorColor.InteriorColorId
		JOIN ExteriorColor ON Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId

		WHERE IsNew = 1 AND IsAvailable = 1 AND VehicleSalePrice >= @PriceMin AND VehicleSalePrice <= @PriceMax
		AND Vehicle.ModelDate >= @YearMin AND Vehicle.ModelDate <= @YearMax AND 
		(MakeName LIKE '%' + @Input + '%' OR ModelName LIKE '%' + @Input + '%' OR
		TRY_CAST(@Input AS INT) = ModelDate)

		ORDER BY Msrp DESC

END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsedVehicleListingSelect')
		DROP PROCEDURE UsedVehicleListingSelect	
GO

CREATE PROCEDURE UsedVehicleListingSelect
	@Input varchar(max),
	@PriceMin decimal(10,2),
	@PriceMax decimal(10,2),
	@YearMin int,
	@YearMax int
AS

BEGIN
	IF @Input = ''
	
		SELECT TOP 20 VehicleId, Vehicle.UserId, ModelDate, Make.MakeName, Model.ModelName, 
		BodyStyleName, IsAutoTransmission, InteriorColorName, ExteriorColorName, IsNew, 
		Mileage, Vin, VehicleSalePrice, Msrp, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Vehicle.ModelId = Model.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId
		JOIN BodyStyle ON Vehicle.BodyStyleId = BodyStyle.BodyStyleId
		JOIN InteriorColor ON Vehicle.InteriorColorId = InteriorColor.InteriorColorId
		JOIN ExteriorColor ON Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId

		WHERE IsNew = 0 AND IsAvailable = 1 AND VehicleSalePrice >= @PriceMin AND VehicleSalePrice <= @PriceMax
		AND Vehicle.ModelDate >= @YearMin AND Vehicle.ModelDate <= @YearMax 
		
		ORDER BY Msrp DESC

	ELSE

		SELECT TOP 20 VehicleId, Vehicle.UserId, ModelDate, Make.MakeName, Model.ModelName, 
		BodyStyleName, IsAutoTransmission, InteriorColorName, ExteriorColorName, IsNew, 
		Mileage, Vin, VehicleSalePrice, Msrp, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Vehicle.ModelId = Model.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId
		JOIN BodyStyle ON Vehicle.BodyStyleId = BodyStyle.BodyStyleId
		JOIN InteriorColor ON Vehicle.InteriorColorId = InteriorColor.InteriorColorId
		JOIN ExteriorColor ON Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId

		WHERE IsNew = 0 AND IsAvailable = 1 AND VehicleSalePrice >= @PriceMin AND VehicleSalePrice <= @PriceMax
		AND Vehicle.ModelDate >= @YearMin AND Vehicle.ModelDate <= @YearMax AND 
		(MakeName LIKE '%' + @Input + '%' OR ModelName LIKE '%' + @Input + '%' OR
		TRY_CAST(@Input AS INT) = ModelDate)

		ORDER BY Msrp DESC

END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleListingSelect')
		DROP PROCEDURE VehicleListingSelect	
GO
-- where isAvailable = 1. see VehicleSelectAll to include 0
CREATE PROCEDURE VehicleListingSelect
	@Input varchar(max),
	@PriceMin decimal(10,2),
	@PriceMax decimal(10,2),
	@YearMin int,
	@YearMax int
AS

BEGIN
	IF @Input = ''
	
		SELECT TOP 20 VehicleId, Vehicle.UserId, ModelDate, Make.MakeName, Model.ModelName, 
		BodyStyleName, IsAutoTransmission, InteriorColorName, ExteriorColorName, IsNew, 
		Mileage, Vin, VehicleSalePrice, Msrp, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Vehicle.ModelId = Model.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId
		JOIN BodyStyle ON Vehicle.BodyStyleId = BodyStyle.BodyStyleId
		JOIN InteriorColor ON Vehicle.InteriorColorId = InteriorColor.InteriorColorId
		JOIN ExteriorColor ON Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId

		WHERE IsAvailable = 1 AND VehicleSalePrice >= @PriceMin AND VehicleSalePrice <= @PriceMax
		AND Vehicle.ModelDate >= @YearMin AND Vehicle.ModelDate <= @YearMax 
		
		ORDER BY Msrp DESC

	ELSE

		SELECT TOP 20 VehicleId, Vehicle.UserId, ModelDate, Make.MakeName, Model.ModelName, 
		BodyStyleName, IsAutoTransmission, InteriorColorName, ExteriorColorName, IsNew, 
		Mileage, Vin, VehicleSalePrice, Msrp, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Vehicle.ModelId = Model.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId
		JOIN BodyStyle ON Vehicle.BodyStyleId = BodyStyle.BodyStyleId
		JOIN InteriorColor ON Vehicle.InteriorColorId = InteriorColor.InteriorColorId
		JOIN ExteriorColor ON Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId

		WHERE IsAvailable = 1 AND VehicleSalePrice >= @PriceMin AND VehicleSalePrice <= @PriceMax
		AND Vehicle.ModelDate >= @YearMin AND Vehicle.ModelDate <= @YearMax AND 
		(MakeName LIKE '%' + @Input + '%' OR ModelName LIKE '%' + @Input + '%' OR
		TRY_CAST(@Input AS INT) = ModelDate)

		ORDER BY Msrp DESC

END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'FeaturedVehicleSelectAll')
		DROP PROCEDURE FeaturedVehicleSelectAll	
GO

CREATE PROCEDURE FeaturedVehicleSelectAll

AS

BEGIN
		SELECT VehicleId, MakeName, ModelName, ModelDate, VehicleSalePrice, IsFeatured, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Vehicle.ModelId = Model.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId


		WHERE IsAvailable = 1 AND IsFeatured = 1
		
		ORDER BY Msrp DESC
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InventorySelectNew')
		DROP PROCEDURE InventorySelectNew	
GO

CREATE PROCEDURE InventorySelectNew

AS

BEGIN
		SELECT		
		Vehicle.ModelDate,
		Make.MakeName,
		Model.ModelName,
		
		COUNT(Model.ModelId) AS VehicleCount,
		SUM(Vehicle.Msrp) AS TotalMsrpStockValue


		FROM Model

		JOIN Vehicle ON Model.ModelId = Vehicle.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId

		WHERE IsAvailable = 1 AND IsNew = 1
		GROUP BY MakeName, ModelName, Vehicle.ModelDate
		ORDER BY ModelName ASC, Vehicle.ModelDate DESC
		
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InventorySelectUsed')
		DROP PROCEDURE InventorySelectUsed	
GO

CREATE PROCEDURE InventorySelectUsed

AS

BEGIN
		SELECT		
		Vehicle.ModelDate,
		Make.MakeName,
		Model.ModelName,
		
		COUNT(Model.ModelId) AS VehicleCount,
		SUM(Vehicle.Msrp) AS TotalMsrpStockValue


		FROM Model

		JOIN Vehicle ON Model.ModelId = Vehicle.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId

		WHERE IsAvailable = 1 AND IsNew = 0
		GROUP BY MakeName, ModelName, Vehicle.ModelDate
		ORDER BY ModelName ASC, Vehicle.ModelDate DESC
		
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetById')
		DROP PROCEDURE VehicleGetById	
GO

CREATE PROCEDURE VehicleGetById
@VehicleId int
AS

BEGIN
		SELECT VehicleId, ModelDate, MakeName, ModelName, BodyStyleName, IsAutoTransmission, InteriorColorName,
		ExteriorColorName, IsNew, Mileage, Vin, VehicleSalePrice, Msrp, IsAvailable, ImageLocation, VehicleDescription

		FROM Vehicle

		JOIN Model ON Model.ModelId = Vehicle.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId
		Join BodyStyle ON BodyStyle.BodyStyleId = Vehicle.BodyStyleId
		JOIN InteriorColor ON InteriorColor.InteriorColorId = Vehicle.InteriorColorId
		JOIN ExteriorColor ON ExteriorColor.ExteriorColorId = Vehicle.ExteriorColorId

		WHERE Vehicle.VehicleId = @VehicleId
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleEditItemGetById')
		DROP PROCEDURE VehicleEditItemGetById	
GO

CREATE PROCEDURE VehicleEditItemGetById
@VehicleId int
AS

BEGIN
		SELECT VehicleId, Vehicle.UserId, Vehicle.ModelId, Make.MakeId, Vehicle.InteriorColorId, ExteriorColorId, 
		BodyStyleId, IsNew, IsAutoTransmission, Mileage, Vin, Msrp, VehicleSalePrice, VehicleDescription,
		ModelDate, IsFeatured, IsAvailable, ImageLocation

		FROM Vehicle

		JOIN Model ON Model.ModelId = Vehicle.ModelId
		JOIN Make ON Model.MakeId = Make.MakeId

		WHERE Vehicle.VehicleId = @VehicleId
END

GO
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesSearchByUser')
		DROP PROCEDURE SalesSearchByUser	
GO

CREATE PROCEDURE SalesSearchByUser

@FirstLast nvarchar(256),
@DateMin date,
@DateMax date
AS
BEGIN
IF @FirstLast = ''
		SELECT 
		CONCAT(AspNetUsers.FirstName, ' ', AspNetUsers.LastName) AS FirstLast, 
		SUM(Sale.Price) AS TotalSales,
		Count(Sale.SaleId) AS TotalVehicles

		FROM Sale

		JOIN AspNetUsers ON AspNetUsers.Id = Sale.UserId

		WHERE  Sale.DateSold >= @DateMin AND
		Sale.DateSold <= @DateMax

		GROUP BY CONCAT(AspNetUsers.FirstName, ' ', AspNetUsers.LastName)
	ELSE
	SELECT 
		CONCAT(AspNetUsers.FirstName, ' ', AspNetUsers.LastName) AS FirstLast, 
		SUM(Sale.Price) AS TotalSales,
		Count(Sale.SaleId) AS TotalVehicles

		FROM Sale

		JOIN AspNetUsers ON AspNetUsers.Id = Sale.UserId

		WHERE CONCAT(AspNetUsers.FirstName, ' ', AspNetUsers.LastName) LIKE '%' +  @FirstLast + '%' AND 
		Sale.DateSold >= @DateMin AND
		Sale.DateSold <= @DateMax

		GROUP BY CONCAT(AspNetUsers.FirstName, ' ', AspNetUsers.LastName)
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesSearchAllUser')
		DROP PROCEDURE SalesSearchAllUser
GO

CREATE PROCEDURE SalesSearchAllUser
@DateMin date,
@DateMax date
AS
BEGIN
		SELECT 
		CONCAT(AspNetUsers.FirstName, ' ', AspNetUsers.LastName) AS FirstLast, 
		SUM(Sale.Price) AS TotalSales,
		Count(Sale.SaleId) AS TotalVehicles

		FROM Sale

		JOIN AspNetUsers ON AspNetUsers.Id = Sale.UserId

		WHERE Sale.DateSold >= @DateMin AND
		Sale.DateSold <= @DateMax

		GROUP BY CONCAT(AspNetUsers.FirstName, ' ', AspNetUsers.LastName)
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UserSelectAll')
		DROP PROCEDURE UserSelectAll	
GO

CREATE PROCEDURE UserSelectAll
AS

BEGIN
	SELECT Id, LastName, FirstName, Email, RoleId
	FROM AspNetUsers
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectModelsFromMake')
		DROP PROCEDURE SelectModelsFromMake	
GO

CREATE PROCEDURE SelectModelsFromMake
@MakeId int
AS

BEGIN
	SELECT ModelName, ModelId
	FROM Model
	WHERE Model.MakeId = @MakeId
END

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteVehicle')
		DROP PROCEDURE DeleteVehicle	
GO

CREATE PROCEDURE DeleteVehicle
@VehicleId int
AS

BEGIN
	DELETE Vehicle
	WHERE Vehicle.VehicleId = @VehicleId
END

GO