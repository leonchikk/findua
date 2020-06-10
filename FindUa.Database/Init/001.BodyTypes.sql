MERGE INTO [dbo].[BodyTypes] AS Target
USING
(
	VALUES
	(1, N'Hatchback'),
	(2, N'Sedan'),
	(3, N'MUV/SUV'),
	(4, N'Coupe'),
	(5, N'Convertible'),
	(6, N'Wagon'),
	(7, N'Van'),
	(8, N'Jeep')
) AS Source ([Id], [Name])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name])
	VALUES (Source.[Id], Source.[Name], Source.[Code], Source.[Language]);