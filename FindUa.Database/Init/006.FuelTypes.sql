MERGE INTO [dbo].[FuelTypes] AS Target
USING
(
	VALUES
	(1, N'Petrol'),
	(2, N'Diesel'),
	(3, N'Gas'),
	(4, N'Petrol/Gas'),
	(5, N'Hybrid'),
	(6, N'PropaneGas'),
	(7, N'MethaneGas'),
	(8, N'Electric')
) AS Source ([Id], [Name])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name])
	VALUES (Source.[Id], Source.[Name]);