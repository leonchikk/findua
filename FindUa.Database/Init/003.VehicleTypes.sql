MERGE INTO [dbo].[VehicleTypes] AS Target
USING
(
	VALUES
	(1, N'PassengerCar'),
	(2, N'Moto'),
	(3, N'AirTransport'),
	(4, N'Trucks'),
	(5, N'AgriculturalMachinery'),
	(6, N'SpecialMachinery'),
	(7, N'Bus'),
	(8, N'Trailer'),
	(9, N'HouseOnWheels'),
	(10, N'WaterTransport'),
	(11, N'NA')
) AS Source ([Id], [Name])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name])
	VALUES (Source.[Id], Source.[Name]);