MERGE INTO [dbo].[BodyTypes] AS Target
USING
(
	VALUES
	/* Passenger Car */
	(1, N'Hatchback', 1),
	(2, N'StationWagon', 1),
	(3, N'Sedan', 1),
	(4, N'SUV', 1),
	(5, N'Coupe', 1),
	(6, N'Cabriolet', 1),
	(7, N'Minivan', 1),
	(8, N'Pickup', 1),
	(9, N'Limousine', 1),
	(10, N'Roadster', 1),
	(11, N'Liftback', 1),
	(12, N'Other', 1)
) AS Source ([Id], [Name], [VehicleTypeId])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name], [VehicleTypeId])
	VALUES (Source.[Id], Source.[Name], Source.[VehicleTypeId]);