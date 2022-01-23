USE [master]
GO

USE GuildCars;
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset	
GO

CREATE PROCEDURE DbReset
AS
BEGIN

	DELETE FROM Sale;
		DELETE FROM Vehicle;
			DELETE FROM Model;
				DELETE FROM Make;
			DELETE FROM InteriorColor;
			DELETE FROM ExteriorColor;
			DELETE FROM PurchaseType;
			DELETE FROM BodyStyle;
		DELETE FROM [State];
	DELETE FROM Special;
	DELETE FROM ContactUs;

	DBCC CHECKIDENT ('Vehicle', RESEED, 1)
	DBCC CHECKIDENT ('Sale', RESEED, 1)
	DBCC CHECKIDENT ('Model', RESEED, 1)
	DBCC CHECKIDENT ('Make', RESEED, 1)
	DBCC CHECKIDENT ('InteriorColor', RESEED, 1)
	DBCC CHECKIDENT ('ExteriorColor', RESEED, 1)
	DBCC CHECKIDENT ('PurchaseType', RESEED, 1)
	DBCC CHECKIDENT ('ContactUs', RESEED, 1)
	DBCC CHECKIDENT ('BodyStyle', RESEED, 1)
	DBCC CHECKIDENT ('Special', RESEED, 1)
	DBCC CHECKIDENT ('[State]', RESEED, 1)

	DELETE FROM AspNetUsers WHERE id='00000000-0000-0000-0000-000000000000';
	DELETE FROM AspNetUsers WHERE id='11111111-1111-1111-1111-111111111111';

	SET IDENTITY_INSERT Special ON
	INSERT INTO Special (SpecialId, SpecialTitle, SpecialDescription)
	VALUES (1, 'Hello World!', 'I''m a test special! And BOY, do I feel SPECIAL! :)'),
		(2, 'Wow! You Won''t believe this special!', 'Uh, I don''t know what to put here.');
	SET IDENTITY_INSERT Special OFF
	
	SET IDENTITY_INSERT ContactUs ON
	INSERT INTO ContactUs (vehicleInquiryId, [Name], Email, [Message], Phone)
	VALUES (1, 'Tester McGee', 'TestBoi99@gmail.com', 'yo, this car kinda looks jank.', '111-222-3333'),
		(2, 'Tester McGee Jr.', 'TestBoiJr@gmail.com', 'Sorry about my dad''s message, he was inebriated', null);
	SET IDENTITY_INSERT ContactUs OFF

	SET IDENTITY_INSERT [State] ON
	INSERT INTO [State] (StateId, StateName)
		VALUES (1, 'AL'), (2, 'AK'), (3, 'AZ'), (4, 'AR'), (5, 'CA'), (6, 'CO'), (7, 'CT'), (8, 'DE'), (9, 'FL'), (10, 'GA'),
	(11, 'HI'), (12, 'ID'), (13, 'IL'), (14, 'IN'), (15, 'IA'), (16, 'KS'), (17, 'KY'), (18, 'LA'), (19, 'ME'), (20, 'MD'),
	(21, 'MA'), (22, 'MI'), (23, 'MN'), (24, 'MS'), (25, 'MO'), (26, 'MT'), (27, 'NE'), (28, 'NV'), (29, 'NH'), (30, 'NJ'),
	(31, 'NM'), (32, 'NY'), (33, 'NC'), (34, 'ND'), (35, 'OH'), (36, 'OK'), (37, 'OR'), (38, 'PA'), (39, 'RI'), (40, 'SC'),
	(41, 'SD'), (42, 'TN'), (43, 'TX'), (44, 'UT'), (45, 'VT'), (46, 'VA'), (47, 'WA'), (48, 'WV'), (49, 'WI'), (50, 'WY');
	SET IDENTITY_INSERT [State] OFF
	

	SET IDENTITY_INSERT [BodyStyle] ON
	INSERT INTO BodyStyle (BodyStyleId, BodyStyleName)
	VALUES (1, 'Car'), (2, 'SUV'), (3, 'Truck'), (4, 'Van');
	SET IDENTITY_INSERT [BodyStyle] OFF

	SET IDENTITY_INSERT PurchaseType ON
	INSERT INTO PurchaseType (PurchaseTypeId, PurchaseTypeName)
	VALUES (1, 'Bank Finance'), (2, 'Cash'), (3, 'Dealer Finance');
	SET IDENTITY_INSERT PurchaseType OFF
	

	SET IDENTITY_INSERT InteriorColor ON
	INSERT INTO InteriorColor (InteriorColorId, InteriorColorName)
	VALUES (1, 'Black'), (2, 'Grey'), (3, 'Tan'),
	(4, 'Brown Leather');
	
	SET IDENTITY_INSERT InteriorColor OFF
	

	SET IDENTITY_INSERT ExteriorColor ON
	INSERT INTO ExteriorColor (ExteriorColorId, ExteriorColorName)
	VALUES (1, 'Yellow'), (2, 'Silver'), (3, 'Vomit Green'),
			(4, 'Brick Red'), (5, 'White');
		SET IDENTITY_INSERT ExteriorColor OFF
	

	INSERT INTO AspNetUsers(Id, RoleId, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName)
	VALUES('00000000-0000-0000-0000-000000000000', 1, 'testuser@test.net', 0, 0, 0, 0, 0, 'testuser@test.net', 'Test', 'Boi'),
		  ('11111111-1111-1111-1111-111111111111', 1, 'testuser2@test.net', 0, 0, 0, 0, 0, 'testuser2@test.net', 'Test2', 'Boi2');

	SET IDENTITY_INSERT Make ON
	INSERT INTO Make (MakeId, MakeName, UserId, DateAdded)
	VALUES (1, 'Porsche', '00000000-0000-0000-0000-000000000000', '01-01-2021'), 
	(2, 'Ford', '00000000-0000-0000-0000-000000000000', '01-02-2021'),
	(3, 'Tesla', '00000000-0000-0000-0000-000000000000', '12-12-2021');
	
	SET IDENTITY_INSERT Make OFF


	SET IDENTITY_INSERT Model ON
	INSERT INTO Model (ModelId, ModelName, MakeId, UserId, DateAdded)
	VALUES (1, 'Fiesta', 2, '00000000-0000-0000-0000-000000000000', '01-01-2021'),
			(2, 'Cayenne', 1, '00000000-0000-0000-0000-000000000000', '01-02-2021'),
			(3, 'Fusion', 2, '00000000-0000-0000-0000-000000000000', '01-03-2021'),
			(4, 'Mustang', 2, '11111111-1111-1111-1111-111111111111',  '01-01-2022'),
			(5, '911', 1, '11111111-1111-1111-1111-111111111111', '01-01-2022'),
			(6, 'Cybertruck', 3, '00000000-0000-0000-0000-000000000000', '12-12-2021'),
			(7, 'Transit Connect Cargo Van', 2, '00000000-0000-0000-0000-000000000000', '12-12-2021');
			
	SET IDENTITY_INSERT Model OFF


	SET IDENTITY_INSERT Vehicle ON
	INSERT INTO Vehicle (VehicleId, UserId, ModelId, InteriorColorId, ExteriorColorId, BodyStyleId, IsNew, IsAutoTransmission, Mileage, 
			Vin, Msrp, VehicleSalePrice, VehicleDescription, ModelDate, IsFeatured, IsAvailable, ImageLocation)
	VALUES
	(1, '00000000-0000-0000-0000-000000000000', 1, 1, 1, 1, 1, 1, 100, '12345678901234567', 16100, 15000, 
	'This is a new yellow ford fiesta with an ugly black interior. Gross. SOLD!', 2021, 1, 0, null),
	(2, '00000000-0000-0000-0000-000000000000', 1, 2, 2, 1, 0, 1, 100000, '01234567890123456', 16100, 9000, 
	'This is a used silver ford fiesta. The image may look yellow, but images may be deceiving....', 
	2021, 0, 1, 'inventory-2.jpeg'),
	(3, '00000000-0000-0000-0000-000000000000', 2, 3, 3, 1, 1, 1, 9, '76543210987654321', 23200, 22000, 
	'This is a new vomit green porsche cayenne with a tan interior. Mmmm, vomit.', 2021, 1, 1, 'inventory-3.jpeg'),
	(4, '00000000-0000-0000-0000-000000000000', 3, 2, 1, 2, 0, 1, 6969, '10203040506070809', 69000, 60000, 
	'This is a (nice) used yellow porsche cayenne with a green interior.', 2021, 0, 1, null),
	(5, '00000000-0000-0000-0000-000000000000', 3, 2, 1, 2, 1, 1, 0, '90807060504030201', 69000, 65000, 
	'This is a test, it is sold and featured, just to make it weird.', 2021, 1, 0, null),
	(6, '00000000-0000-0000-0000-000000000000', 1, 1, 1, 1, 1, 1, 100, '12345678901234568', 16100, 15000, 
	'This is a copy of index 1, but available. make it a sale, pls', 2020, 1, 1, null),
	(7, '00000000-0000-0000-0000-000000000000', 1, 2, 2, 1, 0, 1, 1000000, '11234567890123456', 16100, 300, 
	'Used silver ford fiesta with one million miles.', 
	2021, 1, 1, null),
	(8, '11111111-1111-1111-1111-111111111111', 4, 4, 4, 1, 1, 1, 50, '88004567890123456', 27205, 27000, 
	'Brick red ford mustang with brown leather interior. New', 
	2021, 1, 1, 'inventory-8.jpg'),
	(9, '11111111-1111-1111-1111-111111111111', 5, 4, 4, 1, 1, 1, 0, '91191191191191100', 97400, 90000, 
	'Brick red porsche 911 with brown leather interior. New', 
	2020, 0, 1, null),
	(10, '00000000-0000-0000-0000-000000000000', 6, 1, 2, 3, 0, 1, 50000, 'XAEA-XII123456789', 39900, 30000, 
	'It''s Cyber, and it''s a truck. Smells musky.', 2019, 1, 1, 'inventory-10.png'),
	(11, '00000000-0000-0000-0000-000000000000', 7, 1, 5, 4, 1, 0, 0, '11111567890123456', 24600, 20000,
	'White, black interior, new.', 2021, 0, 1, null);

	SET IDENTITY_INSERT Vehicle OFF
	
	SET IDENTITY_INSERT Sale ON
	INSERT INTO Sale (SaleId, UserId, VehicleId, StateId, PurchaseTypeId, Price, DateSold, CustomerName, Email, Phone, Street1, Street2, City, Zip)
	VALUES
	(1, '00000000-0000-0000-0000-000000000000', 1, 1, 1, 15000, '01-01-2020', 'I Myself', null, null, 'Street', null, 'Big City', '29292'),
	(2, '11111111-1111-1111-1111-111111111111', 5, 2, 2, 65000, '01-01-2019', 'Not Me', null, null, 'Street', 'With another street', 'Small City', '92929')
	
END
