USE HotelDB;
GO

--1. Return list of resvs that end in July 2023. Incl guest name, room numbers, and resv dates

SELECT 
	Reservation.reservationId,
	CONCAT(Guest.firstName, ' ', Guest.lastName) GuestName,
	RoomReservation.roomId RoomNumber,
	Reservation.startDate,
	Reservation.endDate
FROM Reservation
JOIN Guest ON Reservation.guestId = Guest.guestId
JOIN RoomReservation ON Reservation.reservationId = RoomReservation.reservationId
WHERE endDate BETWEEN '2023-07-01' AND '2023-07-31';
--4 results


--------------------------------------------------------------------------------------------------

--2. Return list of all resvs for rooms with jacuzzi. Incl guest name, room num, and resv dates

SELECT
	Reservation.reservationId,
	CONCAT(Guest.firstName, ' ', Guest.lastName) GuestName,
	RoomReservation.roomId RoomNumber,
	Reservation.startDate,
	Reservation.endDate
FROM Reservation
JOIN Guest ON Reservation.guestId = Guest.guestId
JOIN RoomReservation ON Reservation.reservationId = RoomReservation.reservationId
WHERE roomId IN (
	SELECT roomId FROM RoomAmenity
	WHERE amenityId IN (
		SELECT amenityId FROM Amenity
		WHERE amenityDescription LIKE '%Jacuzzi%'));
--11 results


--------------------------------------------------------------------------------------------------

--3. Return all rooms reserved for [choose any] specific guest. Incl guest name, rooms reserved, starting date, and how many people included in res.

SELECT
	CONCAT(Guest.firstName, ' ', Guest.lastName) GuestName,
	RoomReservation.roomId RoomNumber,
	Reservation.startDate, 
	(Reservation.adults + Reservation.Children) AS Occupants
FROM Guest
JOIN Reservation ON Guest.guestId = Reservation.guestId
JOIN RoomReservation ON Reservation.reservationId = RoomReservation.reservationId
WHERE Guest.firstName = 'Mack'; 
--4 results


--------------------------------------------------------------------------------------------------

--4. Return list of rooms, resv ID, per-room cost of each res. Incl all rooms, wh/n a resv is present for that room.

SELECT
	Room.roomId RoomNumber,
	Reservation.reservationId,
	RoomType.basePrice
FROM Room
LEFT OUTER JOIN RoomReservation ON Room.roomId = RoomReservation.roomId
LEFT OUTER JOIN Reservation ON RoomReservation.reservationId = Reservation.reservationId
LEFT OUTER JOIN RoomType ON Room.roomTypeId = RoomType.roomTypeId
ORDER BY RoomNumber;
--26 results


--------------------------------------------------------------------------------------------------

--5. Return all rooms accommodating at least 3 (>=3) guests that are reserved on any date in Apr 2023.

SELECT 
	RoomReservation.roomId RoomNumber
FROM RoomReservation
JOIN Reservation ON RoomReservation.reservationId = Reservation.reservationId
WHERE (adults + children >= 3) AND 
	((startDate <= '2023-04-01' AND endDate >= '2023-04-01')
	OR (startdate >= '2023-04-01' AND endDate <= '2023-05-01')
	OR (startDate <= '2023-05-01' AND endDate >= '2023-05-01'));
--0 results	

--------------------------------------------------------------------------------------------------

--6. Return list of all guest names and number of resvs per guest. Sort by guest with most resvs, then l_name.

SELECT
	Guest.lastName,
	COUNT(Reservation.reservationId) ReservationCount
FROM Guest
JOIN Reservation ON Guest.guestId = Reservation.guestId
GROUP BY Guest.lastName 
ORDER BY ReservationCount DESC, Guest.lastName;
--11 results


--------------------------------------------------------------------------------------------------

--7. Display name, address, and phone of a guest based on phone number [choose any phone in data]

SELECT
	CONCAT(Guest.firstName, ' ', Guest.lastName) GuestName,
	CONCAT(Guest.[address], ', ', Guest.city, ', ', [State].stateName, ' ', Guest.zip) [Address],
	Guest.phone
FROM Guest
JOIN [State] ON [State].stateId = Guest.stateId
WHERE Guest.phone = '2318932755';
--Joleen's deets
