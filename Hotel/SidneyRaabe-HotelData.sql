USE HotelDB;
GO

INSERT INTO [State] (stateName) VALUES 
	('AL'), ('AK'), ('AZ'), ('AR'), ('CA'), ('CO'), ('CT'), ('DE'), ('FL'), ('GA'),
	('HI'), ('ID'), ('IL'), ('IN'), ('IA'), ('KS'), ('KY'), ('LA'), ('ME'), ('MD'),
	('MA'), ('MI'), ('MN'), ('MS'), ('MO'), ('MT'), ('NE'), ('NV'), ('NH'), ('NJ'),
	('NM'), ('NY'), ('NC'), ('ND'), ('OH'), ('OK'), ('OR'), ('PA'), ('RI'), ('SC'),
	('SD'), ('TN'), ('TX'), ('UT'), ('VT'), ('VA'), ('WA'), ('WV'), ('WI'), ('WY');

INSERT INTO Guest (firstName, LastName, address, city, stateId, zip, phone) VALUES 
	('Sidney', 'Raabe', 'Someplace', 'Hell', 35, '66666', '1234567890'),
	('Mack', 'Simmer', '379 Old Shore Street', 'Council Bluffs', 15, '51501', '2915530508'),
	('Bettyann', 'Seery', '750 Wintergreen Dr.', 'Wasilla', 2, '99654', '4782779632'),
	('Duane', 'Cullison', '9662 Foxrun Lane', 'Harlingen', 43, '78552', '3084940198'),
	('Karie', 'Yang', '9378 W. Augusta Ave', 'West Deptford', 30, '08096', '2147300298'),
	('Aurore', 'Lipton', '762 Wild Rose Street', 'Saginaw', 25, '48601', '3775070974'),
	('Zachery', 'Luechtefeld', '7 Poplar Dr.', 'Arvada', 6, '80003', '8144852615'),
	('Jeremiah', 'Pendergrass', '70 Oakwood St.', 'Zion', 13, '60099', '2794910960'),
	('Walter', 'Holaway', '7556 Arrowhead St.', 'Cumberland', 39, '02864', '4463966785'),
	('Willfred', 'Vise', '77 West Surrey Street', 'Oswego', 32, '13126', '8347271001'),
	('Maritza', 'Tilton', '939 Linda Rd.', 'Burke', 46, '22015', '4463516860'),
	('Joleen', 'Tison', '87 Queen St.', 'Drexel Hill', 38, '19026', '2318932755');

INSERT INTO Reservation (guestId, adults, children, startDate, endDate, totalCost) VALUES 
	(2, 1, 0, '2023-02-02', '2023-02-04', 299.98),
	(3, 2, 1, '2023-02-05', '2023-02-10', 999.95),
	(4, 2, 0, '2023-02-22', '2023-02-24', 349.98),
	(5, 2, 2, '2023-03-06', '2023-03-07', 199.99),
	(1, 1, 1, '2023-03-17', '2023-03-20', 524.97),
	(6, 3, 0, '2023-03-18', '2023-03-23', 924.95),
	(7, 2, 2, '2023-03-29', '2023-03-31', 349.98),
	(8, 2, 0, '2023-03-31', '2023-04-05', 874.95),
	(9, 1, 0, '2023-04-09', '2023-04-13', 799.96),
	(10, 1, 1, '2023-04-23', '2023-04-24', 174.99),
	(11, 2, 4, '2023-05-30', '2023-06-02', 1199.97),
	(12, 2, 0, '2023-06-10', '2023-06-14', 599.96),
	(12, 1, 0, '2023-06-10', '2023-06-14', 599.96),
	(6, 3, 0, '2023-06-17', '2023-06-18', 184.99),
	(1, 2, 0, '2023-06-28', '2023-07-02', 699.96),
	(9, 3, 1, '2023-07-13', '2023-07-14', 184.99),
	(10, 4, 2, '2023-07-18', '2023-07-21', 1259.97),
	(3, 2, 1, '2023-07-28', '2023-07-29', 199.99),
	(3, 1, 0, '2023-08-30', '2023-09-01', 349.98),
	(2, 2, 0, '2023-09-16', '2023-09-17', 149.99),
	(5, 2, 2, '2023-09-13', '2023-09-15', 399.98),
	(4, 2, 2, '2023-11-22', '2023-11-25', 1199.97),
	(2, 2, 0, '2023-11-22', '2023-11-25', 449.97),
	(2, 2, 2, '2023-11-22', '2023-11-25', 599.97),
	(11, 2, 0, '2023-12-24', '2023-12-28', 699.96);

INSERT INTO RoomCategory (roomCategoryName) VALUES 
	('Single'),
	('Double'),
	('Suite');

INSERT INTO RoomType (roomCategoryId, occupancyMin, occupancyMax, basePrice, extraGuestFee) VALUES
	(1, 2, 2, 149.99, null),
	(1, 2, 2, 174.99, null),
	(2, 2, 4, 174.99, 10),
	(2, 2, 4, 199.99, 10),
	(3, 3, 8, 399.99, 20);

INSERT INTO Room (roomId, roomTypeId, hasADA) VALUES
	(201, 4, 0),
	(202, 3, 1),
	(203, 4, 0),
	(204, 3, 1),
	(205, 2, 0),
	(206, 1, 1),
	(207, 2, 0),
	(208, 1, 1),
	(301, 4, 0),
	(302, 3, 1),
	(303, 4, 0),
	(304, 3, 1),
	(305, 2, 0),
	(306, 1, 1),
	(307, 2, 0),
	(308, 1, 1),
	(401, 5, 1),
	(402, 5, 1);

INSERT INTO RoomReservation (reservationId, roomId)  VALUES
	(1, 308),
	(2, 203),
	(3, 305),
	(4, 201),
	(5, 307),
	(6, 302),
	(7, 202),
	(8, 304),
	(9, 301),
	(10, 207),
	(11, 401),
	(12, 206),
	(13, 208),
	(14, 304),
	(15, 205),
	(16, 204),
	(17, 401),
	(18, 303),
	(19, 305),
	(20, 208),
	(21, 203),
	(22, 401),
	(23, 206),
	(24, 301),
	(25, 302);

INSERT INTO Amenity (amenityDescription, amenityFee) VALUES
	('Microwave, Jacuzzi', 25),
	('Refrigerator', null),
	('Microwave, Refrigerator, Jacuzzi', 25),
	('Microwave, Refrigerator', null),
	('Microwave, Refrigerator, Oven', null);

INSERT INTO RoomAmenity (roomId, amenityId) VALUES
	(201, 1),
	(202, 2),
	(203, 1),
	(204, 2),
	(205, 3),
	(206, 4),
	(207, 3),
	(208, 4),
	(301, 1),
	(302, 2),
	(303, 1),
	(304, 2),
	(305, 3),
	(306, 4),
	(307, 3),
	(308, 4),
	(401, 5),
	(402, 5);



--- QUICK! WE GOTTA DELETE JEREMIAH, THE FEDS ARE AFTER HIM!

DELETE FROM RoomReservation
WHERE reservationId IN (
	SELECT reservationId FROM Reservation
	WHERE guestId = 8)

DELETE FROM Reservation 
WHERE guestId = 8;

DELETE FROM Guest
WHERE guestId = 8;
